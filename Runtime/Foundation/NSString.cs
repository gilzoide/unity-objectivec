using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public struct NSString : IConvertibleToId
    {
        public static readonly Class Class = new Class("NSString");

        private static Selector Selector_initWithCharacters_length = "initWithCharacters:length:";
        private static Selector Selector_stringWithCharacters_length = "stringWithCharacters:length:";
        private static Selector Selector_UTF8String = "UTF8String";

        [DllImport("__Internal", EntryPoint = "objc_msgSend", CharSet = CharSet.Unicode)]
        public static extern NSString objc_msgSend_charp_ulong(Id obj, Selector selector, string str, ulong length);

        [DllImport("__Internal")]
        public static extern long CFStringGetLength(NSString theString);

        private Id _self;

        public long Length => CFStringGetLength(this);

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
            NSString nsstring = objc_msgSend_charp_ulong(Class.ToId().Call<Id>("alloc"), Selector_initWithCharacters_length, str, (ulong) str.Length);
            return new StrongReference<NSString>(nsstring);
        }

        public static AutoreleasedReference<NSString> StringWith(string str)
        {
            NSString nsstring = objc_msgSend_charp_ulong(Class, Selector_stringWithCharacters_length, str, (ulong) str.Length);
            return new AutoreleasedReference<NSString>(nsstring);
        }

        public override string ToString()
        {
            IntPtr dataPtr = Runtime.objc_msgSend(_self, Selector_UTF8String).RawPtr;
            return Marshal.PtrToStringAnsi(dataPtr);
        }

        public static implicit operator Id(NSString str)
        {
            return str._self;
        }
    }
}
