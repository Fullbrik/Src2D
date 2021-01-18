using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms.Tools.PropertyEditor
{
    public partial class ColorEditor : UserControl
    {
        private SolidBrush currentBrush;
        private Action<Microsoft.Xna.Framework.Color> onChange;
        private Action commitChanges;

        public ColorEditor(Microsoft.Xna.Framework.Color initial, 
            Action<Microsoft.Xna.Framework.Color> onChange, 
            Action commitChanges)
        {
            InitializeComponent();

            currentBrush = new SolidBrush(
                Color.FromArgb(initial.A, initial.R, initial.G, initial.B));

            this.onChange = onChange;
            this.commitChanges = commitChanges;
        }

        private void Preview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(currentBrush, e.ClipRectangle);
        }

        private void OpenDialogButton_Click(object sender, EventArgs e)
        {
            if(ColorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                var color = ColorPickerDialog.Color;
                currentBrush.Color = color;
                onChange?.Invoke(new Microsoft.Xna.Framework.Color(
                    color.R,
                    color.G,
                    color.B,
                    color.A));
                commitChanges?.Invoke();
                Invalidate();
            }
        }
    }
}
