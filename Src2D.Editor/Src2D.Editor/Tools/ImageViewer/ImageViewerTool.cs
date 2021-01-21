using System;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor.Tools.ImageViewer
{
    [Tool("Image Viewer", Ext = ".png")]
    [Tool("Image Viewer", Ext = ".jpeg")]
    [Tool("Image Viewer", Ext = ".jpg")]
    [Tool("Image Viewer", Ext = ".bmp")]
    public partial class ImageViewerTool : Form
    {
        public string File { get; }

        public ImageViewerTool(string file)
        {
            InitializeComponent();
            File = file;

            Load += ImageViewerTool_Load;
        }

        private void ImageViewerTool_Load(object sender, EventArgs e)
        {
            Img.Image = new Bitmap(File);
        }
    }
}
