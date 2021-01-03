using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Src2D.Data
{
    public sealed class MapScene : Scene
    {
        private Map map;

        private List<(string id, MapBinding[] binding)> bindings = new List<(string id, MapBinding[] binding)>();

        public MapScene(Map map)
        {
            this.map = map;
        }

        public override void CreateEnities()
        {
            foreach (var entData in map.Entities)
            {
                var entity = AssemblyManager.CreateEntity(entData.EntityType);

                if(entity == null) continue;

                Entities.Add(entity, (ent) =>
                {
                    foreach (var prop in entData.Properties)
                    {
                        ent.SetProperty(prop.Key, prop.Value);
                    }
                });

                bindings.Add((entity.ID, entData.Bindings));
            }
        }

        public override void BindEntityEvents()
        {
            foreach (var entBindings in bindings)
            {
                var entity = Entities[entBindings.id];

                foreach (var binding in entBindings.binding)
                {
                    var thems = Entities.Where(ent => ent.Name == binding.EntityName);

                    foreach (var them in thems)
                    {
                        them.Bind(binding.ActionName, entity, binding.Event, binding.OverrideParam, binding.ParamOverride);
                    }
                }
            }
        }
    }
}
