
namespace Src2D.Editor.Winforms.Tools.MapEditor
{
    partial class EntityPropertyEditor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PropertiesTab = new System.Windows.Forms.TabPage();
            this.AssetsTab = new System.Windows.Forms.TabPage();
            this.AssetList = new Src2D.Editor.Winforms.BufferedTableLayout();
            this.EventsTab = new System.Windows.Forms.TabPage();
            this.BindingsList = new System.Windows.Forms.ListView();
            this.EntityName = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DescriptionGB = new System.Windows.Forms.GroupBox();
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.PropertyEditor = new Src2D.Editor.Winforms.Tools.PropertyEditor.PropertyEditor();
            this.tabControl1.SuspendLayout();
            this.PropertiesTab.SuspendLayout();
            this.AssetsTab.SuspendLayout();
            this.EventsTab.SuspendLayout();
            this.EntityName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.DescriptionGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PropertiesTab);
            this.tabControl1.Controls.Add(this.AssetsTab);
            this.tabControl1.Controls.Add(this.EventsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 257);
            this.tabControl1.TabIndex = 0;
            // 
            // PropertiesTab
            // 
            this.PropertiesTab.Controls.Add(this.PropertyEditor);
            this.PropertiesTab.Location = new System.Drawing.Point(4, 22);
            this.PropertiesTab.Name = "PropertiesTab";
            this.PropertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropertiesTab.Size = new System.Drawing.Size(362, 231);
            this.PropertiesTab.TabIndex = 0;
            this.PropertiesTab.Text = "Properties";
            this.PropertiesTab.UseVisualStyleBackColor = true;
            // 
            // AssetsTab
            // 
            this.AssetsTab.Controls.Add(this.AssetList);
            this.AssetsTab.Location = new System.Drawing.Point(4, 22);
            this.AssetsTab.Name = "AssetsTab";
            this.AssetsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssetsTab.Size = new System.Drawing.Size(362, 231);
            this.AssetsTab.TabIndex = 1;
            this.AssetsTab.Text = "Assets";
            this.AssetsTab.UseVisualStyleBackColor = true;
            // 
            // AssetList
            // 
            this.AssetList.AutoScroll = true;
            this.AssetList.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.AssetList.ColumnCount = 1;
            this.AssetList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetList.Location = new System.Drawing.Point(3, 3);
            this.AssetList.Name = "AssetList";
            this.AssetList.RowCount = 1;
            this.AssetList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AssetList.Size = new System.Drawing.Size(356, 225);
            this.AssetList.TabIndex = 0;
            // 
            // EventsTab
            // 
            this.EventsTab.Controls.Add(this.BindingsList);
            this.EventsTab.Location = new System.Drawing.Point(4, 22);
            this.EventsTab.Name = "EventsTab";
            this.EventsTab.Size = new System.Drawing.Size(362, 231);
            this.EventsTab.TabIndex = 2;
            this.EventsTab.Text = "Events";
            this.EventsTab.UseVisualStyleBackColor = true;
            // 
            // BindingsList
            // 
            this.BindingsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BindingsList.HideSelection = false;
            this.BindingsList.LabelWrap = false;
            this.BindingsList.Location = new System.Drawing.Point(3, 3);
            this.BindingsList.MultiSelect = false;
            this.BindingsList.Name = "BindingsList";
            this.BindingsList.Size = new System.Drawing.Size(356, 225);
            this.BindingsList.TabIndex = 0;
            this.BindingsList.UseCompatibleStateImageBehavior = false;
            this.BindingsList.View = System.Windows.Forms.View.List;
            this.BindingsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BindingsList_MouseDoubleClick);
            // 
            // EntityName
            // 
            this.EntityName.Controls.Add(this.splitContainer1);
            this.EntityName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntityName.Location = new System.Drawing.Point(0, 0);
            this.EntityName.Name = "EntityName";
            this.EntityName.Size = new System.Drawing.Size(376, 391);
            this.EntityName.TabIndex = 1;
            this.EntityName.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DescriptionGB);
            this.splitContainer1.Size = new System.Drawing.Size(370, 372);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 1;
            // 
            // DescriptionGB
            // 
            this.DescriptionGB.Controls.Add(this.DescriptionText);
            this.DescriptionGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionGB.Location = new System.Drawing.Point(0, 0);
            this.DescriptionGB.Name = "DescriptionGB";
            this.DescriptionGB.Size = new System.Drawing.Size(370, 111);
            this.DescriptionGB.TabIndex = 0;
            this.DescriptionGB.TabStop = false;
            this.DescriptionGB.Text = "Description";
            // 
            // DescriptionText
            // 
            this.DescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionText.Location = new System.Drawing.Point(3, 16);
            this.DescriptionText.Multiline = true;
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ReadOnly = true;
            this.DescriptionText.Size = new System.Drawing.Size(364, 92);
            this.DescriptionText.TabIndex = 0;
            // 
            // PropertyEditor
            // 
            this.PropertyEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyEditor.Location = new System.Drawing.Point(3, 3);
            this.PropertyEditor.Preview = null;
            this.PropertyEditor.Name = "PropertyEditor";
            this.PropertyEditor.PropertyEditable = null;
            this.PropertyEditor.Size = new System.Drawing.Size(356, 225);
            this.PropertyEditor.TabIndex = 0;
            // 
            // EntityPropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EntityName);
            this.Name = "EntityPropertyEditor";
            this.Size = new System.Drawing.Size(376, 391);
            this.tabControl1.ResumeLayout(false);
            this.PropertiesTab.ResumeLayout(false);
            this.AssetsTab.ResumeLayout(false);
            this.EventsTab.ResumeLayout(false);
            this.EntityName.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.DescriptionGB.ResumeLayout(false);
            this.DescriptionGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PropertiesTab;
        private System.Windows.Forms.TabPage AssetsTab;
        private System.Windows.Forms.TabPage EventsTab;
        private System.Windows.Forms.GroupBox EntityName;
        private Src2D.Editor.Winforms.BufferedTableLayout AssetList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox DescriptionGB;
        private System.Windows.Forms.TextBox DescriptionText;
        private System.Windows.Forms.ListView BindingsList;
        private PropertyEditor.PropertyEditor PropertyEditor;
    }
}
