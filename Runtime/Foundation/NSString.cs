using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public struct NSString : IConvertibleToId
    {
        public static readonly Class Class = new Class("NSString");

        [DllImport("__Internal", EntryPoint = "objc_msgSend", CharSet = CharSet.Unicode)]
        public static extern NSString objc_msgSend_charp_ulong(Id obj, Selector selector, string str, ulong length);

        private Id _self;

        public NSString(Id self)
        {
            _self = self;
        }

        public Id ToId()
        {
            return _self;
        }

        public static StrongReference<NSString> Alloc(string str)
        {
            NSString nsstring = objc_msgSend_charp_ulong(Class.ToId().Call<Id>("alloc"), "initWithCharacters:length:", str, (ulong) str.Length);
            return new StrongReference<NSString>(nsstring);
        }

        public static AutoreleasedReference<NSString> StringWith(string str)
        {
            NSString nsstring = objc_msgSend_charp_ulong(Class, "stringWithCharacters:length:", str, (ulong) str.Length);
            return new AutoreleasedReference<NSString>(nsstring);
        }

        public override string ToString()
        {
            IntPtr dataPtr = _self.Call<IntPtr>("UTF8String");
            return Marshal.PtrToStringUTF8(dataPtr);
        }

        public static implicit operator Id(NSString str)
        {
            return str._self;
        }
    }
}
