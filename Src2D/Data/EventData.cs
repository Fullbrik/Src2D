using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Data
{
    public enum EventParamType
    {
        String,
        Int,
        Float,
        Bool,
    }

    public struct EventData
    {
        public bool ExportsParam;
        public EventParamType ParamType;
        public string[] ParamOptions;
        public string Description;
    }
}
