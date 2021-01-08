
namespace Src2D.Editor.Winforms.Tools
{
    partial class ToolLauncher
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
            this.ContentBrowser = new Src2D.Editor.Winforms.ContentBrowser.ContentBrowser();
            this.SuspendLayout();
            // 
            // ContentBrowser
            // 
            this.ContentBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentBrowser.Location = new System.Drawing.Point(0, 0);
            this.ContentBrowser.Name = "ContentBrowser";
            this.ContentBrowser.Size = new System.Drawing.Size(800, 450);
            this.ContentBrowser.TabIndex = 0;
            this.ContentBrowser.OnDoubleClickFile += new System.EventHandler<Src2D.Editor.Content.ContentItemSelectEventArgs>(this.ContentBrowser_OnDoubleClickFile);
            // 
            // ToolLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentBrowser);
            this.Name = "ToolLauncher";
            this.Text = "ProjectName - Tools";
            this.Load += new System.EventHandler(this.ToolLauncher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ContentBrowser.ContentBrowser ContentBrowser;
    }
}