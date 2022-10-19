using System;

namespace Gilzoide.ObjectiveC
{
    public struct AutoreleasedReference : IId
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

        public Id AsId => Target;

        public override string ToString()
        {
            return Target.ToString();
        }
        
        public static explicit operator AutoreleasedReference(Id obj)
        {
            return new AutoreleasedReference(obj);
        }
        public static implicit operator Id(AutoreleasedReference autoreleasedObject)
        {
            return autoreleasedObject.Target;
        }
    }

    public struct AutoreleasedReference<T> : IId
        where T : struct, IId
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

        public Id AsId => Target.AsId;

        public override string ToString()
        {
            return Target.ToString();
        }

        public static explicit operator AutoreleasedReference<T>(T value)
        {
            return new AutoreleasedReference<T>(value);
        }
        public static implicit operator T(AutoreleasedReference<T> autoreleasedObject)
        {
            return autoreleasedObject.Target;
        }
        public static implicit operator Id(AutoreleasedReference<T> autoreleasedObject)
        {
            return autoreleasedObject.AsId;
        }
        public static implicit operator AutoreleasedReference(AutoreleasedReference<T> autoreleasedObject)
        {
            return new AutoreleasedReference(autoreleasedObject.AsId);
        }
    }
}
