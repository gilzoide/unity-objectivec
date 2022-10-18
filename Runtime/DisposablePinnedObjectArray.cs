using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public class DisposablePinnedObjectArray : IDisposable
    {
        private GCHandle[] _gcHandles;

        public DisposablePinnedObjectArray(Array array)
        {
            _gcHandles = new GCHandle[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                _gcHandles[i] = GCHandle.Alloc(array.GetValue(i), GCHandleType.Pinned);
            }
        }

        public IntPtr this[int index] => _gcHandles[index].AddrOfPinnedObject();
        public int Length => _gcHandles.Length;

        public void Dispose()
        {
            foreach (GCHandle handle in _gcHandles)
            {
                handle.Free();
            }
        }
    }
}
