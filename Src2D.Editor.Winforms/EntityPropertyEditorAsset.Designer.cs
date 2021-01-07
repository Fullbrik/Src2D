
namespace Src2D.Editor.Winforms
{
    partial class EntityPropertyEditorAsset
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
            this.PropertyName = new System.Windows.Forms.Label();
            this.BrowsButton = new System.Windows.Forms.Button();
            this.AssetNameText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertyName
            // 
            this.PropertyName.AutoSize = true;
            this.PropertyName.Dock = System.Windows.Forms.DockStyle.Left;
            this.PropertyName.Location = new System.Drawing.Point(0, 0);
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.Size = new System.Drawing.Size(36, 13);
            this.PropertyName.TabIndex = 0;
            this.PropertyName.Text = "Asset:";
            this.PropertyName.MouseEnter += new System.EventHandler(this.PropertyName_MouseEnter);
            this.PropertyName.MouseLeave += new System.EventHandler(this.PropertyName_MouseLeave);
            // 
            // BrowsButton
            // 
            this.BrowsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.BrowsButton.Location = new System.Drawing.Point(1274, 0);
            this.BrowsButton.Name = "BrowsButton";
            this.BrowsButton.Size = new System.Drawing.Size(26, 20);
            this.BrowsButton.TabIndex = 1;
            this.BrowsButton.Text = "...";
            this.BrowsButton.UseVisualStyleBackColor = true;
            this.BrowsButton.Click += new System.EventHandler(this.BrowsButton_Click);
            // 
            // AssetNameText
            // 
            this.AssetNameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetNameText.Location = new System.Drawing.Point(0, 0);
            this.AssetNameText.Name = "AssetNameText";
            this.AssetNameText.ReadOnly = true;
            this.AssetNameText.Size = new System.Drawing.Size(1238, 20);
            this.AssetNameText.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.AssetNameText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(36, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1238, 20);
            this.panel1.TabIndex = 3;
            // 
            // EntityPropertyEditorAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BrowsButton);
            this.Controls.Add(this.PropertyName);
            this.Name = "EntityPropertyEditorAsset";
            this.Size = new System.Drawing.Size(1300, 20);
            this.Load += new System.EventHandler(this.EntityPropertyEditorAsset_Load);
            this.MouseEnter += new System.EventHandler(this.EntityPropertyEditorAsset_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.EntityPropertyEditorAsset_MouseLeave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PropertyName;
        private System.Windows.Forms.Button BrowsButton;
        private System.Windows.Forms.TextBox AssetNameText;
        private System.Windows.Forms.Panel panel1;
    }
}
