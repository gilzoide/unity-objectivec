#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public struct AutoFreeCString : IDisposable
    {
        public IntPtr RawPtr;

        public void Dispose()
        {
            Runtime.free(RawPtr);
        }

        public override string ToString()
        {
            return Marshal.PtrToStringAnsi(RawPtr);
        }
    }
}
#endif