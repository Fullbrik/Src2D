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
    }
}
