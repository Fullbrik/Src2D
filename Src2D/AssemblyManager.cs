using Src2D.Attributes;
using Src2D.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Src2D
{
    public static class AssemblyManager
    {
        public static readonly Dictionary<string, Type> Entities = new Dictionary<string, Type>();

        public static BaseEntity CreateEntity(string name)
        {
            if(!Entities.ContainsKey(name)) return null;
            if(Entities[name].TryExecuteEmptyConstructor(out object obj)
                && obj is BaseEntity entity)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public static void LoadAssembly(Assembly assembly)
        {
            GetEntities(assembly);
        }

        private static void GetEntities(Assembly assembly)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if((type.IsSubclassOf(typeof(BaseEntity)) || type == typeof(BaseEntity)) && Attribute.IsDefined(type, typeof(SrcEntityAttribute)))
                {
                    var srcEntity = (SrcEntityAttribute)Attribute.GetCustomAttribute(type, typeof(SrcEntityAttribute));
                    Entities.Add(srcEntity.Name, type);
                }
            }
        }
    }
}
