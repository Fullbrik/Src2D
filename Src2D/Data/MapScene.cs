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

                    foreach (var asset in entData.Assets)
                    {
                        ent.SetAsset(asset.Key, asset.Value);
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
                    //var thems = Entities.Where(ent => ent.Name == binding.EntityName);

                    entity.CreateBinding(
                            binding.Event, 
                            binding.EntityName, 
                            binding.ActionName, 
                            binding.OverrideParam, 
                            binding.ParamOverride);
                }
            }
        }
    }
}
