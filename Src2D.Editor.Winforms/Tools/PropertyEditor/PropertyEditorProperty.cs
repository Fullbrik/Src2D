using Microsoft.Xna.Framework;
using Src2D.Attributes;
using Src2D.Data;
using Src2D.Editor.EnityData;
using Src2D.Editor.Previews;
using Src2D.Editor.Previews.MapEditor;
using Src2D.Editor.SchemaData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms.Tools.PropertyEditor
{
    public partial class PropertyEditorProperty : UserControl
    {
        public string Description { get; }
        public string PropertyName { get; }
        public SrcPropertyType PropertyType { get; }
        public IPropertyEditable PropertyEditable { get; }
        public bool CanCommitChanges { get; }

        private object startingValue;
        private bool valueChanged = false;

        private EditorPreview preveiw;

        public event EventHandler OnShowDescription;

        public PropertyEditorProperty(EditorPreview preveiw,
            string name,
            PropertyData property,
            IPropertyEditable propertyEditable,
            bool canCommitChanges)
        {
            this.preveiw = preveiw;

            InitializeComponent();

            PropertyName = name;
            PropertyType = property.PropertyType;

            Description = property.Description;
            PropertyEditable = propertyEditable;

            CanCommitChanges = canCommitChanges;
        }

        private void EntityPropertyEditorProperty_Load(object sender, EventArgs e)
        {
            PropetyLabel.Text = PropertyName + ":";
            startingValue = PropertyEditable.GetProperty(PropertyName);
            if (PropertyType == SrcPropertyType.List)
                startingValue = (startingValue as IEnumerable)
                    .Cast<IPropertyEditable>().ToList();

            try
            {
                SetEditor();
            }
            catch (Exception ex)
            {

                throw new Exception($"Invalid property type {PropertyEditable.GetProperty(PropertyName).GetType().FullName}", ex);
            }

        }

        private void SetEditor()
        {
            TextBox textBox;
            CheckBox checkbox;
            NumericUpDown numericUpDown;
            Button button;
            switch (PropertyType)
            {
                case SrcPropertyType.None:
                    break;
                case SrcPropertyType.String:
                    textBox = new TextBox();
                    textBox.Text = (string)(PropertyEditable.GetProperty(PropertyName));
                    textBox.TextChanged += TextBox_TextChanged;
                    textBox.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) CommitChanges(); };
                    textBox.LostFocus += (o, e) => CommitChanges();
                    PropertyValueEditor.Controls.Add(textBox);
                    textBox.Dock = DockStyle.Fill;
                    break;
                case SrcPropertyType.Int:
                    numericUpDown = new NumericUpDown();
                    numericUpDown.Minimum = int.MaxValue;
                    numericUpDown.Minimum = int.MinValue;
                    numericUpDown.DecimalPlaces = 0;
                    numericUpDown.Increment = 1;
                    numericUpDown.Value = (int)(PropertyEditable.GetProperty(PropertyName));
                    numericUpDown.ValueChanged += NumericUpDown_ValueChanged_Int;
                    numericUpDown.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) CommitChanges(); };
                    numericUpDown.LostFocus += (o, e) => CommitChanges();
                    PropertyValueEditor.Controls.Add(numericUpDown);
                    numericUpDown.Dock = DockStyle.Fill;
                    break;
                case SrcPropertyType.Float:
                    numericUpDown = new NumericUpDown();
                    numericUpDown.DecimalPlaces = 5;
                    numericUpDown.Increment = .1M;
                    numericUpDown.Minimum = decimal.MaxValue;
                    numericUpDown.Minimum = decimal.MinValue;
                    numericUpDown.Value = (decimal)(float)(PropertyEditable.GetProperty(PropertyName));
                    numericUpDown.ValueChanged += NumericUpDown_ValueChanged_Float;
                    numericUpDown.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) CommitChanges(); };
                    numericUpDown.LostFocus += (o, e) => CommitChanges();
                    PropertyValueEditor.Controls.Add(numericUpDown);
                    numericUpDown.Dock = DockStyle.Fill;
                    break;
                case SrcPropertyType.Bool:
                    checkbox = new CheckBox();
                    checkbox.Checked = (bool)(PropertyEditable.GetProperty(PropertyName));
                    checkbox.CheckStateChanged += Checkbox_CheckStateChanged;
                    PropertyValueEditor.Controls.Add(checkbox);
                    checkbox.Dock = DockStyle.Fill;
                    break;
                case SrcPropertyType.Vector2:
                    Vector2Editor vector2Editor = new Vector2Editor(
                        (Vector2)(PropertyEditable.GetProperty(PropertyName)),
                        (v2) =>
                        {
                            PropertyEditable.SetProperty(PropertyName, v2);
                            valueChanged = true;
                        },
                        () => CommitChanges());
                    PropertyValueEditor.Controls.Add(vector2Editor);
                    vector2Editor.Dock = DockStyle.Fill;
                    break;
                case SrcPropertyType.Vector3:
                    Vector3Editor vector3Editor = new Vector3Editor(
                        (Vector3)(PropertyEditable.GetProperty(PropertyName)),
                        (v3) =>
                        {
                            PropertyEditable.SetProperty(PropertyName, v3);
                            valueChanged = true;
                        },
                        () => CommitChanges());
                    PropertyValueEditor.Controls.Add(vector3Editor);
                    vector3Editor.Dock = DockStyle.Fill;
                    break;
                case SrcPropertyType.Color:
                    ColorEditor colorEditor = new ColorEditor(
                        (Color)(PropertyEditable.GetProperty(PropertyName)),
                        (c) =>
                        {
                            PropertyEditable.SetProperty(PropertyName, c);
                            valueChanged = true;
                        },
                        () => CommitChanges());
                    PropertyValueEditor.Controls.Add(colorEditor);
                    colorEditor.Dock = DockStyle.Fill;
                    break;
                case SrcPropertyType.EntityReferance:
                    if (preveiw is MapEditorPreview)
                    {
                        textBox = new TextBox();
                        textBox.Text = (EntityReference)(PropertyEditable.GetProperty(PropertyName));
                        textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        textBox.GotFocus += TextBox_EntityNames_GotFocus;
                        textBox.TextChanged += TextBox_TextChanged_ER;
                        textBox.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) CommitChanges(); };
                        textBox.LostFocus += (o, e) => CommitChanges();
                        PropertyValueEditor.Controls.Add(textBox);
                        textBox.Dock = DockStyle.Fill;
                    }
                    break;
                case SrcPropertyType.List:
                    button = new Button();
                    button.Text = $"Edit {(startingValue as List<IPropertyEditable>).Count} items";
                    button.Click += Button_List_Click;
                    PropertyValueEditor.Controls.Add(button);
                    button.Dock = DockStyle.Fill;
                    break;
                case SrcPropertyType.Misc:
                    button = new Button();
                    button.Text = "Edit";
                    button.Click += Button_Misc_Click;
                    PropertyValueEditor.Controls.Add(button);
                    button.Dock = DockStyle.Fill;
                    break;
                default:
                    break;
            }
        }

        private void CommitChanges()
        {
            if (CanCommitChanges)
            {
                object newValue = PropertyEditable.GetProperty(PropertyName);

                if (valueChanged)
                {
                    valueChanged = false;

                    if (newValue != startingValue)
                    {
                        preveiw.DoAction(
                            () => PropertyEditable.SetProperty(PropertyName, newValue),
                            () => PropertyEditable.SetProperty(PropertyName, startingValue));
                    }
                }
            }
        }

        private void TextBox_EntityNames_GotFocus(object sender, EventArgs e)
        {
            var tb = (sender as TextBox);
            tb.AutoCompleteCustomSource.Clear();
            tb.AutoCompleteCustomSource
                .AddRange((preveiw as MapEditorPreview).EntityNames);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            PropertyEditable.SetProperty(PropertyName, (sender as TextBox).Text);
            valueChanged = true;
        }

        private void NumericUpDown_ValueChanged_Int(object sender, EventArgs e)
        {
            PropertyEditable.SetProperty(PropertyName, (int)((decimal)((sender as NumericUpDown).Value)));
            valueChanged = true;
        }

        private void NumericUpDown_ValueChanged_Float(object sender, EventArgs e)
        {
            PropertyEditable.SetProperty(PropertyName, (float)((decimal)((sender as NumericUpDown).Value)));
            valueChanged = true;
        }

        private void Checkbox_CheckStateChanged(object sender, EventArgs e)
        {
            PropertyEditable.SetProperty(PropertyName, (sender as CheckBox).Checked);
            valueChanged = true;
            CommitChanges();
        }

        private void TextBox_TextChanged_ER(object sender, EventArgs e)
        {
            PropertyEditable.SetProperty(PropertyName, (EntityReference)((sender as TextBox).Text));
            valueChanged = true;
        }

        private void Button_List_Click(object sender, EventArgs e)
        {
            var schema = PropertyEditable.GetAllProperties()[PropertyName].SchemaType;

            var editables
                = (PropertyEditable.GetProperty(PropertyName)
                    as IEnumerable).Cast<IPropertyEditable>().ToList();

            PropertyListEditorDialog.Show(editables, schema, preveiw,
                out IPropertyEditable[] edited);

            if (editables.Count != (startingValue as List<IPropertyEditable>).Count)
            {
                valueChanged = true;
            }
            else
            {
                for (int i = 0; i < editables.Count; i++)
                {
                    if(editables[i] != (startingValue as List<IPropertyEditable>)[i])
                    {
                        valueChanged = true;
                        break;
                    }
                }
            }
            PropertyEditable.SetProperty(PropertyName, edited.ToList());

            CommitChanges();
        }


        private void Button_Misc_Click(object sender, EventArgs e)
        {
            var props
                = PropertyEditable.GetProperty(PropertyName)
                as Dictionary<string, object>;

            var schema = PropertyEditable.GetAllProperties()[PropertyName].SchemaType;

            PropertyEditorDialog.Show(
                new SchemaEditable(schema, props),
                preveiw);
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
