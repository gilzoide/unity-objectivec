using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public static class ObjectiveCNative
    {
        [DllImport("ObjectiveCNative.dylib")]
        public static extern Id Gilzoide_ObjectiveC_NSInvocationProtectedInvoke(Id invocation);

        [DllImport("ObjectiveCNative.dylib")]
        public static extern void Gilzoide_ObjectiveC_BlockWithPointer(out Block block, IntPtr functionPointer);
    }
}