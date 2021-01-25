using System;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor.Tools.MapEditor
{
    partial class MapEditor : Form
    {
        private TreeGridItem EntityTreeRoot;
        private ContentManager.ContentManager ContentBrowser;

        void InitializeComponent()
        {
            Title = "Map Editor - Untitled*";
            MinimumSize = new Size(200, 200);
            Padding = 10;

            Content = new Splitter()
            {
                Orientation = Orientation.Horizontal,
                Panel1 = new Splitter()
                {
                    Orientation = Orientation.Vertical,
                    Panel1 = new TreeGridView()
                    {
                        ShowHeader = false,
                        AllowMultipleSelection = false,
                        Columns =
                        {
                            new GridColumn()
                            {
                                DataCell = new ImageTextCell(1, 0),
                                AutoSize = true
                            }
                        },
                        DataStore = new TreeGridItem()
                        {
                        }.Export(out EntityTreeRoot)
                    },
                    Panel2 = new PropertyGrid()
                    {

                    }
                },
                Panel2 = new Splitter()
                {
                    Orientation = Orientation.Vertical,
                    Panel1 = new Panel()
                    {
                        Size = new Size(-1, 300)
                    },
                    Panel2 = new ContentManager.ContentManager()
                    {
                        Size = new Size(-1, 100)
                    }.Export(out ContentBrowser)
                }
            };
        }
    }
}
