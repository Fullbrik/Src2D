using System;
using Src2D.Editor.ContentManager;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor
{

    partial class ProjectView : Form
    {
        ContentManager.ContentManager ContentBrowser;

        private Command NewCommand;
        private Command ImportCommand;
        private Command DeleteCommand;
        private Command RefreshCommand;

        //private Command HotReloadCommand;

        void InitializeComponent()
        {
            Title = "Project - ProjectName";
            MinimumSize = new Size(200, 200);
            Padding = 5;

            NewCommand = new Command()
            {
                MenuText = "&New",
                ToolTip = "Create a new asset"
            };

            ImportCommand = new Command()
            {
                MenuText = "&Import",
                ToolTip = "Import an item from your computer, and copy it to the project directory"
            };

            DeleteCommand = new Command()
            {
                MenuText = "&Delete",
                ToolTip = "Delete currently selected folder or file",
                Shortcut = Keys.Delete
            };

            RefreshCommand = new Command()
            {
                MenuText = "&Refresh",
                ToolTip = "Refresh the content directory"
            };

            Content = new ContentManager.ContentManager()
            {
                FilesListContextMenu = new ContextMenu()
                {
                    Items =
                    {
                        ImportCommand,
                        NewCommand,
                        DeleteCommand,
                        RefreshCommand
                    }
                }
            }.Export(out ContentBrowser);


            Menu = new MenuBar()
            {
                Items =
                {
                    new ButtonMenuItem()
                    {
                        Text = "&File",
                        Items =
                        {
                            NewCommand,
                            ImportCommand,
                            DeleteCommand,
                            RefreshCommand
                        }
                    }
                }
            };
        }
    }
}
