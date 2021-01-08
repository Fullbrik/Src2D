using Src2D.Editor.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms.Tools
{
    [Tool("Image Viewer", SrcAssetType.Texture2D)]
    public partial class ImageViewer : Form
    {
        string imageFile;
        ContentFile content;

        public ImageViewer(string imageFile, ContentFile content)
        {
            InitializeComponent();
            this.imageFile = imageFile;
            this.content = content;
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            PictureBox.Image = Image.FromFile(
                Path.Combine(content.ContentFolder, imageFile));
        }
    }
}
