using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Src2D.Editor
{
    partial class Launcher : Form
    {
        private Button NewButton;
        private Button OpenButton;

        private ListBox RecentFilesList;

        void InitializeComponent()
        {
            Title = "Project Launcher";
            MinimumSize = new Size(1, 1);
            Resizable = false;
            Padding = 10;

            Content = new StackLayout()
            {
                Orientation = Orientation.Horizontal,
                Items =
                {
                    new GroupBox()
                    {
                        Text = "Recent projects:",
                        Font = new Font(SystemFont.Label, 15),
                        Content = new ListBox()
                        {
                            Size = new Size(400, 500),
                            Font = new Font(SystemFont.Label, 15)
                        }.Export(out RecentFilesList)
                    },
                    new Panel()
                    {
                        Size = new Size(10, 0)
                    },
                    new StackLayout()
                    {
                        Items =
                        {
                            new Panel()
                            {
                                Size = new Size(0, 30)
                            },
                            new Button()
                            {
                                Text = "New",
                                Font = new Font(SystemFont.Label, 20),
                                MinimumSize = new Size(200, 60),
                            }.Export(out NewButton),
                            new Panel()
                            {
                                Size = new Size(0, 5)
                            },
                            new Button()
                            {
                                Text = "Open",
                                Font = new Font(SystemFont.Label, 20),
                                MinimumSize = new Size(200, 60)
                            }.Export(out OpenButton)
                        }
                    }
                }
            };
        }
    }
}
