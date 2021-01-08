
namespace Src2D.Editor.Winforms.Tools.MapEditor
{
    partial class EntityPropertyEditorProperty
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
            this.PropetyLabel = new System.Windows.Forms.Label();
            this.PropertyValueEditor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PropetyLabel
            // 
            this.PropetyLabel.AutoSize = true;
            this.PropetyLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PropetyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropetyLabel.Location = new System.Drawing.Point(0, 0);
            this.PropetyLabel.Name = "PropetyLabel";
            this.PropetyLabel.Size = new System.Drawing.Size(55, 15);
            this.PropetyLabel.TabIndex = 0;
            this.PropetyLabel.Text = "Property:";
            this.PropetyLabel.MouseEnter += new System.EventHandler(this.PropetyLabel_MouseEnter);
            this.PropetyLabel.MouseLeave += new System.EventHandler(this.PropetyLabel_MouseLeave);
            // 
            // PropertyValueEditor
            // 
            this.PropertyValueEditor.AutoSize = true;
            this.PropertyValueEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyValueEditor.Location = new System.Drawing.Point(55, 0);
            this.PropertyValueEditor.Name = "PropertyValueEditor";
            this.PropertyValueEditor.Size = new System.Drawing.Size(1245, 20);
            this.PropertyValueEditor.TabIndex = 1;
            // 
            // EntityPropertyEditorProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PropertyValueEditor);
            this.Controls.Add(this.PropetyLabel);
            this.Name = "EntityPropertyEditorProperty";
            this.Size = new System.Drawing.Size(1300, 20);
            this.Load += new System.EventHandler(this.EntityPropertyEditorProperty_Load);
            this.MouseEnter += new System.EventHandler(this.EntityPropertyEditorProperty_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.EntityPropertyEditorProperty_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PropetyLabel;
        private System.Windows.Forms.Panel PropertyValueEditor;
    }
}
