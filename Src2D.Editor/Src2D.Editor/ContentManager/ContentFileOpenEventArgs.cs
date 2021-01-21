using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.ContentManager
{
    public class ContentFileOpenEventArgs : EventArgs
    {
        public string FileName { get; }

        public ContentFileOpenEventArgs(string filename)
        {
            FileName = filename;
        }
    }
}
