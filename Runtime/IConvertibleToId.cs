using System;

namespace Gilzoide.ObjectiveC
{
    public interface IConvertibleToId
    {
        Id ToId();
    }

    public static class IConvertibleToIdExtensions
    {
        // Notice that this call boxes `obj`
        public static T Call<T>(this IConvertibleToId obj, Selector selector)
            where T : struct
        {
            return obj.ToId().Call<T>(selector);
        }
        // Notice that this call boxes `obj`
        public static T Call<T>(this IConvertibleToId obj, Selector selector, params ValueType[] args)
            where T : struct
        {
            return obj.ToId().Call<T>(selector, args);
        }

        public static void Call<TSelf>(this TSelf obj, Selector selector)
            where TSelf : IConvertibleToId
        {
            obj.ToId().Call(selector);
        }
        public static T Call<TSelf, T>(this TSelf obj, Selector selector)
            where TSelf : IConvertibleToId
            where T : struct
        {
            return obj.ToId().Call<T>(selector);
        }
        public static void Call<TSelf>(this TSelf obj, Selector selector, params ValueType[] args)
            where TSelf : IConvertibleToId
        {
            obj.ToId().Call(selector, args);
        }
        public static T Call<TSelf, T>(this TSelf obj, Selector selector, params ValueType[] args)
            where TSelf : IConvertibleToId
            where T : struct
        {
            return obj.ToId().Call<T>(selector, args);
        }

        public static bool RespondsToSelector<TSelf>(this TSelf obj, Selector selector)
            where TSelf : IConvertibleToId
        {
            return obj.ToId().RespondsToSelector(selector);
        }

        public static StrongReference<Id> Retain<TSelf>(this TSelf obj)
            where TSelf : IConvertibleToId
        {
            return obj.ToId().Retain();
        }
        public static void Release<TSelf>(this TSelf obj)
            where TSelf : IConvertibleToId
        {
            obj.ToId().Release();
        }
        public static AutoreleasedReference<Id> Autorelease<TSelf>(this TSelf obj)
            where TSelf : IConvertibleToId
        {
            return obj.ToId().Autorelease();
        }
        public static AutoreleasedReference<Id> RetainAutorelease<TSelf>(this TSelf obj)
            where TSelf : IConvertibleToId
        {
            return obj.ToId().RetainAutorelease();
        }

        public static string ToString<TSelf>(this TSelf obj)
            where TSelf : IConvertibleToId
        {
            return obj.ToId().ToString();
        }
    }
}