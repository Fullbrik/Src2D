using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Src2D.Editor.Tools
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class ToolAttribute : Attribute
    {
        internal struct Data
        {
            public ToolAttribute Attr { get; set; }
            public Type Type { get; set; }

            public Data(ToolAttribute attr, Type type)
            {
                Attr = attr;
                Type = type;
            }
        }

        public string Name { get; }
        public string Ext { get; set; }

        public ToolAttribute(string name)
        {
            Name = name;
        }

        internal static IEnumerable<Data> GetAllTools()
        {
            return from Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
                   where !assembly.FullName.ToLower().Contains("wpf")
                   from type in assembly.GetTypes()
                   where IsDefined(type, typeof(ToolAttribute))
                   from ToolAttribute tool in GetCustomAttributes(type, typeof(ToolAttribute))
                   select new Data(tool, type);
        }

        internal static IEnumerable<Data> GetAllToolsForExtention(string ext)
        {
            if (!ext.StartsWith(".")) ext = "." + ext;

            return GetAllTools()
                .Where(tool =>
                {
                    var toolExt = tool.Attr.Ext.StartsWith(".") ? tool.Attr.Ext : "." + tool.Attr.Ext;
                    return ext == toolExt;
                });
        }
    }
}
