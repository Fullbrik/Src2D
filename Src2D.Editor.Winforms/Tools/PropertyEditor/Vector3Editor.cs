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

namespace Src2D.Editor.Winforms.Tools.PropertyEditor
{
    public partial class Vector3Editor : UserControl
    {
        private Action<Vector3> onChange;

        public Vector3Editor(Vector3 initial, Action<Vector3> onChange, 
            Action commitChanges)
        {
            InitializeComponent();
            X.Minimum = decimal.MinValue;
            X.Maximum = decimal.MaxValue;
            X.Value = (decimal)initial.X;
            X.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) commitChanges(); };
            X.LostFocus += (o, e) => commitChanges();

            Y.Minimum = decimal.MinValue;
            Y.Maximum = decimal.MaxValue;
            Y.Value = (decimal)initial.Y;
            Y.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) commitChanges(); };
            Y.LostFocus += (o, e) => commitChanges();

            Z.Minimum = decimal.MinValue;
            Z.Maximum = decimal.MaxValue;
            Z.Value = (decimal)initial.Z;
            Z.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) commitChanges(); };
            Z.LostFocus += (o, e) => commitChanges();

            this.onChange = onChange;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            onChange?.Invoke(new Vector3((float)X.Value, (float)Y.Value, (float)Z.Value));
        }
    }
}
