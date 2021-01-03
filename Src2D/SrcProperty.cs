using Microsoft.Xna.Framework;
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
    }
}
