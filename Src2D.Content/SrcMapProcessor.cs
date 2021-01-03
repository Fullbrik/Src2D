using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using Src2D.Data;
using Newtonsoft.Json;

namespace Src2D.Content
{
    [ContentProcessor(DisplayName = "Src Map Processor")]
    public class SrcMapProcessor : ContentProcessor<string, Map>
    {
        public override Map Process(string input, ContentProcessorContext context)
        {
            return JsonConvert.DeserializeObject<Map>(input);
        }
    }
}
