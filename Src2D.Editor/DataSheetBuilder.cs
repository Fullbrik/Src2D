using Src2D.Attributes;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Src2D.Editor
{
    public abstract class DataSheetBuilder<TBuilder, TStruct>
        where TBuilder : DataSheetBuilder<TBuilder, TStruct>, new()
        where TStruct : struct
    {
        public static TStruct FromAssemblies(params Assembly[] assemblies)
        {
            var builder = new TBuilder();

            for (int i = 0; i < assemblies.Length; i++)
            {
                builder.AddFromAssembly(assemblies[i]);
            }

            return builder.Build();
        }

        public void AddFromAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();
            AddFromTypes(types);
        }

        public abstract void AddFromTypes(Type[] types);
        public abstract TStruct Build();

        protected Dictionary<string, PropertyData> GetPropertiesFromType(Type type)
        {
            Dictionary<string, PropertyData> retVal = new Dictionary<string, PropertyData>();

            var props = type.GetProperties();
            foreach (var prop in props)
            {
                if (Attribute.IsDefined(prop, typeof(SrcPropertyAttribute)))
                {
                    var srcProp = (SrcPropertyAttribute)Attribute.GetCustomAttribute(prop, typeof(SrcPropertyAttribute));

                    PropertyData property = new PropertyData();

                    string name = srcProp.Name;

                    property.Description = srcProp.Description;
                    property.PropertyType = PropertyData.GetSrcPropertyTypeFor(prop);

                    if (property.PropertyType == SrcPropertyType.Misc)
                    {
                        if (Attribute.IsDefined(prop.PropertyType, typeof(SrcSchemaAttribute)))
                        {
                            var srcSchema 
                                = (SrcSchemaAttribute)Attribute
                                .GetCustomAttribute(
                                    prop.PropertyType, 
                                    typeof(SrcSchemaAttribute));

                            property.SchemaType = srcSchema.Name;

                        }
                    }
                    else if (property.PropertyType == SrcPropertyType.List)
                    {
                        var pt = prop.PropertyType;

                        if(pt.IsGenericType && pt.GenericTypeArguments.Length > 0
                            && Attribute.IsDefined(pt.GenericTypeArguments[0], typeof(SrcSchemaAttribute)))
                        {
                            var srcSchema 
                                = (SrcSchemaAttribute)Attribute
                                .GetCustomAttribute(
                                    pt.GenericTypeArguments[0], 
                                    typeof(SrcSchemaAttribute));

                            property.SchemaType = srcSchema.Name;
                        }
                    }

                    property.DefaultValue = srcProp.DefaultValue ?? PropertyData.GetDefaultValueFor(property.PropertyType);

                    retVal.Add(name, property);
                }
            }
            return retVal;
        }

        protected Dictionary<string, AssetData> GetAssetsFromType(Type type)
        {
            Dictionary<string, AssetData> retVal = new Dictionary<string, AssetData>();

            var fields = type.GetFields();
            foreach (var field in fields)
            {
                if (Attribute.IsDefined(field, typeof(SrcAssetAttribute)))
                {
                    var srcAsset = (SrcAssetAttribute)Attribute.GetCustomAttribute(field, typeof(SrcAssetAttribute));

                    AssetData asset = new AssetData();

                    string name = srcAsset.Name;

                    asset.Description = srcAsset.Description;
                    asset.AssetType = AssetData.GetSrcAssetTypeFor(field);

                    retVal.Add(name, asset);
                }
            }

            return retVal;
        }

        protected Dictionary<string, EventData> GetActionsFromType(Type type)
        {
            Dictionary<string, EventData> retVal = new Dictionary<string, EventData>();

            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                if (Attribute.IsDefined(method, typeof(SrcActionAttribute)))
                {
                    var srcAct = (SrcActionAttribute)Attribute.GetCustomAttribute(method, typeof(SrcActionAttribute));

                    EventData action = new EventData();

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

        protected Dictionary<string, EventData> GetEventsFromType(Type type)
        {
            Dictionary<string, EventData> retVal = new Dictionary<string, EventData>();

            var events = type.GetEvents();
            foreach (var evnt in events)
            {
                if (Attribute.IsDefined(evnt, typeof(SrcEventAttribute)))
                {
                    var srcEvnt = (SrcEventAttribute)Attribute.GetCustomAttribute(evnt, typeof(SrcEventAttribute));

                    EventData ds_evnt = new EventData();

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
    }
}
