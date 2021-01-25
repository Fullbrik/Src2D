using System;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor.ContentManager
{
    partial class ContentManager : Panel
    {
        private TreeGridView Tree;
        private TreeGridItem TreeRoot;

        private ListBox FilesList;

        void InitializeComponent()
        {
            Padding = 0;

            Content = new Splitter()
            {
                Panel1 = new TreeGridView()
                {
                    ShowHeader = false,
                    AllowMultipleSelection = false,
                    Size = new Size(200, 500),
                    Columns =
                    {
                        new GridColumn()
                        {
                            DataCell = new ImageTextCell(0, 1),
                            AutoSize = true
                        }
                    },
                    DataStore = new TreeGridItem()
                    {
                    }.Export(out TreeRoot)
                }.Export(out Tree),
                Panel2 = new ListBox()
                {
                    Size = new Size(400, 500),
                }.Export(out FilesList)
            };

        }
    }
}
