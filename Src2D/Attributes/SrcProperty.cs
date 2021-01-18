using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Newtonsoft.Json.Linq;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Src2D.Attributes
{
    

    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class SrcPropertyAttribute : Attribute
    {
        readonly string name;


        public SrcPropertyAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public string Description { get; set; } = "";
        public object DefaultValue { get; set; }
    }
}
