using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.SchemaData
{
    public struct SchemaDataSheet
    {
        public Dictionary<string, DataSheetSchema> Schemas;
    }

    public struct DataSheetSchema
    {
        public Dictionary<string, PropertyData> Properties;
    }
}
