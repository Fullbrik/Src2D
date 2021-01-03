
namespace Src2D.Editor.Winforms
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
            this.EventsTab = new System.Windows.Forms.TabPage();
            this.PropertyList = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.PropertiesTab.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(376, 391);
            this.tabControl1.TabIndex = 0;
            // 
            // PropertiesTab
            // 
            this.PropertiesTab.Controls.Add(this.PropertyList);
            this.PropertiesTab.Location = new System.Drawing.Point(4, 22);
            this.PropertiesTab.Name = "PropertiesTab";
            this.PropertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropertiesTab.Size = new System.Drawing.Size(368, 365);
            this.PropertiesTab.TabIndex = 0;
            this.PropertiesTab.Text = "Properties";
            this.PropertiesTab.UseVisualStyleBackColor = true;
            // 
            // AssetsTab
            // 
            this.AssetsTab.Location = new System.Drawing.Point(4, 22);
            this.AssetsTab.Name = "AssetsTab";
            this.AssetsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssetsTab.Size = new System.Drawing.Size(368, 365);
            this.AssetsTab.TabIndex = 1;
            this.AssetsTab.Text = "Assets";
            this.AssetsTab.UseVisualStyleBackColor = true;
            // 
            // EventsTab
            // 
            this.EventsTab.Location = new System.Drawing.Point(4, 22);
            this.EventsTab.Name = "EventsTab";
            this.EventsTab.Size = new System.Drawing.Size(368, 365);
            this.EventsTab.TabIndex = 2;
            this.EventsTab.Text = "Events";
            this.EventsTab.UseVisualStyleBackColor = true;
            // 
            // PropertyList
            // 
            this.PropertyList.AutoScroll = true;
            this.PropertyList.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.PropertyList.ColumnCount = 1;
            this.PropertyList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyList.Location = new System.Drawing.Point(3, 3);
            this.PropertyList.Name = "PropertyList";
            this.PropertyList.RowCount = 1;
            this.PropertyList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PropertyList.Size = new System.Drawing.Size(362, 359);
            this.PropertyList.TabIndex = 0;
            // 
            // EntityPropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "EntityPropertyEditor";
            this.Size = new System.Drawing.Size(376, 391);
            this.tabControl1.ResumeLayout(false);
            this.PropertiesTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PropertiesTab;
        private System.Windows.Forms.TabPage AssetsTab;
        private System.Windows.Forms.TabPage EventsTab;
        private System.Windows.Forms.TableLayoutPanel PropertyList;
    }
}
