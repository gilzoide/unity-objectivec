using System;

namespace Gilzoide.ObjectiveC
{
    public interface IId
    {
        Id AsId { get; }
    }

    public static class IIdExtensions
    {
        // Notice that this call boxes `obj`
        public static T Get<T>(this IId obj, string propertyName)
            where T : struct
        {
            return obj.AsId.Get<T>(propertyName);
        }
        public static T Get<TSelf, T>(this TSelf obj, string propertyName)
            where TSelf : IId
            where T : struct
        {
            return obj.AsId.Get<T>(propertyName);
        }

        public static void Set<TSelf, T>(this TSelf obj, string propertyName, T value)
            where TSelf : IId
            where T : struct
        {
            obj.AsId.Set(propertyName, value);
        }

        // Notice that this call boxes `obj`
        public static T Call<T>(this IId obj, Selector selector)
            where T : struct
        {
            return obj.AsId.Call<T>(selector);
        }
        // Notice that this call boxes `obj`
        public static T Call<T>(this IId obj, Selector selector, params ValueType[] args)
            where T : struct
        {
            return obj.AsId.Call<T>(selector, args);
        }

        public static void Call<TSelf>(this TSelf obj, Selector selector)
            where TSelf : IId
        {
            obj.AsId.Call(selector);
        }
        public static T Call<TSelf, T>(this TSelf obj, Selector selector)
            where TSelf : IId
            where T : struct
        {
            return obj.AsId.Call<T>(selector);
        }
        public static void Call<TSelf>(this TSelf obj, Selector selector, params ValueType[] args)
            where TSelf : IId
        {
            obj.AsId.Call(selector, args);
        }
        public static T Call<TSelf, T>(this TSelf obj, Selector selector, params ValueType[] args)
            where TSelf : IId
            where T : struct
        {
            return obj.AsId.Call<T>(selector, args);
        }

        public static bool RespondsToSelector<TSelf>(this TSelf obj, Selector selector)
            where TSelf : IId
        {
            return obj.AsId.RespondsToSelector(selector);
        }

        public static StrongReference Retain<TSelf>(this TSelf obj)
            where TSelf : IId
        {
            return obj.AsId.Retain();
        }
        public static void Release<TSelf>(this TSelf obj)
            where TSelf : IId
        {
            obj.AsId.Release();
        }
        public static AutoreleasedReference Autorelease<TSelf>(this TSelf obj)
            where TSelf : IId
        {
            return obj.AsId.Autorelease();
        }
        public static AutoreleasedReference RetainAutorelease<TSelf>(this TSelf obj)
            where TSelf : IId
        {
            return obj.AsId.RetainAutorelease();
        }

        public static string ToString<TSelf>(this TSelf obj)
            where TSelf : IId
        {
            return obj.AsId.ToString();
        }
    }
}