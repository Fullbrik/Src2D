using Microsoft.Xna.Framework;
using Src2D.Editor.EnityData;
using Src2D.Editor.Previews.MapEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms.Tools.MapEditor
{
    public partial class EntityPropertyEditorProperty : UserControl
    {
        public string Description { get; }
        public string PropertyName { get; }
        public SrcPropertType PropertyType { get; }
        public MapEditorEntity Entity { get; }

        private MapEditorPreview preveiw;

        public event EventHandler OnShowDescription;

        public EntityPropertyEditorProperty(MapEditorPreview preveiw, string name, DataSheetProperty property, MapEditorEntity entity)
        {
            this.preveiw = preveiw;

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
                    textBox.Text = (string)(Entity.GetProperty(PropertyName));
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
                    numericUpDown.Value = (int)(Entity.GetProperty(PropertyName));
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
                    numericUpDown.Value = (decimal)(float)(Entity.GetProperty(PropertyName));
                    numericUpDown.ValueChanged += NumericUpDown_ValueChanged_Float;
                    PropertyValueEditor.Controls.Add(numericUpDown);
                    numericUpDown.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Bool:
                    checkbox = new CheckBox();
                    checkbox.Checked = (bool)(Entity.GetProperty(PropertyName));
                    checkbox.CheckStateChanged += Checkbox_CheckStateChanged;
                    PropertyValueEditor.Controls.Add(checkbox);
                    checkbox.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Vector2:
                    Vector2Editor vector2Editor = new Vector2Editor(
                        (Vector2)(Entity.GetProperty(PropertyName)),
                        (v2) => Entity.SetProperty(PropertyName, v2));
                    PropertyValueEditor.Controls.Add(vector2Editor);
                    vector2Editor.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Vector3:
                    Vector3Editor vector3Editor = new Vector3Editor(
                        (Vector3)(Entity.GetProperty(PropertyName)),
                        (v3) => Entity.SetProperty(PropertyName, v3));
                    PropertyValueEditor.Controls.Add(vector3Editor);
                    vector3Editor.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.Color:
                    ColorEditor colorEditor = new ColorEditor(
                        (Color)(Entity.GetProperty(PropertyName)),
                        (c) => Entity.SetProperty(PropertyName, c));
                    PropertyValueEditor.Controls.Add(colorEditor);
                    colorEditor.Dock = DockStyle.Fill;
                    break;
                case SrcPropertType.EntityReferance:
                    textBox = new TextBox();
                    textBox.Text = (EntityReference)(Entity.GetProperty(PropertyName));
                    textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox.GotFocus += TextBox_EntityNames_GotFocus;
                    textBox.TextChanged += TextBox_TextChanged_ER;
                    PropertyValueEditor.Controls.Add(textBox);
                    textBox.Dock = DockStyle.Fill;
                    break;
                default:
                    break;
            }
        }

        private void TextBox_EntityNames_GotFocus(object sender, EventArgs e)
        {
            var tb = (sender as TextBox);
            tb.AutoCompleteCustomSource.Clear();
            tb.AutoCompleteCustomSource.AddRange(preveiw.EntityNames);
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

        private void TextBox_TextChanged_ER(object sender, EventArgs e)
        {
            Entity.SetProperty(PropertyName, (EntityReference)((sender as TextBox).Text));
        }

        private void EntityPropertyEditorProperty_MouseEnter(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.LightBlue;
            OnShowDescription?.Invoke(this, EventArgs.Empty);
        }

        private void EntityPropertyEditorProperty_MouseLeave(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.Transparent;
        }

        private void PropetyLabel_MouseEnter(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.LightBlue;
            OnShowDescription?.Invoke(this, EventArgs.Empty);
        }

        private void PropetyLabel_MouseLeave(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.Transparent;
        }
    }
}
