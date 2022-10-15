using System;

namespace Gilzoide.ObjectiveC
{
    public struct AutoreleasedReference : IConvertibleToId
    {
        public Id Target;

        public AutoreleasedReference(Id value)
        {
            Target = value;
        }

        public void Release()
        {
            throw new InvalidOperationException("Cannot release an autoreleased object");
        }

        public Id ToId()
        {
            return Target;
        }

        public override string ToString()
        {
            return Target.ToString();
        }
        
        public static implicit operator Id(AutoreleasedReference autoreleasedObject)
        {
            return autoreleasedObject.Target;
        }
    }

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

        public override string ToString()
        {
            return Target.ToString();
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
