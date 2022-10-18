using System;
using System.Runtime.InteropServices;
using Gilzoide.ObjectiveC.Foundation;

namespace Gilzoide.ObjectiveC
{
    public static class ObjectiveCNative
    {
#if UNITY_IOS && !UNITY_EDITOR
        private const string _dllName = "__Internal";
#else
        private const string _dllName = "ObjectiveCNative.dylib";
#endif

        [DllImport(_dllName)]
        public static extern Id Gilzoide_ObjectiveC_NSInvocationProtectedInvoke(NSInvocation invocation);

        [DllImport(_dllName)]
        public static extern void Gilzoide_ObjectiveC_BlockWithPointer(out Block block, IntPtr functionPointer);
    }
}