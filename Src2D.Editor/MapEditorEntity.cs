using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        public MapEditorEntity(MapEntity entity, ContentManager content)
        {
            EntityType = entity.EntityType;
            Data = EntityDataSheetManager.CurrentSheet.Entities[entity.EntityType];
            PopulateProperties(entity.Properties);
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
                    object value = properties.ContainsKey(prop.Key) ?
                        properties[prop.Key] : default;

                    OtherProperties.Add(prop.Key,
                        new MapPreviewEntityProperty(
                            prop.Value.PropertyType,
                            prop.Value.Description,
                            value));
                }
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
                    return OtherProperties[name].Value;
            }
        }

        public void SetProperty(string name, object value)
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
}
