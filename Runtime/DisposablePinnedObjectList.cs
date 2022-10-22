using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public class DisposablePinnedObjectList : IDisposable, IReadOnlyList<IntPtr>
    {
        private List<GCHandle> _gcHandles = new List<GCHandle>();

        public int Count => _gcHandles.Count;
        public IntPtr this[int index] => _gcHandles[index].AddrOfPinnedObject();

        public DisposablePinnedObjectList(IEnumerable<object> array)
        {
            foreach (object obj in array)
            {
                _gcHandles.Add(GCHandle.Alloc(obj, GCHandleType.Pinned));
            }
        }

        public void Dispose()
        {
            foreach (GCHandle handle in _gcHandles)
            {
                handle.Free();
            }
        }

        public IEnumerator<IntPtr> GetEnumerator()
        {
            foreach (GCHandle handle in _gcHandles)
            {
                yield return handle.AddrOfPinnedObject();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
