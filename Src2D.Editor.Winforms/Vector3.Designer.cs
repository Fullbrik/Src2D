
namespace Src2D.Editor.Winforms
{
    partial class Vector3Editor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.X = new System.Windows.Forms.NumericUpDown();
            this.Y = new System.Windows.Forms.NumericUpDown();
            this.Z = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.X, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Y, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Z, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // X
            // 
            this.X.DecimalPlaces = 5;
            this.X.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.X.Location = new System.Drawing.Point(3, 3);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(102, 20);
            this.X.TabIndex = 0;
            this.X.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // Y
            // 
            this.Y.DecimalPlaces = 5;
            this.Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Y.Location = new System.Drawing.Point(111, 3);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(102, 20);
            this.Y.TabIndex = 1;
            this.Y.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // Z
            // 
            this.Z.DecimalPlaces = 5;
            this.Z.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Z.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Z.Location = new System.Drawing.Point(219, 3);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(104, 20);
            this.Z.TabIndex = 2;
            this.Z.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // Vector3Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Vector3Editor";
            this.Size = new System.Drawing.Size(326, 26);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown X;
        private System.Windows.Forms.NumericUpDown Y;
        private System.Windows.Forms.NumericUpDown Z;
    }
}
