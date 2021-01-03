using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Content
{
    [ContentImporter(".srcmap", DisplayName = "Src Map Importer", DefaultProcessor = "SrcMapProcessor")]
    public class SrcMapImporter : ContentImporter<string>
    {
        public override string Import(string filename, ContentImporterContext context)
        {
            return System.IO.File.ReadAllText(filename);
        }
    }
}
