using System;

namespace Gilzoide.ObjectiveC
{
    public struct Ivar
    {
        public IntPtr RawPtr;

        public unsafe string Name => Runtime.ivar_getName(this).ToString();
        public unsafe string TypeEncoding => Runtime.ivar_getTypeEncoding(this).ToString();
        public uint Offset => (uint) Runtime.ivar_getOffset(this);

        public Ivar(IntPtr rawPtr)
        {
            RawPtr = rawPtr;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}