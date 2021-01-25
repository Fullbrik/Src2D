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
        public event EventHandler<ContentFileEventArgs> SelectFile;
        public event EventHandler<ContentFileEventArgs> OpenFile;

        private Image folderIcon = Bitmap.FromResource("FolderClosed");
        private Image entityIcon = Bitmap.FromResource("Entity");

        public string CurrentDirectory { get => currentDirectory; }
        private string currentDirectory;

        public ContextMenu FilesListContextMenu { get; set; }

        public ContentManager()
        {
            InitializeComponent();

            Load += ContentManager_Load;

            Tree.SelectionChanged += Tree_SelectionChanged;
            FilesList.SelectedIndexChanged += FilesList_SelectedIndexChanged;
            FilesList.MouseDoubleClick += FilesList_MouseDoubleClick;
        }

        private void ContentManager_Load(object sender, EventArgs e)
        {
            if (FilesListContextMenu != null)
                FilesList.ContextMenu = FilesListContextMenu;
        }

        private void Tree_SelectionChanged(object sender, EventArgs e)
        {
            if (Tree.SelectedItem != null
                && Tree.SelectedItem is TreeGridItem node)
            {
                if (node.Tag is string directory)
                    OpenDirectory(directory);
                else if (node.Tag is Dictionary<string, Type> entities)
                    ShowEntites(entities);
            }
        }

        private void FilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilesList.SelectedIndex >= 0
               && FilesList.Items[FilesList.SelectedIndex] is ImageListItem listItem
               && listItem.Text != ".."
               && listItem.Tag is Tuple<string, bool> nameAndIsDirectory)
            {
                SelectFile?.Invoke(this, new ContentFileEventArgs(nameAndIsDirectory.Item1, nameAndIsDirectory.Item2));
            }
            else
            {
                SelectFile?.Invoke(this, new ContentFileEventArgs(null, false));
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
                    OpenFile?.Invoke(this, new ContentFileEventArgs(nameAndIsDirectory.Item1, false));
                }
            }
        }

        private void OpenDirectory(string directory)
        {
            currentDirectory = directory;

            FilesList.Items.Clear();

            if (directory != ProjectManager.ContentDirectory)
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

        private void ShowEntites(Dictionary<string, Type> entities)
        {
            currentDirectory = null;

            FilesList.Items.Clear();

            foreach (var ent in entities)
            {
                FilesList.Items.Add(new ImageListItem()
                {
                    Text = ent.Key,
                    Tag = new Tuple<string, Type>(ent.Key, ent.Value),
                    Image = entityIcon
                });
            }
        }

        public void Refresh(bool includeFolders, bool includeEntities)
        {
            TreeRoot.Children.Clear();

            if (includeFolders)
                RefreshContentFolders();
            if (includeEntities)
                RefreshEntities();

            Tree.ReloadData();

            string startDir = (Directory.Exists(currentDirectory)) ? currentDirectory : ProjectManager.ContentDirectory;
            OpenDirectory(startDir);
        }

        private void RefreshContentFolders()
        {
            if (Directory.Exists(ProjectManager.ContentDirectory))
            {
                TreeRoot.Children.Add(GetContentTreeNodeForDirectory(ProjectManager.ContentDirectory));
            }
            else
            {
                throw new DirectoryNotFoundException($"Couldn't find directory {ProjectManager.ContentDirectory}");
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

        private void RefreshEntities()
        {
            TreeGridItem entityRoot = new TreeGridItem(folderIcon, "Entities")
            {
                Expanded = true
            };
            TreeRoot.Children.Add(entityRoot);

            Dictionary<string, TreeGridItem> assemblyNodes = new Dictionary<string, TreeGridItem>();

            foreach (var ent in AssemblyManager.Entities)
            {
                string name = ent.Key;
                var entity = ent.Value;

                string assembly = entity.Assembly.GetName().Name;

                TreeGridItem parent;

                if (assemblyNodes.ContainsKey(assembly))
                {
                    parent = assemblyNodes[assembly];
                }
                else
                {
                    parent = new TreeGridItem(folderIcon, assembly)
                    {
                        Tag = new Dictionary<string, Type>()
                    };
                    assemblyNodes.Add(assembly, parent);
                    entityRoot.Children.Add(parent);
                }

                (parent.Tag as Dictionary<string, Type>).Add(name, entity);
            }
        }

        private string[] GetDirectories(string directory)
        {
            bool isRoot = directory == ProjectManager.ContentDirectory;

            var dirs = Directory.GetDirectories(directory);

            return dirs
                .Where(dir => isRoot ? (!dir.EndsWith("/bin") && !dir.EndsWith("\\bin")
                        && !dir.EndsWith("/obj") && !dir.EndsWith("\\obj")) : true)
                .ToArray();
        }
    }
}
