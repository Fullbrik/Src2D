using Src2D.Editor.Previews;
using Src2D.Editor.SchemaData;
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
    public partial class PropertyListEditorDialog : Form
    {
        public static DialogResult Show(
            List<IPropertyEditable> propertyEditables,
            string schema,
            EditorPreview preview,
            out IPropertyEditable[] editedPropertyEditables)
        {
            using (var dialog = new PropertyListEditorDialog(
                propertyEditables,
                schema,
                preview))
            {
                var result = dialog.ShowDialog();

                editedPropertyEditables = dialog.propertyEditables.ToArray();

                return result;
            }
        }
        
        private List<IPropertyEditable> propertyEditables;
        private EditorPreview preview;
        private string schema;

        public PropertyListEditorDialog(
            List<IPropertyEditable> propertyEditables,
            string schema,
            EditorPreview preview)
        {
            InitializeComponent();
            this.propertyEditables = propertyEditables;
            this.schema = schema;
            this.preview = preview;
        }

        private void PropertyListEditorDialog_Load(object sender, EventArgs e)
        {
            PropEditor.CanCommitChnages = false;
            RefreshList();
        }

        private void RefreshList()
        {
            ListItems.Clear();
            for (int i = 0; i < propertyEditables.Count; i++)
            {
                ListItems.Items.Add(new ListViewItem($"Item {i}")
                {
                    Tag = propertyEditables[i]
                });
            }
        }

        private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListItems.SelectedItems.Count > 0
                && ListItems.SelectedItems[0].Tag is IPropertyEditable propertyEditable)
            {
                PropEditor.PropertyEditable = propertyEditable;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            IPropertyEditable pe = new SchemaEditable(schema, new Dictionary<string, object>());
            propertyEditables.Add(pe);
            RefreshList();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ListItems.SelectedItems.Count > 0
                && ListItems.SelectedItems[0].Tag is IPropertyEditable propertyEditable)
            {
                var pe = propertyEditable;
                propertyEditables.Remove(pe);
                ListItems.SelectedItems.Clear();
                RefreshList();
            }
        }

        private void PropertyListEditorDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
