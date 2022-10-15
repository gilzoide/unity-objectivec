using System;

namespace Gilzoide.ObjectiveC
{
    public struct AutoreleasedReference<T> : IConvertibleToId
        where T : struct, IConvertibleToId
    {
        public T Target;

        public AutoreleasedReference(T value)
        {
            Target = value;
        }

        public void Release()
        {
            throw new InvalidOperationException("Cannot release an autoreleased object");
        }

        public Id ToId()
        {
            return Target.ToId();
        }

        public static implicit operator T(AutoreleasedReference<T> autoreleasedObject)
        {
            return autoreleasedObject.Target;
        }
        public static implicit operator Id(AutoreleasedReference<T> autoreleasedObject)
        {
            return autoreleasedObject.ToId();
        }
    }
}
