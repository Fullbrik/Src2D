
namespace Src2D.Editor.Winforms
{
    partial class MapEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.EntityList = new System.Windows.Forms.TreeView();
            this.PropertyEditor = new Src2D.Editor.Winforms.EntityPropertyEditor();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.MapPreview = new Src2D.Editor.Winforms.MapEditorPreveiwControl();
            this.ContentBrowser = new Src2D.Editor.Winforms.ContentBrowser();
            this.EntityListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GizmoSelector = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1130, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1130, 547);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.EntityList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.PropertyEditor);
            this.splitContainer2.Size = new System.Drawing.Size(215, 547);
            this.splitContainer2.SplitterDistance = 279;
            this.splitContainer2.TabIndex = 0;
            // 
            // EntityList
            // 
            this.EntityList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntityList.Location = new System.Drawing.Point(0, 0);
            this.EntityList.Name = "EntityList";
            this.EntityList.Size = new System.Drawing.Size(215, 279);
            this.EntityList.TabIndex = 0;
            this.EntityList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.EntityList_AfterSelect);
            // 
            // PropertyEditor
            // 
            this.PropertyEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyEditor.Entity = null;
            this.PropertyEditor.Location = new System.Drawing.Point(0, 0);
            this.PropertyEditor.Name = "PropertyEditor";
            this.PropertyEditor.Preview = null;
            this.PropertyEditor.Size = new System.Drawing.Size(215, 264);
            this.PropertyEditor.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.MapPreview);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ContentBrowser);
            this.splitContainer3.Size = new System.Drawing.Size(911, 547);
            this.splitContainer3.SplitterDistance = 418;
            this.splitContainer3.TabIndex = 1;
            // 
            // MapPreview
            // 
            this.MapPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPreview.Location = new System.Drawing.Point(0, 0);
            this.MapPreview.MouseHoverUpdatesOnly = false;
            this.MapPreview.Name = "MapPreview";
            this.MapPreview.Size = new System.Drawing.Size(911, 418);
            this.MapPreview.TabIndex = 0;
            this.MapPreview.Text = "map";
            this.MapPreview.OnAction += new System.EventHandler(this.MapPreview_OnAction);
            this.MapPreview.OnUndoOrRedo += new System.EventHandler(this.MapPreview_OnUndoOrRedo);
            // 
            // ContentBrowser
            // 
            this.ContentBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentBrowser.Location = new System.Drawing.Point(0, 0);
            this.ContentBrowser.Name = "ContentBrowser";
            this.ContentBrowser.Size = new System.Drawing.Size(911, 125);
            this.ContentBrowser.TabIndex = 0;
            // 
            // EntityListContextMenu
            // 
            this.EntityListContextMenu.Name = "EntityListContextMenu";
            this.EntityListContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // GizmoSelector
            // 
            this.GizmoSelector.CanOverflow = false;
            this.GizmoSelector.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.GizmoSelector.Location = new System.Drawing.Point(0, 24);
            this.GizmoSelector.Name = "GizmoSelector";
            this.GizmoSelector.Size = new System.Drawing.Size(1130, 25);
            this.GizmoSelector.Stretch = true;
            this.GizmoSelector.TabIndex = 2;
            this.GizmoSelector.Text = "toolStrip1";
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 599);
            this.Controls.Add(this.GizmoSelector);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditor";
            this.Text = "LevelEditor";
            this.Load += new System.EventHandler(this.LevelEditor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapEditor_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MapEditorPreveiwControl MapPreview;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private ContentBrowser ContentBrowser;
        private System.Windows.Forms.TreeView EntityList;
        private System.Windows.Forms.ContextMenuStrip EntityListContextMenu;
        private System.Windows.Forms.ToolStrip GizmoSelector;
        private EntityPropertyEditor PropertyEditor;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}