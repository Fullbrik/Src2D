using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Src2D
{
    public static class Extensions
    {
        public static bool TryExecuteEmptyConstructor(this Type type, out object result)
        {
            var cons = type.GetConstructor(Array.Empty<Type>());

            if (cons != null)
            {
                result = cons.Invoke(Array.Empty<object>());
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public static bool TryExecuteConstructor(this Type type, out object result,
            params object[] args)
        {
            var cons = type.GetConstructor(
                args.Select(obj => obj.GetType()).ToArray());

            if (cons != null)
            {
                result = cons.Invoke(args);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<TValue> source, IEnumerable<TKey> keys)
        {
            Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

            for (int i = 0; i < source.Count(); i++)
            {
                if (i < keys.Count())
                {
                    dictionary.Add(keys.ElementAt(i), source.ElementAt(i));
                }
            }

            return dictionary;
        }

        public static int MaxX(this Point[] points)
        {
            int cuurrentMax = int.MinValue;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].X > cuurrentMax)
                    cuurrentMax = points[i].X;
            }
            return cuurrentMax;
        }

        public static int MaxY(this Point[] points)
        {
            int cuurrentMax = int.MinValue;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].Y > cuurrentMax)
                    cuurrentMax = points[i].Y;
            }
            return cuurrentMax;
        }

        public static int MinX(this Point[] points)
        {
            int cuurrentMin = int.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].X < cuurrentMin)
                    cuurrentMin = points[i].X;
            }
            return cuurrentMin;
        }

        public static int MinY(this Point[] points)
        {
            int cuurrentMin = int.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].Y < cuurrentMin)
                    cuurrentMin = points[i].Y;
            }
            return cuurrentMin;
        }

        public static IEnumerable<T> SelectDynamic<T>(this Array array, Func<dynamic, T> selector)
        {
            foreach (var item in array)
            {
                yield return selector(item);
            }
        }

        public static Vector2 Rotate(this Vector2 vector, float rotationInRadians)
        {
            var x = vector.X;
            var y = vector.Y;
            var rot = rotationInRadians;

            return new Vector2(
                (float)(x * Math.Cos(rot) - y * Math.Sin(rot)),
                (float)(x * Math.Sin(rot) + y * Math.Cos(rot)));
        }
    }
}
