
namespace Src2D.Editor.Winforms.ContentBrowser
{
    partial class ContentBrowserDialog
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
            this.Cancel = new System.Windows.Forms.Button();
            this.CB = new Src2D.Editor.Winforms.ContentBrowser.ContentBrowser();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Cancel.Location = new System.Drawing.Point(0, 427);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(800, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            // 
            // CB
            // 
            this.CB.AllowedTypes = null;
            this.CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB.Location = new System.Drawing.Point(0, 0);
            this.CB.Name = "CB";
            this.CB.Size = new System.Drawing.Size(800, 450);
            this.CB.TabIndex = 0;
            this.CB.UseFilter = false;
            this.CB.OnDoubleClickFile += new System.EventHandler<Src2D.Editor.Content.ContentItemSelectEventArgs>(this.CB_OnDoubleClickFile);
            // 
            // ContentBrowserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.CB);
            this.Name = "ContentBrowserDialog";
            this.Text = "ContentBrowserDialog";
            this.ResumeLayout(false);

        }

        #endregion
        private ContentBrowser CB;
        private System.Windows.Forms.Button Cancel;
    }
}