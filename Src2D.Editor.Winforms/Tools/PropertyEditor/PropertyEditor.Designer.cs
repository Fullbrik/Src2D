
namespace Src2D.Editor.Winforms.Tools.PropertyEditor
{
    partial class PropertyEditor
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
            this.PropertyList = new Src2D.Editor.Winforms.BufferedTableLayout();
            this.SuspendLayout();
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
            this.PropertyList.Size = new System.Drawing.Size(356, 225);
            this.PropertyList.TabIndex = 0;
            // 
            // PropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PropertyList);
            this.Name = "PropertyEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private BufferedTableLayout PropertyList;
    }
}
