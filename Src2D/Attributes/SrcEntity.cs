using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class SrcEntityAttribute : Attribute
    {
        private readonly string name;

        public SrcEntityAttribute(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }
        public string Description { get; set; } = "";
        public string Sprite { get; set; } = "";

        public string Gizmos { get; set; } = "";
    }
}
