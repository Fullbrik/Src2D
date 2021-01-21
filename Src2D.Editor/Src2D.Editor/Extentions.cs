using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor
{
    public static class Extentions
    {
        public static T Export<T>(this T inRef, out T outRef)
        {
            outRef = inRef;
            return inRef;
        }
    }
}
