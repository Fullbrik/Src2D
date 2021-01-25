using System;
using System.Reflection;
using System.Runtime.Loader;

namespace Src2D.Editor.CoreHacks
{
    public class CoreHackDynamicAssemblyManager : DynamicAssemblyManager
    {
        private AssemblyLoadContext projectLoadContext;

        protected override Assembly LoadAssemblyFromPath(string dllPath)
        {
            projectLoadContext = new AssemblyLoadContext(null, true);
            return projectLoadContext.LoadFromAssemblyPath(dllPath);
        }

        protected override void UnloadAssembly(Assembly assembly)
        {
            projectLoadContext.Unload();
            projectLoadContext = null;
        }
    }
}
