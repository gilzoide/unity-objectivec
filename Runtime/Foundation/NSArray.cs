using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC.Foundation
{
    public unsafe struct NSArray : IId, IReadOnlyCollection<Id>
    {
        public static readonly Class Class = new Class("NSArray");

        [DllImport("__Internal")]
        public static extern long CFArrayGetCount(NSArray theArray);

        [DllImport("__Internal")]
        public static extern Id CFArrayGetValueAtIndex(NSArray theArray, long idx);

        private Id _self;

        public int Count => (int) CFArrayGetCount(this);
        public Id this[long index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return CFArrayGetValueAtIndex(this, index);
            }
        }

        public NSArray(Id self)
        {
            _self = self;
        }

        public static StrongReference<NSArray> Alloc(params Id[] objects)
        {
            fixed (Id* objectsPtr = objects)
            {
                return Class.Alloc<StrongReference<NSArray>>("initWithObjects:count:", (IntPtr) objectsPtr, (ulong) objects.Length);
            }
        }

        public static AutoreleasedReference<NSArray> ArrayWith(NSArray array)
        {
            return Class.Call<AutoreleasedReference<NSArray>>("arrayWithArray:", array);
        }
        public static AutoreleasedReference<NSArray> ArrayWith(params Id[] objects)
        {
            fixed (Id* objectsPtr = objects)
            {
                return Class.Call<AutoreleasedReference<NSArray>>("arrayWithObjects:count:", (IntPtr) objectsPtr, (ulong) objects.Length);
            }
        }

        public Id AsId => _self;

        public IEnumerator<Id> GetEnumerator()
        {
            return new NSEnumeratorIEnumerator(_self.Call<NSEnumerator>("objectEnumerator"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return _self.ToString();
        }

        public static explicit operator NSArray(Id obj)
        {
            return new NSArray(obj);
        }
        public static implicit operator Id(NSArray arr)
        {
            return arr._self;
        }
    }
}
