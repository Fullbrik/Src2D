using Microsoft.Xna.Framework;
using Src2D.Editor.EnityData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms
{
    public partial class EntityPropertyEditorProperty : UserControl
    {
        public string Description { get; }
        public string PropertyName { get; }
        public SrcPropertType PropertyType { get; }
        public MapEditorEntity Entity { get; }

        public EntityPropertyEditorProperty(string name, DataSheetProperty property, MapEditorEntity entity)
        {
            InitializeComponent();

            PropertyName = name;
            PropertyType = property.PropertyType;

            Description = property.Description;
            Entity = entity;
        }

        private void EntityPropertyEditorProperty_Load(object sender, EventArgs e)
        {
            PropetyLabel.Text = PropertyName + ":";
            SetEditor();
        }

        private void SetEditor()
        {
            TextBox textBox;
            CheckBox checkbox;
            NumericUpDown numericUpDown;
            switch (PropertyType)
            {
                case SrcPropertType.None:
                    break;
                case SrcPropertType.String:
                    textBox = new TextBox();
                    textBox.Text = (string)(Entity.GetProperty(PropertyName) ?? "");
                    textBox.TextChanged += TextBox_TextChanged;
                    PropertyValueEditor.Controls.Add(textBox);
                    textBox.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Int:
                    numericUpDown = new NumericUpDown();
                    numericUpDown.Minimum = int.MaxValue;
                    numericUpDown.Minimum = int.MinValue;
                    numericUpDown.DecimalPlaces = 0;
                    numericUpDown.Increment = 1;
                    numericUpDown.Value = (int)(Entity.GetProperty(PropertyName) ?? 0);
                    numericUpDown.ValueChanged += NumericUpDown_ValueChanged_Int;
                    PropertyValueEditor.Controls.Add(numericUpDown);
                    numericUpDown.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Float:
                    numericUpDown = new NumericUpDown();
                    numericUpDown.DecimalPlaces = 5;
                    numericUpDown.Increment = .1M;
                    numericUpDown.Minimum = decimal.MaxValue;
                    numericUpDown.Minimum = decimal.MinValue;
                    numericUpDown.Value = (decimal)(float)(Entity.GetProperty(PropertyName) ?? 0);
                    numericUpDown.ValueChanged += NumericUpDown_ValueChanged_Float;
                    PropertyValueEditor.Controls.Add(numericUpDown);
                    numericUpDown.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Bool:
                    checkbox = new CheckBox();
                    checkbox.Checked = (bool)(Entity.GetProperty(PropertyName) ?? false);
                    checkbox.CheckStateChanged += Checkbox_CheckStateChanged;
                    PropertyValueEditor.Controls.Add(checkbox);
                    checkbox.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Vector2:
                    Vector2Editor vector2Editor = new Vector2Editor(
                        (Vector2)(Entity.GetProperty(PropertyName) ?? Vector2.Zero),
                        (v2) => Entity.SetProperty(PropertyName, v2));
                    PropertyValueEditor.Controls.Add(vector2Editor);
                    vector2Editor.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Vector3:
                    Vector3Editor vector3Editor = new Vector3Editor(
                        (Vector3)(Entity.GetProperty(PropertyName) ?? Vector3.Zero),
                        (v3) => Entity.SetProperty(PropertyName, v3));
                    PropertyValueEditor.Controls.Add(vector3Editor);
                    vector3Editor.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Color:
                    break;
                case SrcPropertType.EntityReferance:
                    break;
                default:
                    break;
            }
        }


        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            Entity.SetProperty(PropertyName, (sender as TextBox).Text);
        }

        private void NumericUpDown_ValueChanged_Int(object sender, EventArgs e)
        {
            Entity.SetProperty(PropertyName, (int)((decimal)((sender as NumericUpDown).Value)));
        }

        private void NumericUpDown_ValueChanged_Float(object sender, EventArgs e)
        {
            Entity.SetProperty(PropertyName, (float)((decimal)((sender as NumericUpDown).Value)));
        }

        private void Checkbox_CheckStateChanged(object sender, EventArgs e)
        {
            Entity.SetProperty(PropertyName, (sender as CheckBox).Checked);
        }
    }
}
