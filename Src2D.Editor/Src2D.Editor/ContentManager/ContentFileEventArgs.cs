using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.ContentManager
{
    public class ContentFileEventArgs : EventArgs
    {
        public string FileName { get; }
        public bool IsDirectory { get; }

        public ContentFileEventArgs(string filename, bool isDirectory)
        {
            FileName = filename;
            IsDirectory = isDirectory;
        }
    }
}
