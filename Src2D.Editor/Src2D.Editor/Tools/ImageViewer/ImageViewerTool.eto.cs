using System;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor.Tools.ImageViewer
{
    partial class ImageViewerTool : Form
    {
        private ImageView Img;

        void InitializeComponent()
        {
            Title = "Image viewer";

            Content = new ImageView()
            .Export(out Img);
        }
    }
}
