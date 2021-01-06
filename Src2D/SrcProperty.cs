using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Src2D
{
    public enum SrcPropertType
    {
        None,
        String,
        Int,
        Float,
        Bool,
        Vector2,
        Vector3,
        Color,
        EntityReferance,
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class SrcPropertyAttribute : Attribute
    {
        readonly string name;

        // This is a positional argument
        public SrcPropertyAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public string Description { get; set; } = "";
        public object DefaultValue { get; set; }

        public static SrcPropertType GetSrcPropertyTypeFor(PropertyInfo property)
        {
            return GetSrcPropertyTypeFor(property.PropertyType);
        }

        public static SrcPropertType GetSrcPropertyTypeFor(Type type)
        {
            if (type == typeof(string))
                return SrcPropertType.String;
            else if (type == typeof(int))
                return SrcPropertType.Int;
            else if (type == typeof(float))
                return SrcPropertType.Float;
            else if (type == typeof(bool))
                return SrcPropertType.Bool;
            else if (type == typeof(Vector2))
                return SrcPropertType.Vector2;
            else if (type == typeof(Vector3))
                return SrcPropertType.Vector3;
            else if (type == typeof(Color))
                return SrcPropertType.Color;
            else if(type == typeof(EntityReference))
                return SrcPropertType.EntityReferance;
            else return SrcPropertType.None;
        }

        public static object GetDefaultValueFor(SrcPropertType propertyType)
        {
            switch (propertyType)
            {
                case SrcPropertType.None:
                    return null;
                case SrcPropertType.String:
                    return "";
                case SrcPropertType.Int:
                    return 0;
                case SrcPropertType.Float:
                    return 0;
                case SrcPropertType.Bool:
                    return false;
                case SrcPropertType.Vector2:
                    return Vector2.Zero;
                case SrcPropertType.Vector3:
                    return Vector3.Zero;
                case SrcPropertType.Color:
                    return Color.White;
                case SrcPropertType.EntityReferance:
                    return new EntityReference("");
                default:
                    return null;
            }
        }

        public static object PropertyFromString(string str, SrcPropertType propertyType)
        {
            switch (propertyType)
            {
                case SrcPropertType.String:
                    return str;
                case SrcPropertType.None:
                    return str;
                case SrcPropertType.Int:
                    return int.Parse(str);
                case SrcPropertType.Float:
                    return float.Parse(str);
                case SrcPropertType.Bool:
                    return bool.Parse(str);
                case SrcPropertType.Vector2:
                    return new Vector2TypeConverter().ConvertFrom(str);
                case SrcPropertType.Vector3:
                    return new Vector3TypeConverter().ConvertFrom(str);
                case SrcPropertType.Color:
                    throw new NotImplementedException();
                case SrcPropertType.EntityReferance:
                    return new EntityReference(str);
                default:
                    return str;
            }
        }

        public static object PropertyFromJObject(JObject jObject, SrcPropertType propertyType)
        {
            switch (propertyType)
            {
                case SrcPropertType.String:
                    throw new NotImplementedException();
                case SrcPropertType.None:
                    throw new NotImplementedException();
                case SrcPropertType.Int:
                    throw new NotImplementedException();
                case SrcPropertType.Float:
                    throw new NotImplementedException();
                case SrcPropertType.Bool:
                    throw new NotImplementedException();
                case SrcPropertType.Vector2:
                    return new Vector2(jObject["X"].ToObject<float>(), jObject["Y"].ToObject<float>());
                case SrcPropertType.Vector3:
                    return new Vector3(jObject["X"].ToObject<float>(), jObject["Y"].ToObject<float>(), jObject["Z"].ToObject<float>());
                case SrcPropertType.Color:
                    return new Color(jObject["R"].ToObject<float>(), jObject["G"].ToObject<float>(), jObject["B"].ToObject<float>(), jObject["A"].ToObject<float>());
                case SrcPropertType.EntityReferance:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
