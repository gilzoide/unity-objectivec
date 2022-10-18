using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC.Foundation
{
    public struct NSString : IId
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
            Id newString = Runtime.objc_msgSend(Class, "alloc");
            NSString nsstring = objc_msgSend(newString, "initWithCharacters:length:", str, (ulong) str.Length);
            return new StrongReference<NSString>(nsstring);
        }

        public static AutoreleasedReference<NSString> StringWith(string str)
        {
            NSString nsstring = objc_msgSend(Class, "stringWithCharacters:length:", str, (ulong) str.Length);
            return new AutoreleasedReference<NSString>(nsstring);
        }

        public Id AsId => _self;

        public override string ToString()
        {
            IntPtr dataPtr = Runtime.objc_msgSend(_self, "UTF8String").RawPtr;
            return Marshal.PtrToStringAnsi(dataPtr);
        }

        public static implicit operator Id(NSString str)
        {
            return str._self;
        }
    }
}
