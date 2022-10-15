using System;

namespace Gilzoide.ObjectiveC
{
    public struct StrongReference : IConvertibleToId, IDisposable
    {
        public Id Target;

        public StrongReference(Id value)
        {
            Target = value;
        }

        public Id ToId()
        {
            return Target;
        }

        public void Dispose()
        {
            Target.Release();
        }

        public static implicit operator Id(StrongReference strongReference)
        {
            return strongReference.Target;
        }
    }

    public struct StrongReference<T> : IConvertibleToId, IDisposable
        where T : struct, IConvertibleToId
    {
        public T Target;

        public StrongReference(T value)
        {
            Target = value;
        }

        public Id ToId()
        {
            return Target.ToId();
        }

        public void Dispose()
        {
            ToId().Release();
        }

        public static implicit operator T(StrongReference<T> strongReference)
        {
            return strongReference.Target;
        }
        public static implicit operator Id(StrongReference<T> strongReference)
        {
            return strongReference.ToId();
        }
    }
}
