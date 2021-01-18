using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Src2D.Data
{
    public enum SrcPropertyType
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
        List,
        Misc,
    }

    public struct PropertyData
    {
        public SrcPropertyType PropertyType;
        public string SchemaType;
        public string Description;
        public object DefaultValue;

        public static SrcPropertyType GetSrcPropertyTypeFor(PropertyInfo property)
        {
            return GetSrcPropertyTypeFor(property.PropertyType);
        }

        public static SrcPropertyType GetSrcPropertyTypeFor(Type type)
        {
            if (type == typeof(string))
                return SrcPropertyType.String;
            else if (type == typeof(int))
                return SrcPropertyType.Int;
            else if (type == typeof(float))
                return SrcPropertyType.Float;
            else if (type == typeof(bool))
                return SrcPropertyType.Bool;
            else if (type == typeof(Vector2))
                return SrcPropertyType.Vector2;
            else if (type == typeof(Vector3))
                return SrcPropertyType.Vector3;
            else if (type == typeof(Color))
                return SrcPropertyType.Color;
            else if (type == typeof(EntityReference))
                return SrcPropertyType.EntityReferance;
            else if(type.IsSubclassOf(typeof(SrcSchema)))
                return SrcPropertyType.Misc;
            else if(type.IsSubclassOf(typeof(InternalSrcListBaseClass)))
                return SrcPropertyType.List;
            else return SrcPropertyType.None;
        }

        public static object GetDefaultValueFor(SrcPropertyType propertyType)
        {
            switch (propertyType)
            {
                case SrcPropertyType.None:
                    return null;
                case SrcPropertyType.String:
                    return "";
                case SrcPropertyType.Int:
                    return 0;
                case SrcPropertyType.Float:
                    return 0;
                case SrcPropertyType.Bool:
                    return false;
                case SrcPropertyType.Vector2:
                    return Vector2.Zero;
                case SrcPropertyType.Vector3:
                    return Vector3.Zero;
                case SrcPropertyType.Color:
                    return Color.White;
                case SrcPropertyType.EntityReferance:
                    return new EntityReference("");
                case SrcPropertyType.Misc:
                    return new Dictionary<string, object>();
                case SrcPropertyType.List:
                    return Array.Empty<SrcSchema>();
                default:
                    return null;
            }
        }

        public static object PropertyFromString(string str, SrcPropertyType propertyType)
        {
            switch (propertyType)
            {
                case SrcPropertyType.String:
                    return str;
                case SrcPropertyType.None:
                    return str;
                case SrcPropertyType.Int:
                    return int.Parse(str);
                case SrcPropertyType.Float:
                    return float.Parse(str);
                case SrcPropertyType.Bool:
                    return bool.Parse(str);
                case SrcPropertyType.Vector2:
                    return new Vector2TypeConverter().ConvertFrom(str);
                case SrcPropertyType.Vector3:
                    return new Vector3TypeConverter().ConvertFrom(str);
                case SrcPropertyType.Color:
                    throw new NotImplementedException();
                case SrcPropertyType.EntityReferance:
                    return new EntityReference(str);
                case SrcPropertyType.Misc:
                    return new NotImplementedException();
                case SrcPropertyType.List:
                    throw new NotImplementedException();
                default:
                    return str;
            }
        }

        public static object PropertyFromJObject(JObject jObject, 
            SrcPropertyType propertyType)
        {
            switch (propertyType)
            {
                case SrcPropertyType.String:
                    throw new NotImplementedException();
                case SrcPropertyType.None:
                    throw new NotImplementedException();
                case SrcPropertyType.Int:
                    throw new NotImplementedException();
                case SrcPropertyType.Float:
                    throw new NotImplementedException();
                case SrcPropertyType.Bool:
                    throw new NotImplementedException();
                case SrcPropertyType.Vector2:
                    return new Vector2(jObject["X"].ToObject<float>(), jObject["Y"].ToObject<float>());
                case SrcPropertyType.Vector3:
                    return new Vector3(jObject["X"].ToObject<float>(), jObject["Y"].ToObject<float>(), jObject["Z"].ToObject<float>());
                case SrcPropertyType.Color:
                    return new Color(jObject["R"].ToObject<float>(), jObject["G"].ToObject<float>(), jObject["B"].ToObject<float>(), jObject["A"].ToObject<float>());
                case SrcPropertyType.EntityReferance:
                    throw new NotImplementedException();
                case SrcPropertyType.Misc:
                    return jObject.ToObject<Dictionary<string, object>>();
                    case SrcPropertyType.List:
                        return jObject.ToObject<JArray>().ToList();
                default:
                    throw new NotImplementedException();
            }
        }

        public static object FixValue(object value, SrcPropertyType propertyType)
        {
            if (value is JObject jObject)
                value = PropertyFromJObject(jObject, propertyType);
            else if (value is string str)
                value = PropertyFromString(str, propertyType);

            if (propertyType == SrcPropertyType.Int && value is long l)
                return (int)l;
            else if (propertyType == SrcPropertyType.Float && value is long ll)
                return (float)ll;
            else if (propertyType == SrcPropertyType.Float && value is double d)
                return (float)d;
            else if (propertyType == SrcPropertyType.Float && value is int i)
                return (float)i;

            return value;
        }
    }
}
