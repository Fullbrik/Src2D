using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Src2D
{
    [TypeConverter(typeof(EntityReferenceTypeConverter))]
    public class EntityReference
    {
        public string Query { get; }
        public List<BaseEntity> Entities { get => entities; }
        private List<BaseEntity> entities;

        public EntityReference(string query)
        {
            Query = query;
        }

        public void Setup(Scene scene)
        {
            if (!string.IsNullOrWhiteSpace(Query))
            {
                if (!scene.EntityQuerys.ContainsKey(Query))
                    scene.EntityQuerys.Add(Query, new List<BaseEntity>());

                entities = scene.EntityQuerys[Query];
            }
        }

        public void Do(Action<BaseEntity> action)
        {
            Entities.ForEach(action);
        }

        public static implicit operator string(EntityReference asset) => asset.Query;
        public static implicit operator EntityReference(string query) => new EntityReference(query);
    }

    public class EntityReferenceTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string str)
                return new EntityReference(str);

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is EntityReference entityReference)
            {
                if (destinationType == typeof(string))
                    return entityReference.Query;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
