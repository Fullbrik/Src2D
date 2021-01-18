
namespace Src2D.Editor.Winforms.Tools.PropertyEditor
{
    partial class PropertyListEditorDialog
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListItems = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.PropEditor = new Src2D.Editor.Winforms.Tools.PropertyEditor.PropertyEditor();
            this.DoneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListItems);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PropEditor);
            this.splitContainer1.Panel2.Controls.Add(this.DoneButton);
            this.splitContainer1.Size = new System.Drawing.Size(800, 478);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // ListItems
            // 
            this.ListItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListItems.HideSelection = false;
            this.ListItems.Location = new System.Drawing.Point(0, 0);
            this.ListItems.MultiSelect = false;
            this.ListItems.Name = "ListItems";
            this.ListItems.Size = new System.Drawing.Size(266, 429);
            this.ListItems.TabIndex = 1;
            this.ListItems.UseCompatibleStateImageBehavior = false;
            this.ListItems.View = System.Windows.Forms.View.List;
            this.ListItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RemoveButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 49);
            this.panel1.TabIndex = 0;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(110, 0);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(156, 49);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(110, 49);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PropEditor
            // 
            this.PropEditor.CanCommitChnages = true;
            this.PropEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropEditor.Location = new System.Drawing.Point(0, 0);
            this.PropEditor.Name = "PropEditor";
            this.PropEditor.Preview = null;
            this.PropEditor.PropertyEditable = null;
            this.PropEditor.Size = new System.Drawing.Size(530, 429);
            this.PropEditor.TabIndex = 1;
            // 
            // DoneButton
            // 
            this.DoneButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DoneButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.Location = new System.Drawing.Point(0, 429);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(530, 49);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            // 
            // PropertyListEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PropertyListEditorDialog";
            this.Text = "PropertyListEditorDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertyListEditorDialog_FormClosing);
            this.Load += new System.EventHandler(this.PropertyListEditorDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DoneButton;
        private PropertyEditor PropEditor;
        private System.Windows.Forms.ListView ListItems;
    }
}