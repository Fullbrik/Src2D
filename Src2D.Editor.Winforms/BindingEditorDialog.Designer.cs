
namespace Src2D.Editor.Winforms
{
    partial class BindingEditorDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.EventName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OtherEntity = new System.Windows.Forms.TextBox();
            this.OverideParam = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ParamOveride = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ActionName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event:";
            // 
            // EventName
            // 
            this.EventName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EventName.FormattingEnabled = true;
            this.EventName.Location = new System.Drawing.Point(66, 9);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(439, 21);
            this.EventName.TabIndex = 1;
            this.EventName.SelectedIndexChanged += new System.EventHandler(this.EventName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Other Entity:";
            // 
            // OtherEntity
            // 
            this.OtherEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OtherEntity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.OtherEntity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.OtherEntity.Location = new System.Drawing.Point(101, 32);
            this.OtherEntity.Name = "OtherEntity";
            this.OtherEntity.Size = new System.Drawing.Size(404, 20);
            this.OtherEntity.TabIndex = 3;
            this.OtherEntity.TextChanged += new System.EventHandler(this.OtherEntity_TextChanged);
            // 
            // OverideParam
            // 
            this.OverideParam.AutoSize = true;
            this.OverideParam.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OverideParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverideParam.Location = new System.Drawing.Point(12, 80);
            this.OverideParam.Name = "OverideParam";
            this.OverideParam.Size = new System.Drawing.Size(151, 21);
            this.OverideParam.TabIndex = 4;
            this.OverideParam.Text = "Overide Parameter:";
            this.OverideParam.UseVisualStyleBackColor = true;
            this.OverideParam.CheckedChanged += new System.EventHandler(this.OverideParam_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parameter Overide:";
            // 
            // ParamOveride
            // 
            this.ParamOveride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamOveride.Location = new System.Drawing.Point(150, 104);
            this.ParamOveride.Name = "ParamOveride";
            this.ParamOveride.Size = new System.Drawing.Size(358, 20);
            this.ParamOveride.TabIndex = 6;
            this.ParamOveride.TextChanged += new System.EventHandler(this.ParamOveride_TextChanged);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.Location = new System.Drawing.Point(12, 130);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(496, 24);
            this.ApplyButton.TabIndex = 7;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Action:";
            // 
            // ActionName
            // 
            this.ActionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionName.FormattingEnabled = true;
            this.ActionName.Location = new System.Drawing.Point(66, 58);
            this.ActionName.Name = "ActionName";
            this.ActionName.Size = new System.Drawing.Size(439, 21);
            this.ActionName.TabIndex = 9;
            this.ActionName.SelectedIndexChanged += new System.EventHandler(this.ActionName_SelectedIndexChanged);
            // 
            // BindingEditorDialog
            // 
            this.AcceptButton = this.ApplyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 160);
            this.Controls.Add(this.ActionName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ParamOveride);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OverideParam);
            this.Controls.Add(this.OtherEntity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EventName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingEditorDialog";
            this.Text = "Binding Editor";
            this.Load += new System.EventHandler(this.BindingEditorDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EventName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OtherEntity;
        private System.Windows.Forms.CheckBox OverideParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ParamOveride;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ActionName;
    }
}