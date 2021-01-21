using System;
using Eto.Forms;
using Eto.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Eto.IO;

namespace Src2D.Editor.ContentManager
{
    public partial class ContentManager : Panel
    {
        public event EventHandler<ContentFileOpenEventArgs> OpenFile;

        public string ContentFolder { get; set; }

        private Image folderIcon = Bitmap.FromResource("FolderClosed");

        public ContentManager()
        {
            InitializeComponent();

            Tree.SelectionChanged += Tree_SelectionChanged;
            FilesList.MouseDoubleClick += FilesList_MouseDoubleClick;
        }

        private void Tree_SelectionChanged(object sender, EventArgs e)
        {
            if (Tree.SelectedItem != null
                && Tree.SelectedItem is TreeGridItem node
                && node.Tag is string directory)
            {
                OpenDirectory(directory);
            }
        }

        private void FilesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (FilesList.SelectedIndex >= 0
                && FilesList.Items[FilesList.SelectedIndex] is ImageListItem listItem
                && listItem.Tag is Tuple<string, bool> nameAndIsDirectory)
            {
                if (nameAndIsDirectory.Item2)
                {
                    OpenDirectory(nameAndIsDirectory.Item1);
                }
                else
                {
                    OpenFile?.Invoke(this, new ContentFileOpenEventArgs(nameAndIsDirectory.Item1));
                }
            }
        }

        private void OpenDirectory(string directory)
        {
            FilesList.Items.Clear();

            if (directory != ContentFolder)
            {
                var dir = Directory.GetParent(directory).FullName;

                FilesList.Items.Add(new ImageListItem()
                {
                    Text = "..",
                    Tag = new Tuple<string, bool>(dir, true),
                    Image = folderIcon
                });
            }

            var directories = GetDirectories(directory);
            foreach (var dir in directories)
            {
                FilesList.Items.Add(new ImageListItem()
                {
                    Text = Path.GetFileName(dir),
                    Tag = new Tuple<string, bool>(dir, true),
                    Image = folderIcon
                });
            }

            var files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                FilesList.Items.Add(new ImageListItem()
                {
                    Text = Path.GetFileName(file),
                    Tag = new Tuple<string, bool>(file, false),
                    Image = SystemIcons.GetFileIcon(file, IconSize.Small)
                });
            }
        }

        public void Refresh()
        {
            TreeRoot.Children.Clear();
            RefreshContentFolders();
            Tree.ReloadData();

            if (Tree.SelectedItem == null) OpenDirectory(ContentFolder);
        }

        private void RefreshContentFolders()
        {
            if (Directory.Exists(ContentFolder))
            {
                TreeRoot.Children.Add(GetContentTreeNodeForDirectory(ContentFolder));
            }
            else
            {
                throw new DirectoryNotFoundException($"Couldn't find directory {ContentFolder}");
            }
        }

        private TreeGridItem GetContentTreeNodeForDirectory(string directory)
        {
            var children = GetDirectories(directory)
                .Select(dir => GetContentTreeNodeForDirectory(dir)).ToArray();

            TreeGridItem node = new TreeGridItem(children, folderIcon, Path.GetFileName(directory))
            {
                Tag = directory,
                Expanded = true
            };

            return node;
        }

        private string[] GetDirectories(string directory)
        {
            bool isRoot = directory == ContentFolder;

            var dirs = Directory.GetDirectories(directory);

            return dirs
                .Where(dir => isRoot ? (!dir.EndsWith("/bin") && !dir.EndsWith("\\bin")
                        && !dir.EndsWith("/obj") && !dir.EndsWith("\\obj")) : true)
                .ToArray();
        }
    }
}
