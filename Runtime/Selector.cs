using System;

namespace Gilzoide.ObjectiveC
{
    public struct Selector
    {
        public IntPtr RawPtr;

        public Selector(string name)
        {
            RawPtr = Runtime.sel_registerName(name).RawPtr;
        }

        public string Name => Runtime.sel_getName(this).ToString();

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator Selector(string name)
        {
            return Runtime.sel_registerName(name);
        }
    }
}