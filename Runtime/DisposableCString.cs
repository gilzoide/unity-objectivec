using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public struct DisposableCString : IDisposable
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