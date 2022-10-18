using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.ObjectiveC
{
    public unsafe struct DisposablePointer<T> : IDisposable where T : struct
    {
        public IntPtr RawPtr;

        public T[] ToArrayOfSize(uint size)
        {
            T[] managedArray = new T[size];
            using (var pin = new DisposablePinnedObject(managedArray))
            {
                UnsafeUtility.MemCpy((void*) pin.Address, (void*) RawPtr, UnsafeUtility.SizeOf<T>() * size);
                return managedArray;
            }
        }

        public void Dispose()
        {
            Runtime.free(RawPtr);
        }
    }
}