using System;
using Src2D.Editor.ContentManager;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor
{
    partial class ProjectView : Form
    {
        ContentManager.ContentManager ContentBrowser;

        void InitializeComponent()
        {
            Title = "Project - ProjectName";
            MinimumSize = new Size(200, 200);
            Padding = 5;

            Content = new ContentManager.ContentManager()
                .Export(out ContentBrowser);
        }
    }
}
