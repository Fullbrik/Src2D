using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Src2D
{
    public enum SrcAssetType
    {
        None = -1,
        Texture2D
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class SrcAssetAttribute : Attribute
    {
        readonly string name;
        public SrcAssetAttribute(string name, SrcAssetType assetType)
        {
            this.name = name;
            AssetType = assetType;
        }

        public string Name
        {
            get { return name; }
        }

        public SrcAssetType AssetType { get; }

        public string Description { get; set; } = "";

        public static SrcAssetType GetSrcAssetTypeFor(FieldInfo property)
        {
            return GetSrcAssetTypeFor(property.FieldType);
        }

        public static SrcAssetType GetSrcAssetTypeFor(Type type)
        {
            if(type == typeof(Asset<Texture2D>))
                return SrcAssetType.Texture2D;
            else return SrcAssetType.None;
        }
    }
}
