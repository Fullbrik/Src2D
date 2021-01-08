using Src2D.Editor.Content;
using Src2D.Editor.EnityData;
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

namespace Src2D.Editor.Winforms.ContentBrowser
{
    public partial class ContentBrowser : UserControl
    {
        private ContentFile contentFile;

        public event EventHandler<ContentItemSelectEventArgs> OnSelectFile;
        public event EventHandler<ContentItemSelectEventArgs> OnDoubleClickFile;

        public bool UseFilter { get; set; }
        public SrcAssetType[] AllowedTypes { get; set; }

        public ContentBrowser()
        {
            InitializeComponent();
        }

        private void ContentBrowser_Load(object sender, EventArgs e)
        {
        }

        public void InitializeContent(ContentFile content)
        {
            contentFile = content;

            SetupFolderTree();
        }

        public void SetupFolderTree()
        {
            FolderTree.Nodes.Clear();
            FolderTree.Nodes.Add(ContentFolderToTreeNode(contentFile.Content));
        }

        private TreeNode ContentFolderToTreeNode(ContentFolder folder)
        {
            var children = folder.Folders.Select(f => ContentFolderToTreeNode(f)).ToArray();

            return new TreeNode(folder.Name, children)
            {
                Tag = folder,
                ImageIndex = 1
            };
        }

        private void FolderTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is ContentFolder folder)
            {
                SelectFolder(folder);
            }
        }

        private void SelectFolder(ContentFolder folder)
        {
            FilesView.Items.Clear();

            if (folder.Parent != null)
            {
                var back = new ListViewItem("..", 1)
                {
                    Tag = folder.Parent
                };

                FilesView.Items.Add(back);
            }

            foreach (var f in folder.Folders)
            {
                var lvi = new ListViewItem(f.Name, 1)
                {
                    Tag = f
                };

                FilesView.Items.Add(lvi);
            }

            foreach (var item in folder.Items)
            {
                if (!UseFilter ||
                    AllowedTypes.Contains(
                        SrcAssetAttribute.GetSrcAssetTypeFor(
                            Path.GetExtension(item.FileName))))
                {
                    var lvi = new ListViewItem(item.Name, GetIconIndexFor(item))
                    {
                        Tag = item
                    };

                    FilesView.Items.Add(lvi);
                }

            }
        }

        private int GetIconIndexFor(ContentItem item)
        {
            switch (SrcAssetAttribute.GetSrcAssetTypeFor(Path.GetExtension(item.FileName)))
            {
                case SrcAssetType.None:
                    return 0;
                case SrcAssetType.Texture2D:
                    return 3;
                case SrcAssetType.Map:
                    return 4;
                default:
                    return 0;
            }
        }

        private void FilesView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilesView.SelectedItems.Count > 0)
            {
                var selected = FilesView.SelectedItems[0];
                if (selected.Tag is ContentItem item)
                {
                    OnSelectFile?.Invoke(this, new ContentItemSelectEventArgs(item));
                }
            }
        }

        private void FilesView_DoubleClick(object sender, EventArgs e)
        {
            if (FilesView.SelectedItems.Count > 0)
            {
                var selected = FilesView.SelectedItems[0];

                if (selected.Tag is ContentFolder folder)
                {
                    SelectFolder(folder);
                }
                else if (selected.Tag is ContentItem item)
                {
                    OnDoubleClickFile?.Invoke(this, new ContentItemSelectEventArgs(item));
                }
            }
        }
    }
}
