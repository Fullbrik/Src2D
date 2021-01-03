using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Data
{
    public struct Map
    {
         public MapEntity[] Entities;
    }

    public struct MapEntity
    {
        public string EntityType;

        public Dictionary<string, object> Properties;

        public MapBinding[] Bindings;
    }

    public struct MapBinding
    {
        public string Event;
        public string EntityName;
        public string ActionName;
        public bool OverrideParam;
        public string ParamOverride;
    }
}
