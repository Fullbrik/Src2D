using Src2D.Attributes;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Src2D.Editor.EnityData
{
    public struct EntityDataSheet
    {
        public Dictionary<string, DataSheetEntity> Entities;
    }

    public struct DataSheetEntity
    {
        public string Description;

        public string[] Gizmos;

        public string Sprite;

        public Dictionary<string, DataSheetProperty> Properties;
        public Dictionary<string, DataSheetAsset> Assets;
        public Dictionary<string, DataSheetEvent> Events;
        public Dictionary<string, DataSheetEvent> Actions;

        public MapEntity ToMapEntity(string entityType)
        {
            MapEntity entity = new MapEntity()
            {
                EntityType = entityType,
                Properties = Properties
                    .Select(kvp => kvp.Value.DefaultValue)
                    .ToDictionary(Properties.Keys),
                Assets = Assets
                    .Select((_) => "")
                    .ToDictionary(Assets.Keys),
                Bindings = Array.Empty<MapBinding>()
            };

            return entity;
        }
    }
}

public struct DataSheetProperty
{
    public SrcPropertyType PropertyType;
    public string Description;
    public object DefaultValue;
}

public struct DataSheetAsset
{
    public SrcAssetType AssetType;
    public string Description;
}

public struct DataSheetEvent
{
    public bool ExportsParam;
    public EventParamType ParamType;
    public string[] ParamOptions;
    public string Description;
}
