using Microsoft.Xna.Framework.Content;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    public static class Assets
    {
        internal static ContentManager ContentManager { get; set; }
    }

    public class Asset<T>
    {
        public string AssetName { get; set; }

        [JsonIgnore]
        public T Value { get => value; }
        private T value;

        public Asset()
        {
            AssetName = "";
        }

        public Asset(string assetName)
        {
            AssetName = assetName;
        }

        public void Precache()
        {
            if (!string.IsNullOrWhiteSpace(AssetName))
                value = Assets.ContentManager.Load<T>(AssetName);
        }

        public override string ToString()
        {
            return AssetName;
        }

        public void SetWithString(string str)
        {
            AssetName = str;
        }

        public static implicit operator string(Asset<T> asset) => asset.AssetName;
        public static implicit operator Asset<T>(string assetName) => new Asset<T>(assetName);
        public static implicit operator T(Asset<T> asset) => asset.Value;
    }
}
