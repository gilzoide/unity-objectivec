using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC.Foundation
{
    public struct NSArray : IId, IReadOnlyCollection<Id>
    {
        public static readonly Class Class = new Class("NSArray");

        [DllImport("__Internal", EntryPoint = "objc_msgSend")]
        public static extern NSArray objc_msgSend_idp_ulong(Id obj, Selector selector, Id[] objectArray, ulong length);

        [DllImport("__Internal")]
        public static extern long CFArrayGetCount(NSArray theArray);

        [DllImport("__Internal")]
        public static extern Id CFArrayGetValueAtIndex(NSArray theArray, long idx);

        private Id _self;

        public int Count => (int) CFArrayGetCount(this);
        public Id this[long index] => index >= 0 && index < Count
            ? CFArrayGetValueAtIndex(this, (long) index)
            : throw new IndexOutOfRangeException();

        public NSArray(Id self)
        {
            _self = self;
        }

        public static StrongReference<NSArray> Alloc(params Id[] objects)
        {
            Id newArray = Runtime.objc_msgSend(Class, "alloc");
            return new StrongReference<NSArray>(objc_msgSend_idp_ulong(newArray, "initWithObjects:count:", objects, (ulong) objects.Length));
        }

        public static AutoreleasedReference<NSArray> ArrayWith(NSArray array)
        {
            return new AutoreleasedReference<NSArray>(new NSArray(Runtime.objc_msgSend(Class, "arrayWithArray:", array)));
        }
        public static AutoreleasedReference<NSArray> ArrayWith(params Id[] objects)
        {
            return new AutoreleasedReference<NSArray>(objc_msgSend_idp_ulong(Class, "arrayWithObjects:count:", objects, (ulong) objects.Length));
        }

        public Id AsId => _self;

        public IEnumerator<Id> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return _self.ToString();
        }

        public static implicit operator Id(NSArray arr)
        {
            return arr._self;
        }

        public class Enumerator : IEnumerator<Id>
        {
            private NSArray _array;
            private long _index;

            public Enumerator(NSArray array)
            {
                _array = array;
                _index = -1;
            }

            public Id Current => _array[_index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _index++;
                return _index < CFArrayGetCount(_array);
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
