using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace Src2D.Content
{
    [ContentTypeWriter]
    public class SrcMapWriter : ContentTypeWriter<Map>
    {
        protected override void Write(ContentWriter output, Map value)
        {
            output.Write(value.Entities.Length);
            for (int i = 0; i < value.Entities.Length; i++)
            {
                var entity = value.Entities[i];

                output.Write(entity.EntityType);

                var propKeys = entity.Properties.Keys.ToList();
                output.Write(entity.Properties.Count);
                for (int j = 0; j < entity.Properties.Count; j++)
                {
                    output.Write(propKeys[j]);
                    output.Write(JsonConvert.SerializeObject(entity.Properties[propKeys[j]]));
                }

                output.Write(entity.Bindings.Length);
                for (int j = 0; j < entity.Bindings.Length; j++)
                {
                    output.Write(entity.Bindings[j].Event);
                    output.Write(entity.Bindings[j].EntityName);
                    output.Write(entity.Bindings[j].ActionName);
                    output.Write(entity.Bindings[j].OverrideParam);
                    output.Write(entity.Bindings[j].ParamOverride);
                }
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(SrcMapReader).AssemblyQualifiedName;
        }
    }
}
