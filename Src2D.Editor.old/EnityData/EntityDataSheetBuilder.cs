using Src2D.Attributes;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Src2D.Editor.EnityData
{
    public class EntityDataSheetBuilder 
        : DataSheetBuilder<EntityDataSheetBuilder, EntityDataSheet>
    {
        private EntityDataSheet dataSheet;

        public EntityDataSheetBuilder()
        {
            dataSheet = new EntityDataSheet();
            dataSheet.Entities = new Dictionary<string, DataSheetEntity>();
        }

        public override void AddFromTypes(Type[] types)
        {
            foreach (var type in types)
            {
                if (Attribute.IsDefined(type, typeof(SrcEntityAttribute)))
                {
                    var ent = CreateEntityFromType(type, out string name);
                    dataSheet.Entities.Add(name, ent);
                }
            }
        }

        private DataSheetEntity CreateEntityFromType(Type type, out string name)
        {
            DataSheetEntity retVal = new DataSheetEntity();

            var srcEnt = (SrcEntityAttribute)Attribute.GetCustomAttribute(type, typeof(SrcEntityAttribute));

            name = srcEnt.Name;

            retVal.Description = srcEnt.Description;
            retVal.Gizmos = Attribute.GetCustomAttributes(type)
                .Where(attr => attr is GizmoAttribute)
                .Select(attr => (attr as GizmoAttribute).Name)
                .ToArray();
            retVal.Icon = srcEnt.Icon;
            retVal.UseEditorAsset = srcEnt.UseEditorAsset;
            retVal.SpriteAsset = srcEnt.SpriteAsset;

            retVal.Properties = GetPropertiesFromType(type);
            retVal.Assets = GetAssetsFromType(type);
            retVal.Actions = GetActionsFromType(type);
            retVal.Events = GetEventsFromType(type);

            return retVal;
        }

        public override EntityDataSheet Build()
        {
            return dataSheet;
        }
    }
}
