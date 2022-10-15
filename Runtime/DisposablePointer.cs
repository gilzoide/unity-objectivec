using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.ObjectiveC
{
    public unsafe struct DisposablePointer<T> : IDisposable where T : struct
    {
        public IntPtr RawPtr;

        public void Dispose()
        {
            Runtime.free(RawPtr);
        }

        public T[] ToArrayOfSize(uint size)
        {
            T[] managedArray = new T[size];
            GCHandle gcHandle = GCHandle.Alloc(managedArray, GCHandleType.Pinned);
            try
            {
                UnsafeUtility.MemCpy((void*) gcHandle.AddrOfPinnedObject(), (void*) RawPtr, UnsafeUtility.SizeOf<T>() * size);
                return managedArray;
            }
            finally
            {
                gcHandle.Free();
            }
        }
    }
}