using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using Src2D.Attributes;
using Src2D.Data;
using Src2D.Editor.EnityData;
using Src2D.Shapes;
using System;
using System.Collections.Generic;

namespace Src2D.Editor.Previews.MapEditor
{
    public class MapEditorEntity : IPropertyEditable
    {
        public DataSheetEntity Data { get; }

        public string EntityType { get; }

        public string Name { get; set; } = null;
        public event Action<string> OnNameChanged;

        public Vector2 Position { get; set; } = Vector2.Zero;
        public float Rotation { get; set; } = 0;
        public Vector2 Scale { get; set; } = Vector2.One;
        public Vector2 Origin { get; set; } = new Vector2(.5f, .5f);

        public Texture2D SpritePreview { get => spritePreview; }
        private Texture2D spritePreview;

        public Vector2 SpriteSize => new Vector2(SpritePreview.Width, SpritePreview.Height);
        public Vector2 SpriteOrgin => Origin * SpriteSize;

        //public Rectangle Bounds => new Rectangle(
        //    (int)(Position.X - SpriteOrgin.X), (int)(Position.Y - SpriteOrgin.Y),
        //    (int)(Scale.X * SpritePreview.Width), (int)(Scale.Y * SpritePreview.Height));

        public Dictionary<string, MapPreviewEntityProperty> OtherProperties
            = new Dictionary<string, MapPreviewEntityProperty>();

        public Dictionary<string, MapPreviewAsset> Assets
            = new Dictionary<string, MapPreviewAsset>();

        public List<MapPreviewBinding> Bindings =
            new List<MapPreviewBinding>();

        public MapEditorPreview Preview { get => preveiw; }
        private MapEditorPreview preveiw;

        public MapEditorEntity(MapEditorPreview preveiw, MapEntity entity, ContentManager content)
        {
            this.preveiw = preveiw;

            EntityType = entity.EntityType;

            Data = EntityDataSheetManager.CurrentSheet.Entities[entity.EntityType];

            PopulateProperties(entity.Properties);
            PopulateAssets(entity.Assets);
            PopulateBindings(entity.Bindings);

            ReloadAssets(content);
        }

        private void PopulateProperties(Dictionary<string, object> properties)
        {
            foreach (var prop in Data.Properties)
            {
                bool doDefault = true;

                object value = prop.Value.DefaultValue;

                if (properties.ContainsKey(prop.Key))
                    value = properties[prop.Key];

                value = PropertyData.FixValue(value, prop.Value.PropertyType);

                switch (prop.Key)
                {
                    case "Name":
                        if (prop.Value.PropertyType == SrcPropertyType.String
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Name = (string)value;
                        }
                        break;
                    case "Position":
                        if (prop.Value.PropertyType == SrcPropertyType.Vector2
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Position = (Vector2)value;
                        }
                        break;
                    case "Rotation":
                        if (prop.Value.PropertyType == SrcPropertyType.Float
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Rotation = (float)Convert.ToDouble(value);
                        }
                        break;
                    case "Scale":
                        if (prop.Value.PropertyType == SrcPropertyType.Vector2
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Scale = (Vector2)value;
                        }
                        break;
                    case "Origin":
                        if (prop.Value.PropertyType == SrcPropertyType.Vector2
                            && properties.ContainsKey(prop.Key))
                        {
                            doDefault = false;
                            Origin = (Vector2)value;
                        }
                        break;
                    default:
                        break;
                }

                if (doDefault)
                {
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

        public Dictionary<string, PropertyData> GetAllProperties()
        {
            return Data.Properties;
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
                    if (OtherProperties.ContainsKey(name))
                    {
                        object value = OtherProperties[name].Value;
                        if (value is long l) value = (int)l;
                        return value;
                    }
                    else
                    {
                        return null;
                    }
            }
        }

        public void SetProperty(string name, object value)
        {
            SetProperty(name, value, false);
        }

        public void SetProperty(string name, object value, bool doAsAction)
        {
            var old = GetProperty(name);

            Action action = () =>
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

            };

            if (doAsAction)
            {
                preveiw.DoAction(action,
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
            else
            {
                action();
            }
        }

        public string GetAsset(string name)
        {
            if (Assets.ContainsKey(name))
                return Assets[name].AssetName;
            else
                return null;
        }

        public void SetAsset(string name, string assetName)
        {
            var old = GetAsset(name);

            preveiw.DoAction(
                () => Assets[name].AssetName = assetName,
                () => Assets[name].AssetName = old);
        }

        public void ReloadAssets(ContentManager content)
        {
            if (!string.IsNullOrWhiteSpace(Data.Sprite))
            {
                try
                {
                    spritePreview = content.Load<Texture2D>(Data.Sprite);
                }
                catch (Exception)
                {
                    throw new Exception($"Could not find sprite {Data.Sprite} in content.");
                }
            }
        }

        public bool IsInside(Vector2 point)
        {
            //var trans = Matrix.CreateTranslation(Position.X, Position.Y, 0);
            var rot = Matrix.CreateRotationZ(MathHelper.ToRadians(Rotation));
            var scal = Matrix.CreateScale(Scale.X, Scale.Y, 1);

            var recPos = new Vector2(-SpriteOrgin.X, -SpriteOrgin.Y);
            recPos = Vector2.Transform(recPos, scal);
            recPos += Position;

            RectangleF baseRect =
                new RectangleF(recPos.X, recPos.Y,
                spritePreview.Width * Scale.X, spritePreview.Height * Scale.Y);

            point -= Position;
            point = Vector2.Transform(point, Matrix.Invert(rot));
            point += Position;

            return baseRect.Contains(point);
        }

        public MapEntity ToMapEntity()
        {
            MapEntity me = new MapEntity();
            me.EntityType = EntityType;

            me.Properties = new Dictionary<string, object>();
            foreach (var prop in Data.Properties)
            {
                var value = GetProperty(prop.Key);
                if (value != null && value != prop.Value.DefaultValue)
                    me.Properties.Add(prop.Key, value);
            }

            me.Assets = new Dictionary<string, string>();
            foreach (var asset in Data.Assets)
            {
                var assetValue = GetAsset(asset.Key);
                if (!string.IsNullOrWhiteSpace(assetValue))
                    me.Assets.Add(asset.Key, assetValue);
            }

            me.Bindings = new MapBinding[Bindings.Count];
            for (int i = 0; i < Bindings.Count; i++)
            {
                me.Bindings[i] = new MapBinding()
                {
                    Event = Bindings[i].EventName,
                    EntityName = Bindings[i].OtherEntityName,
                    ActionName = Bindings[i].ActionName,
                    OverrideParam = Bindings[i].OverrideParam,
                    ParamOverride = Bindings[i].ParamOverride
                };
            }

            return me;
        }
    }

    public class MapPreviewEntityProperty
    {
        public SrcPropertyType PropertType { get; }
        public string Description { get; }
        public object Value { get; set; }

        public MapPreviewEntityProperty(SrcPropertyType propertType, string description, object value)
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
