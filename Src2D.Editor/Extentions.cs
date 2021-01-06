using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Src2D.Editor
{
    public static class Extentions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> ts)
        {
            List<T> flattened = new List<T>();

            foreach (var layer1 in ts)
            {
                flattened.AddRange(layer1.ToArray());
            }

            return flattened;
        }
    }
}
