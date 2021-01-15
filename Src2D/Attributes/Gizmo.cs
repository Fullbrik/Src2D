using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class GizmoAttribute : Attribute
    {
        public GizmoAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
