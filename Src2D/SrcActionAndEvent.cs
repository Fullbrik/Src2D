using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    public enum EventParamType
    {
        String,
        Int,
        Float,
        Bool,
    }

    public delegate void SrcEvent(string input);

    [AttributeUsage(AttributeTargets.Event, Inherited = true, AllowMultiple = false)]
    public sealed class SrcEventAttribute : Attribute
    {
        private readonly string name;
        public SrcEventAttribute(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }
        public bool ExportsParam { get; set; } = true;
        public EventParamType ParamType { get; set; } = EventParamType.String;
        public string ParamOptions { get; set; } = "";
        public string Description { get; set; } = "";
    }


    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class SrcActionAttribute : Attribute
    {
        private readonly string name;

        public SrcActionAttribute(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }
        public bool HasParam { get; set; } = true;
        public EventParamType ParamType { get; set; } = EventParamType.String;
        public string ParamOptions { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
