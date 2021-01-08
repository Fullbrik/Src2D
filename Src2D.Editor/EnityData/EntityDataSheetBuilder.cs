using Src2D.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Src2D.Editor.EnityData
{
    public class EntityDataSheetBuilder
    {
        public static EntityDataSheet FromAssemblies(params Assembly[] assemblies)
        {
            var builder = new EntityDataSheetBuilder();

            for (int i = 0; i < assemblies.Length; i++)
            {
                builder.AddFromAssembly(assemblies[i]);
            }

            return builder.Build();
        }

        private EntityDataSheet dataSheet;

        EntityDataSheetBuilder()
        {
            dataSheet = new EntityDataSheet();
            dataSheet.Entities = new Dictionary<string, DataSheetEntity>();
        }

        public void AddFromAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();
            AddFromTypes(types);
        }

        public void AddFromTypes(Type[] types)
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
            retVal.Gizmos = srcEnt.Gizmos.Split('|');
            retVal.Sprite = srcEnt.Sprite;

            retVal.Properties = GetPropertiesFromType(type);
            retVal.Assets = GetAssetsFromType(type);
            retVal.Actions = GetActionsFromType(type);
            retVal.Events = GetEventsFromType(type);

            return retVal;
        }

        private Dictionary<string, DataSheetProperty> GetPropertiesFromType(Type type)
        {
            Dictionary<string, DataSheetProperty> retVal = new Dictionary<string, DataSheetProperty>();

            var props = type.GetProperties();
            foreach (var prop in props)
            {
                if (Attribute.IsDefined(prop, typeof(SrcPropertyAttribute)))
                {
                    var srcProp = (SrcPropertyAttribute)Attribute.GetCustomAttribute(prop, typeof(SrcPropertyAttribute));

                    DataSheetProperty property = new DataSheetProperty();

                    string name = srcProp.Name;

                    property.Description = srcProp.Description;
                    property.PropertyType = SrcPropertyAttribute.GetSrcPropertyTypeFor(prop);
                    property.DefaultValue = srcProp.DefaultValue?? SrcPropertyAttribute.GetDefaultValueFor(property.PropertyType);

                    retVal.Add(name, property);
                }
            }

            return retVal;
        }

        private Dictionary<string, DataSheetAsset> GetAssetsFromType(Type type)
        {
            Dictionary<string, DataSheetAsset> retVal = new Dictionary<string, DataSheetAsset>();

            var fields = type.GetFields();
            foreach (var field in fields)
            {
                if (Attribute.IsDefined(field, typeof(SrcAssetAttribute)))
                {
                    var srcAsset = (SrcAssetAttribute)Attribute.GetCustomAttribute(field, typeof(SrcAssetAttribute));

                    DataSheetAsset asset = new DataSheetAsset();

                    string name = srcAsset.Name;

                    asset.Description = srcAsset.Description;
                    asset.AssetType = SrcAssetAttribute.GetSrcAssetTypeFor(field);

                    retVal.Add(name, asset);
                }
            }

            return retVal;
        }

        private Dictionary<string, DataSheetEvent> GetActionsFromType(Type type)
        {
            Dictionary<string, DataSheetEvent> retVal = new Dictionary<string, DataSheetEvent>();

            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                if (Attribute.IsDefined(method, typeof(SrcActionAttribute)))
                {
                    var srcAct = (SrcActionAttribute)Attribute.GetCustomAttribute(method, typeof(SrcActionAttribute));

                    DataSheetEvent action = new DataSheetEvent();

                    string name = srcAct.Name;
                    action.Description = srcAct.Description;
                    action.ExportsParam = srcAct.HasParam;
                    action.ParamType = srcAct.ParamType;
                    action.ParamOptions = srcAct.ParamOptions.Split('|');

                    retVal.Add(name, action);
                }
            }

            return retVal;
        }

        private Dictionary<string, DataSheetEvent> GetEventsFromType(Type type)
        {
            Dictionary<string, DataSheetEvent> retVal = new Dictionary<string, DataSheetEvent>();

            var events = type.GetEvents();
            foreach (var evnt in events)
            {
                if (Attribute.IsDefined(evnt, typeof(SrcEventAttribute)))
                {
                    var srcEvnt = (SrcEventAttribute)Attribute.GetCustomAttribute(evnt, typeof(SrcEventAttribute));

                    DataSheetEvent ds_evnt = new DataSheetEvent();

                    string name = srcEvnt.Name;
                    ds_evnt.Description = srcEvnt.Description;
                    ds_evnt.ExportsParam = srcEvnt.ExportsParam;
                    ds_evnt.ParamType = srcEvnt.ParamType;
                    ds_evnt.ParamOptions = srcEvnt.ParamOptions.Split('|');

                    retVal.Add(name, ds_evnt);
                }
            }

            return retVal;
        }

        public EntityDataSheet Build()
        {
            return dataSheet;
        }
    }
}
