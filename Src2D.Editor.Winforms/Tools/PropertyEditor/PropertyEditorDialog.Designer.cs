
namespace Src2D.Editor.Winforms.Tools.PropertyEditor
{
    partial class PropertyEditorDialog
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
            this.Done = new System.Windows.Forms.Button();
            this.PropEdit = new Src2D.Editor.Winforms.Tools.PropertyEditor.PropertyEditor();
            this.SuspendLayout();
            // 
            // Done
            // 
            this.Done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Done.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done.Location = new System.Drawing.Point(0, 415);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(800, 35);
            this.Done.TabIndex = 1;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // PropEdit
            // 
            this.PropEdit.CanCommitChnages = true;
            this.PropEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropEdit.Location = new System.Drawing.Point(0, 0);
            this.PropEdit.Name = "PropEdit";
            this.PropEdit.Preview = null;
            this.PropEdit.PropertyEditable = null;
            this.PropEdit.Size = new System.Drawing.Size(800, 415);
            this.PropEdit.TabIndex = 2;
            // 
            // PropertyEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PropEdit);
            this.Controls.Add(this.Done);
            this.Name = "PropertyEditorDialog";
            this.Text = "PropertyEditorDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertyEditorDialog_FormClosing);
            this.Load += new System.EventHandler(this.PropertyEditorDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Done;
        private PropertyEditor PropEdit;
    }
}