using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Src2D.Editor
{
    /// <summary>
    /// Note: This class exists as a workaround to the eto.forms designer not liking using System.Runtime.Loader or AssemblyLoadContext.
    /// </summary>
    public abstract class DynamicAssemblyManager
    {
        private Assembly projectAssembly;

        internal void LoadFromConfig(string configName)
        {
            var config = ProjectManager.GameInfo.BuildConfigurations.First(conf => conf.Name == configName);

            var dll = Path.Combine(ProjectManager.ProjectDirectory, config.DLL);


            projectAssembly = LoadAssemblyFromPath(dll);

            AssemblyManager.LoadAssembly(projectAssembly);
        }

        internal void Unload()
        {
            AssemblyManager.UnloadAssembly(projectAssembly);
            UnloadAssembly(projectAssembly);
            projectAssembly = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        protected abstract Assembly LoadAssemblyFromPath(string dllPath);
        protected abstract void UnloadAssembly(Assembly assembly);
    }
}
