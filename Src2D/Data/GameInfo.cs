using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Data
{
    public struct GameInfo
    {
        public string Name;
        public string ContentFolder;
        public string StartingMap;
        public string DataSheetDirectory;
        public BuildConfiguration[] BuildConfigurations;
    }

    public struct BuildConfiguration
    {
        public string Name;
        public string DLL;
    }
}
