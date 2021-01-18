using Src2D.Attributes;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    public abstract class SrcSchema
    {
        public void PopulateFromDictionary(Dictionary<string, object> dictionary)
        {
            var type = GetType();
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                if (Attribute.IsDefined(prop, typeof(SrcPropertyAttribute)))
                {
                    var srcProp
                        = (SrcPropertyAttribute)Attribute
                            .GetCustomAttribute(prop, typeof(SrcPropertyAttribute));

                    if (dictionary.ContainsKey(srcProp.Name))
                    {
                        var value = dictionary[srcProp.Name];

                        value = PropertyData.FixValue(value,
                            PropertyData.GetSrcPropertyTypeFor(prop));

                        if (prop.PropertyType.IsSubclassOf(typeof(SrcSchema)))
                        {
                            prop.PropertyType
                                .GetMethod("PopulateFromDictionary")
                                .Invoke(this, new object[] { value });
                        }
                        else
                        {
                            prop.SetValue(this, value);
                        }
                    }
                }
            }
        }
    }
}
