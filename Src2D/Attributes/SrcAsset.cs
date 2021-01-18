using Microsoft.Xna.Framework.Graphics;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Src2D.Attributes
{
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
    }
}
