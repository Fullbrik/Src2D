using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.Content
{
    public class ContentItemSelectEventArgs : EventArgs
    {
        public ContentItem Item { get; set; }

        public ContentItemSelectEventArgs(ContentItem item)
        {
            Item = item;
        }
    }
}
