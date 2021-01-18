using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.SchemaData
{
    public class SchemaEditable : IPropertyEditable
    {
        Dictionary<string, PropertyData> allProperties;
        Dictionary<string, object> properties;

        public SchemaEditable(string schema, Dictionary<string, object> properties)
        {
            allProperties
                = SchemaDataSheetManager.CurrentSheet.Schemas[schema].Properties;
            this.properties = properties;
        }

        public Dictionary<string, PropertyData> GetAllProperties()
        {
            return allProperties;
        }

        public object GetProperty(string name)
        {
            if (properties.ContainsKey(name))
            {
                var prop = allProperties[name];
                var propVal =  properties[name];
                return PropertyData.FixValue(propVal, prop.PropertyType);
            }
            else
            {
                var prop = allProperties[name];
                return PropertyData.FixValue(prop.DefaultValue, prop.PropertyType);
            }
        }

        public void SetProperty(string name, object value)
        {
            properties[name] = value;
        }
    }
}
