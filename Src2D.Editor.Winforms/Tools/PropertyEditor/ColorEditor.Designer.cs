
namespace Src2D.Editor.Winforms.Tools.PropertyEditor
{
    partial class ColorEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorEditor));
            this.ColorPickerDialog = new System.Windows.Forms.ColorDialog();
            this.OpenDialogButton = new System.Windows.Forms.Button();
            this.Preview = new System.Windows.Forms.Panel();
            this.Images = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // OpenDialogButton
            // 
            this.OpenDialogButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.OpenDialogButton.ImageKey = "ColorDialog_16x.png";
            this.OpenDialogButton.ImageList = this.Images;
            this.OpenDialogButton.Location = new System.Drawing.Point(280, 0);
            this.OpenDialogButton.Name = "OpenDialogButton";
            this.OpenDialogButton.Size = new System.Drawing.Size(75, 25);
            this.OpenDialogButton.TabIndex = 1;
            this.OpenDialogButton.UseVisualStyleBackColor = true;
            this.OpenDialogButton.Click += new System.EventHandler(this.OpenDialogButton_Click);
            // 
            // Preview
            // 
            this.Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Preview.Location = new System.Drawing.Point(0, 0);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(280, 25);
            this.Preview.TabIndex = 2;
            this.Preview.Paint += new System.Windows.Forms.PaintEventHandler(this.Preview_Paint);
            // 
            // Images
            // 
            this.Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Images.ImageStream")));
            this.Images.TransparentColor = System.Drawing.Color.Transparent;
            this.Images.Images.SetKeyName(0, "ColorDialog_16x.png");
            // 
            // ColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.OpenDialogButton);
            this.Name = "ColorEditor";
            this.Size = new System.Drawing.Size(355, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog ColorPickerDialog;
        private System.Windows.Forms.Button OpenDialogButton;
        private System.Windows.Forms.Panel Preview;
        private System.Windows.Forms.ImageList Images;
    }
}
