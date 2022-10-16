using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public struct DisposablePinnedObject : IDisposable
    {
        private GCHandle _handle;

        public IntPtr Address => _handle.AddrOfPinnedObject();

        public DisposablePinnedObject(object obj)
        {
            _handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
        }

        public void Dispose()
        {
            _handle.Free();
        }
    }
}