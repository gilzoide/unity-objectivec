using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public unsafe struct Block
    {
        private IntPtr isa;
        private int flags;
        private int reserved;
        private IntPtr invoke;
        private IntPtr descriptor;

        public static void CheckValidDelegate(Delegate del)
        {
            ParameterInfo[] parameters = del.Method.GetParameters();
            if (parameters == null || parameters.Length == 0)
            {
                throw new ObjectiveCException("Block delegate must have its first parameter of type 'Id' or other pointer sized struct");
            }

            Type firstParameterType = parameters[0].ParameterType;
            if (Marshal.SizeOf(firstParameterType) != sizeof(Id))
            {
                throw new ObjectiveCException("Block delegate's first parameter must be 'Id' or have the size of a pointer");
            }
        }

        public static Block FromDelegate(Delegate del)
        {
            CheckValidDelegate(del);
            IntPtr functionPointer = Marshal.GetFunctionPointerForDelegate(del);
            ObjectiveCNative.Gilzoide_ObjectiveC_BlockWithPointer(out Block block, functionPointer);
            return block;
        }
    }
}
