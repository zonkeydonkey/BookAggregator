using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Books
{
    public delegate bool Predicate<T>(T t);

    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract))
                return typeof(TBase);

            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract))
                objectType = typeof(TBase);

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }

    public class NoImageFoundException : Exception
    {
        public NoImageFoundException()
        {
        }

        public NoImageFoundException(string message)
            : base(message)
        {
        }

        public NoImageFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NoNodeSelectedException : Exception
    {
        public NoNodeSelectedException()
        {
        }

        public NoNodeSelectedException(string message)
            : base(message)
        {
        }

        public NoNodeSelectedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NoSuchNodeFoundException : Exception
    {
        public NoSuchNodeFoundException()
        {
        }

        public NoSuchNodeFoundException(string message)
            : base(message)
        {
        }

        public NoSuchNodeFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public static class ListUtils
    {
        public static bool AnyOrNotNull<T>(this IEnumerable<T> source)
        {
            if (source != null && source.Any())
                return true;
            else
                return false;
        }

        public static int Find<T1, T2>(this IEnumerable<Tuple<T1, T2>> source, T1 compared) where T1 : IComparable
        {
            if(AnyOrNotNull<Tuple<T1, T2>>(source))
            {
                int i = 0;
                foreach (Tuple<T1, T2> tuple in source)
                {
                    if (compared.CompareTo(tuple.Item1) == 0)
                        return i;
                    ++i;
                }
            }
            return -1;
        }

        public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> original)
        {
            return original ?? new T[0];
        }

        public static void Copy<T>(this List<T> source, List<T> target)
        {
            ConditionalCopy<T>(source, target, delegate (T t) { return true; });
        }

        public static void ConditionalCopy<T>(this List<T> source, List<T> target, Predicate<T> p)
        {
            if (target == null)
                target = new List<T>();

            if (source != null)
            {
                foreach (T t in source)
                {
                    if(p(t))
                        target.Add(t);
                }
            }
        }
    }
}
