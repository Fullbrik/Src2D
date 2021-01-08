using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Src2D.Attributes;

namespace Src2D.Editor
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class ToolAttribute : Attribute
    {
        public ToolAttribute(string name, SrcAssetType assetType)
        {
            Name = name;
            AssetType = assetType;
        }

        public string Name { get; }
        public SrcAssetType AssetType { get; }

        public static (Type type, ToolAttribute ta)[] Get(SrcAssetType assetType)
        {
            return Get()
                .Where(tool => tool.ta.AssetType == assetType)
                .ToArray();
        }

        public static (Type type, ToolAttribute ta)[] Get()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Select(assm => assm.GetTypes()
                    .Where(type => IsDefined(type, typeof(ToolAttribute))))
                .Flatten()
                .Select(type => (type, (ToolAttribute)GetCustomAttribute(type, typeof(ToolAttribute))))
                .ToArray();
        }
    }
}
