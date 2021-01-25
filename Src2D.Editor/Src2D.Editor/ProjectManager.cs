using Newtonsoft.Json;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
//using System.Runtime.Loader;
using System.Text;

namespace Src2D.Editor
{
    public static class ProjectManager
    {
        public static DynamicAssemblyManager DynamicAssemblyManager { get; set; }

        public static string ProjectFile { get => projectFile; }
        private static string projectFile;
        public static string ProjectDirectory { get => projectDirectory; }
        private static string projectDirectory;
        public static string ContentDirectory { get => contentDirectory; }
        private static string contentDirectory;

        public static GameInfo GameInfo { get => gameInfo; }
        private static GameInfo gameInfo;

        public static string[] Configurations { get => GameInfo.BuildConfigurations.Select(conf => conf.Name).ToArray(); }

        public static void LoadProject(string projFile)
        {
            projectFile = projFile;
            projectDirectory = Path.GetDirectoryName(projectFile);

            var text = File.ReadAllText(ProjectFile);
            gameInfo = JsonConvert.DeserializeObject<GameInfo>(text);

            contentDirectory = Path.Combine(ProjectDirectory, GameInfo.ContentFolder);
        }

        public static void LoadProjectAssembly(string configName)
        {
            DynamicAssemblyManager.LoadFromConfig(configName);
        }

        public static void UnloadProjectAssembly()
        {
            DynamicAssemblyManager.Unload();
        }
    }
}
