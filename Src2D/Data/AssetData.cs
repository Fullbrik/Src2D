using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Src2D.Data
{
    public enum SrcAssetType
    {
        None = -1,
        Texture2D,
        Map
    }

    public struct AssetData
    {
        public SrcAssetType AssetType;
        public string Description;

        public static SrcAssetType GetSrcAssetTypeFor(FieldInfo property)
        {
            return GetSrcAssetTypeFor(property.FieldType);
        }

        public static SrcAssetType GetSrcAssetTypeFor(Type type)
        {
            if (type == typeof(Asset<Texture2D>))
                return SrcAssetType.Texture2D;
            else return SrcAssetType.None;
        }

        public static SrcAssetType GetSrcAssetTypeFor(string ext)
        {
            if (ext.StartsWith(".")) ext = ext.Remove(0, 1);

            switch (ext)
            {
                case "jpeg":
                case "jpg":
                case "png":
                case "tga":
                    return SrcAssetType.Texture2D;
                case "srcmap":
                    return SrcAssetType.Map;
                default:
                    return SrcAssetType.None;
            }
        }
    }
}
