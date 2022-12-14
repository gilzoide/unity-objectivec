using System;

namespace Gilzoide.ObjectiveC
{
    public struct StrongReference : IId, IDisposable
    {
        public Id Target;

        public StrongReference(Id value)
        {
            Target = value;
        }

        public Id AsId => Target;

        public void Dispose()
        {
            Target.Release();
            Target = Id.Nil;
        }

        public override string ToString()
        {
            return Target.ToString();
        }

        public static explicit operator StrongReference(Id obj)
        {
            return new StrongReference(obj);
        }
        public static implicit operator Id(StrongReference strongReference)
        {
            return strongReference.Target;
        }
    }

    public struct StrongReference<T> : IId, IDisposable
        where T : struct, IId
    {
        public T Target;

        public StrongReference(T value)
        {
            Target = value;
        }

        public Id AsId => Target.AsId;

        public void Dispose()
        {
            AsId.Release();
            Target = default;
        }

        public override string ToString()
        {
            return Target.ToString();
        }

        public static explicit operator StrongReference<T>(T value)
        {
            return new StrongReference<T>(value);
        }
        public static implicit operator T(StrongReference<T> strongReference)
        {
            return strongReference.Target;
        }
        public static implicit operator Id(StrongReference<T> strongReference)
        {
            return strongReference.AsId;
        }
        public static implicit operator StrongReference(StrongReference<T> strongReference)
        {
            return new StrongReference(strongReference.AsId);
        }
    }
}
