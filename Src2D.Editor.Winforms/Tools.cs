using Src2D.Editor.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src2D.Editor.Winforms
{
    public static class Tools
    {
        public static void Open(string file, ContentFile content)
        {
            string ext = Path.GetExtension(file);

            switch (ext)
            {
                case ".srcmap":
                    new MapEditor(file, content).Show();
                    break;
                default:
                    break;
            }
        }
    }
}
