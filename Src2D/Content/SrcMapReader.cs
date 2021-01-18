using Microsoft.Xna.Framework.Content;
using Newtonsoft.Json;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Content
{
    public class SrcMapReader : ContentTypeReader<Map>
    {
        protected override Map Read(ContentReader input, Map existingInstance)
        {
            Map map = new Map();

            int entityCount = input.ReadInt32();
            map.Entities = new MapEntity[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                var entity = new MapEntity();

                entity.EntityType = input.ReadString();
                entity.Properties = new Dictionary<string, object>();

                int propsCount = input.ReadInt32();
                for (int j = 0; j < propsCount; j++)
                {
                    string key = input.ReadString();
                    string value = input.ReadString();

                    entity.Properties.Add(key, JsonConvert.DeserializeObject(value));
                }

                entity.Assets = new Dictionary<string, string>();
                int assetCount = input.ReadInt32();
                for (int j = 0; j < assetCount; j++)
                {
                    string key = input.ReadString();
                    string value = input.ReadString();
                    entity.Assets.Add(key, value);
                }

                int bindingsCount = input.ReadInt32();
                entity.Bindings = new MapBinding[bindingsCount];
                for (int j = 0; j < bindingsCount; j++)
                {
                    entity.Bindings[j] = new MapBinding();

                    entity.Bindings[j].Event = input.ReadString();
                    entity.Bindings[j].EntityName = input.ReadString();
                    entity.Bindings[j].ActionName = input.ReadString();
                    entity.Bindings[j].OverrideParam = input.ReadBoolean();
                    entity.Bindings[j].ParamOverride = input.ReadString();
                }

                map.Entities[i] = entity;
            }

            return map;
        }
    }
}
