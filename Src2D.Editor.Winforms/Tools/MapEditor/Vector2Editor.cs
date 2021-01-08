using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms.Tools.MapEditor
{
    public partial class Vector2Editor : UserControl
    {
        private Action<Vector2> onChange;

        public Vector2Editor(Vector2 initial, Action<Vector2> onChange)
        {
            InitializeComponent();
            X.Minimum = decimal.MinValue;
            X.Maximum = decimal.MaxValue;
            X.Value = (decimal)initial.X;

            Y.Minimum = decimal.MinValue;
            Y.Maximum = decimal.MaxValue;
            Y.Value = (decimal)initial.Y;

            this.onChange = onChange;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            onChange?.Invoke(new Vector2((float)X.Value, (float)Y.Value));
        }
    }
}
