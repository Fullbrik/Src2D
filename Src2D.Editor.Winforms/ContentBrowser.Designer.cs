
namespace Src2D.Editor.Winforms
{
    partial class ContentBrowser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentBrowser));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FolderTree = new System.Windows.Forms.TreeView();
            this.FilesView = new System.Windows.Forms.ListView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FolderTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FilesView);
            this.splitContainer1.Size = new System.Drawing.Size(784, 437);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 0;
            // 
            // FolderTree
            // 
            this.FolderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderTree.ImageIndex = 1;
            this.FolderTree.ImageList = this.ImageList;
            this.FolderTree.Location = new System.Drawing.Point(0, 0);
            this.FolderTree.Name = "FolderTree";
            this.FolderTree.SelectedImageIndex = 2;
            this.FolderTree.Size = new System.Drawing.Size(261, 437);
            this.FolderTree.TabIndex = 0;
            this.FolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTree_AfterSelect);
            // 
            // FilesView
            // 
            this.FilesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesView.HideSelection = false;
            this.FilesView.LargeImageList = this.ImageList;
            this.FilesView.Location = new System.Drawing.Point(0, 0);
            this.FilesView.MultiSelect = false;
            this.FilesView.Name = "FilesView";
            this.FilesView.Size = new System.Drawing.Size(519, 437);
            this.FilesView.SmallImageList = this.ImageList;
            this.FilesView.TabIndex = 0;
            this.FilesView.UseCompatibleStateImageBehavior = false;
            this.FilesView.SelectedIndexChanged += new System.EventHandler(this.FilesView_SelectedIndexChanged);
            this.FilesView.DoubleClick += new System.EventHandler(this.FilesView_DoubleClick);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Question_16x.png");
            this.ImageList.Images.SetKeyName(1, "FolderClosed_16x.png");
            this.ImageList.Images.SetKeyName(2, "FolderBottomPanel_16x.png");
            this.ImageList.Images.SetKeyName(3, "ImagePixel_16x.png");
            this.ImageList.Images.SetKeyName(4, "GridDark_16x.png");
            // 
            // ContentBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ContentBrowser";
            this.Size = new System.Drawing.Size(784, 437);
            this.Load += new System.EventHandler(this.ContentBrowser_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView FolderTree;
        private System.Windows.Forms.ListView FilesView;
        private System.Windows.Forms.ImageList ImageList;
    }
}
