using Src2D.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.SchemaData
{
    public class SchemaDataSheetBuilder
        : DataSheetBuilder<SchemaDataSheetBuilder, SchemaDataSheet>
    {
        SchemaDataSheet dataSheet;

        public SchemaDataSheetBuilder()
        {
            dataSheet = new SchemaDataSheet();
            dataSheet.Schemas = new Dictionary<string, DataSheetSchema>();
        }

        public override void AddFromTypes(Type[] types)
        {
            foreach (var type in types)
            {
                if (Attribute.IsDefined(type, typeof(SrcSchemaAttribute)))
                {
                    var srcSchema = (SrcSchemaAttribute)Attribute.GetCustomAttribute(type, typeof(SrcSchemaAttribute));
                    var props = GetPropertiesFromType(type);

                    dataSheet.Schemas.Add(srcSchema.Name, new DataSheetSchema()
                    {
                        Properties = props
                    });
                }
            }
        }

        public override SchemaDataSheet Build()
        {
            return dataSheet;
        }
    }
}
