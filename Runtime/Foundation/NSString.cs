using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC.Foundation
{
    public unsafe struct NSString : IId
    {
        public static readonly Class Class = new Class("NSString");

        [DllImport("__Internal", CharSet = CharSet.Unicode)]
        public static extern NSString objc_msgSend(Id obj, Selector selector, string str, ulong length);

        [DllImport("__Internal")]
        public static extern long CFStringGetLength(NSString theString);

        private Id _self;

        public int Length => (int) CFStringGetLength(this);

        public NSString(Id self)
        {
            _self = self;
        }

        public static StrongReference<NSString> Alloc(string str)
        {
            fixed (char* ptr = str)
            {
                return Class.Alloc<StrongReference<NSString>>("initWithCharacters:length:", (IntPtr) ptr, (ulong) str.Length);
            }
        }

        public static AutoreleasedReference<NSString> StringWith(string str)
        {
            fixed (char* ptr = str)
            {
                return Class.Call<AutoreleasedReference<NSString>>("stringWithCharacters:length:", (IntPtr) ptr, (ulong) str.Length);
            }
        }

        public Id AsId => _self;

        public override string ToString()
        {
            IntPtr dataPtr = _self.Call<IntPtr>("UTF8String");
            return Marshal.PtrToStringAnsi(dataPtr);
        }

        public static explicit operator NSString(string s)
        {
            return StringWith(s);
        }
        public static explicit operator NSString(Id obj)
        {
            return new NSString(obj);
        }
        public static implicit operator Id(NSString str)
        {
            return str._self;
        }
    }
}
