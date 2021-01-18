using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class SrcSchemaAttribute : Attribute
    {
        public SrcSchemaAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
