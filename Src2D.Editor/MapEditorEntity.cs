using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using Src2D.Data;
using Src2D.Editor.EnityData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor
{
    public class MapEditorEntity
    {
        public DataSheetEntity Data { get; }

        public string EntityType { get; }

        public string Name { get; set; } = null;
        public event Action<string> OnNameChanged;

        public Vector2 Position { get; set; } = Vector2.Zero;
        public float Rotation { get; set; } = 0;
        public Vector2 Scale { get; set; } = Vector2.One;
        public Vector2 Origin { get; set; } = new Vector2(.5f, .5f);

        public Texture2D SpritePreveiw { get; } = null;

        public Dictionary<string, MapPreviewEntityProperty> OtherProperties
            = new Dictionary<string, MapPreviewEntityProperty>();

        public Dictionary<string, MapPreviewAsset> Assets
            = new Dictionary<string, MapPreviewAsset>();

        public List<MapPreviewBinding> Bindings =
            new List<MapPreviewBinding>();

        private MapEditorPreveiw preveiw;

        public MapEditorEntity(MapEditorPreveiw preveiw, MapEntity entity, ContentManager content)
        {
            this.preveiw = preveiw;

            EntityType = entity.EntityType;

            Data = EntityDataSheetManager.CurrentSheet.Entities[entity.EntityType];

            PopulateProperties(entity.Properties);
            PopulateAssets(entity.Assets);
            PopulateBindings(entity.Bindings);

            if (!string.IsNullOrWhiteSpace(Data.Sprite))
            {
                try
                {
                    SpritePreveiw = content.Load<Texture2D>(Data.Sprite);
                }
                catch (Exception)
                {
#if DEBUG
                    throw;
#endif
                }
            }
        }

        private void PopulateProperties(Dictionary<string, object> properties)
        {
            foreach (var prop in Data.Properties)
            {
                bool doDefault = true;

                switch (prop.Key)
                {
                    case "Name":
                        if (prop.Value.PropertyType == SrcPropertType.String
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Name = (string)properties[prop.Key];
                        }
                        break;
                    case "Position":
                        if (prop.Value.PropertyType == SrcPropertType.Vector2
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Position = (Vector2)properties[prop.Key];
                        }
                        break;
                    case "Rotation":
                        if (prop.Value.PropertyType == SrcPropertType.Float
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Rotation = (float)properties[prop.Key];
                        }
                        break;
                    case "Scale":
                        if (prop.Value.PropertyType == SrcPropertType.Vector2
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Scale = (Vector2)properties[prop.Key];
                        }
                        break;
                    case "Origin":
                        if (prop.Value.PropertyType == SrcPropertType.Vector2
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Origin = (Vector2)properties[prop.Key];
                        }
                        break;
                    default:
                        break;
                }

                if (doDefault)
                {
                    object value = prop.Value.DefaultValue;

                    if (properties.ContainsKey(prop.Key))
                        value = properties[prop.Key];

                    if (value is JObject jObject)
                        value = SrcPropertyAttribute
                            .PropertyFromJObject(jObject, prop.Value.PropertyType);
                    else if (value is string str)
                        value = SrcPropertyAttribute
                            .PropertyFromString(str, prop.Value.PropertyType);

                    OtherProperties.Add(prop.Key,
                        new MapPreviewEntityProperty(
                            prop.Value.PropertyType,
                            prop.Value.Description,
                            value));
                }
            }
        }

        private void PopulateAssets(Dictionary<string, string> assets)
        {
            foreach (var asset in Data.Assets)
            {
                string assetName = "";
                if (assets.ContainsKey(asset.Key))
                {
                    assetName = assets[asset.Key];
                }

                Assets.Add(asset.Key, new MapPreviewAsset(asset.Value.AssetType, asset.Value.Description, assetName));
            }
        }

        private void PopulateBindings(MapBinding[] bindings)
        {
            foreach (var binding in bindings)
            {
                Bindings.Add(
                    new MapPreviewBinding(
                        binding.Event,
                        binding.EntityName,
                        binding.ActionName,
                        binding.OverrideParam,
                        binding.ParamOverride));
            }
        }

        public object GetProperty(string name)
        {
            switch (name)
            {
                case "Name":
                    return Name;
                case "Position":
                    return Position;
                case "Rotation":
                    return Rotation;
                case "Scale":
                    return Scale;
                case "Origin":
                    return Origin;
                default:
                    object value = OtherProperties[name].Value;
                    if (value is long l) value = (int)l;
                    return value;
            }
        }

        public void SetProperty(string name, object value)
        {
            var old = GetProperty(name);

            preveiw.DoAction(() =>
            {
                switch (name)
                {
                    case "Name":
                        Name = (string)value;
                        OnNameChanged?.Invoke(Name);
                        break;
                    case "Position":
                        Position = (Vector2)value;
                        break;
                    case "Rotation":
                        Rotation = (float)value;
                        break;
                    case "Scale":
                        Scale = (Vector2)value;
                        break;
                    case "Origin":
                        Origin = (Vector2)value;
                        break;
                    default:
                        OtherProperties[name].Value = value;
                        break;
                }
            },
            () =>
            {
                switch (name)
                {
                    case "Name":
                        Name = (string)old;
                        OnNameChanged?.Invoke(Name);
                        break;
                    case "Position":
                        Position = (Vector2)old;
                        break;
                    case "Rotation":
                        Rotation = (float)old;
                        break;
                    case "Scale":
                        Scale = (Vector2)old;
                        break;
                    case "Origin":
                        Origin = (Vector2)old;
                        break;
                    default:
                        OtherProperties[name].Value = old;
                        break;
                }
            });
        }

        public string GetAsset(string name)
        {
            return Assets[name].AssetName;
        }

        public void SetAsset(string name, string assetName)
        {
            var old = GetAsset(name);

            preveiw.DoAction(
                () => Assets[name].AssetName = assetName,
                () => Assets[name].AssetName = old);
        }
    }

    public class MapPreviewEntityProperty
    {
        public SrcPropertType PropertType { get; }
        public string Description { get; }
        public object Value { get; set; }

        public MapPreviewEntityProperty(SrcPropertType propertType, string description, object value)
        {
            PropertType = propertType;
            Description = description;
            Value = value;
        }
    }

    public class MapPreviewAsset
    {
        public SrcAssetType AssetType { get; }
        public string Description { get; }
        public string AssetName { get; set; }

        public MapPreviewAsset(SrcAssetType assetType, string description, string assetName)
        {
            AssetType = assetType;
            Description = description;
            AssetName = assetName;
        }
    }

    public class MapPreviewBinding
    {
        public string EventName { get; set; }
        public string OtherEntityName { get; set; }
        public string ActionName { get; set; }
        public bool OverrideParam { get; set; }
        public string ParamOverride { get; set; }

        public MapPreviewBinding(string eventName, string otherEntityName, string actionName, bool overideParam, string paramOveride)
        {
            EventName = eventName;
            OtherEntityName = otherEntityName;
            ActionName = actionName;
            OverrideParam = overideParam;
            ParamOverride = paramOveride;
        }
    }
}
