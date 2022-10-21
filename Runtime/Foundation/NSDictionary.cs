using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Gilzoide.ObjectiveC.Foundation
{
    public unsafe struct NSDictionary : IId, IReadOnlyDictionary<Id, Id>
    {
        public static Class Class = new Class("NSDictionary");

        [DllImport("__Internal")]
        public static extern long CFDictionaryGetCount(NSDictionary theDict);

        private Id _self;

        public NSDictionary(Id self)
        {
            _self = self;
        }

        public static StrongReference<NSDictionary> Alloc(NSDictionary dictionary)
        {
            return Class.Alloc<StrongReference<NSDictionary>>("initWithDictionary:", dictionary);
        }
        public static StrongReference<NSDictionary> Alloc(Id obj, Id key)
        {
            return Class.Alloc<StrongReference<NSDictionary>>("initWithObject:forKey:", obj, key);
        }
        public static StrongReference<NSDictionary> Alloc(params Id[] objectsAndKeys)
        {
            SplitObjectsAndKeys(objectsAndKeys, out Id[] objects, out Id[] keys);
            return Alloc(objects, keys);
        }
        public static StrongReference<NSDictionary> Alloc(Id[] objects, Id[] keys)
        {
            int count = Mathf.Min(objects.Length, keys.Length);
            fixed (Id* objectsPtr = objects)
            fixed (Id* keysPtr = keys)
            {
                return Class.Alloc<StrongReference<NSDictionary>>("initWithObjects:forKeys:count:", (IntPtr) objectsPtr, (IntPtr) keysPtr, (ulong) count);
            }
        }

        public static AutoreleasedReference<NSDictionary> DictionaryWith(NSDictionary dictionary)
        {
            return Class.Call<AutoreleasedReference<NSDictionary>>("dictionaryWithDictionary:", dictionary);
        }
        public static AutoreleasedReference<NSDictionary> DictionaryWith(Id obj, Id key)
        {
            return Class.Call<AutoreleasedReference<NSDictionary>>("dictionaryWithObject:forKey:", obj, key);
        }
        public static AutoreleasedReference<NSDictionary> DictionaryWith(params Id[] objectsAndKeys)
        {
            SplitObjectsAndKeys(objectsAndKeys, out Id[] objects, out Id[] keys);
            return DictionaryWith(objects, keys);
        }
        public static AutoreleasedReference<NSDictionary> DictionaryWith(Id[] objects, Id[] keys)
        {
            int count = Mathf.Min(objects.Length, keys.Length);
            fixed (Id* objectsPtr = objects)
            fixed (Id* keysPtr = keys)
            {
                return Class.Call<AutoreleasedReference<NSDictionary>>("dictionaryWithObjects:forKeys:count:", (IntPtr) objectsPtr, (IntPtr) keysPtr, (ulong) count);
            }
        }

        public Id AsId => _self;

        public IEnumerable<Id> Keys => new NSEnumeratorIEnumerable(_self, "keyEnumerator");

        public IEnumerable<Id> Values => new NSEnumeratorIEnumerable(_self, "objectEnumerator");

        public int Count => (int) CFDictionaryGetCount(this);

        public Id this[Id key] => _self.Call<Id>("objectForKey:", key);

        public override string ToString()
        {
            return _self.ToString();
        }

        public static explicit operator NSDictionary(Id obj)
        {
            return new NSDictionary(obj);
        }
        public static implicit operator Id(NSDictionary dict)
        {
            return dict._self;
        }

        private static void SplitObjectsAndKeys(Id[] objectsAndKeys, out Id[] objects, out Id[] keys)
        {
            int count = objectsAndKeys.Length / 2;
            objects = new Id[count];
            keys = new Id[count];
            for (int i = 0; i < count; i++)
            {
                objects[i] = objectsAndKeys[i * 2];
                keys[i] = objectsAndKeys[(i * 2) + 1];
            }
        }

        public bool ContainsKey(Id key)
        {
            return !this[key].IsNil;
        }

        public bool TryGetValue(Id key, out Id value)
        {
            value = this[key];
            return !value.IsNil;
        }

        public IEnumerator<KeyValuePair<Id, Id>> GetEnumerator()
        {
            foreach (Id key in Keys)
            {
                yield return new KeyValuePair<Id, Id>(key, this[key]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
