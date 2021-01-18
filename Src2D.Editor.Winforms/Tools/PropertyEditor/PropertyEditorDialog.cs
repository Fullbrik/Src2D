using Src2D.Editor.Previews;
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
    public partial class PropertyEditorDialog : Form
    {
        public static DialogResult Show(IPropertyEditable propertyEditable, EditorPreview preview)
        {
            using (var dialog = new PropertyEditorDialog(
                propertyEditable,
                preview))
            {
                var result = dialog.ShowDialog();

                return result;
            }
        }

        Dictionary<string, object> startingValues = new Dictionary<string, object>();
        private IPropertyEditable propertyEditable;
        private EditorPreview preview;

        public PropertyEditorDialog(
            IPropertyEditable propertyEditable,
            EditorPreview preview)
        {
            InitializeComponent();
            this.propertyEditable = propertyEditable;
            this.preview = preview;
        }

        private void PropertyEditorDialog_Load(object sender, EventArgs e)
        {
            PropEdit.Preview = preview;
            PropEdit.CanCommitChnages = false;
            PropEdit.PropertyEditable = propertyEditable;

            PopulateStartingValues();
        }

        private void PopulateStartingValues()
        {
            var allProps = propertyEditable.GetAllProperties();
            foreach (var value in allProps)
            {
                startingValues
                    .Add(value.Key, propertyEditable.GetProperty(value.Key));
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            
        }

        private void PropertyEditorDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool hasChangedAnything = false;

            Dictionary<string, object> newValues = new Dictionary<string, object>();
            var allProps = propertyEditable.GetAllProperties();
            foreach (var value in allProps)
            {
                var newVal = propertyEditable.GetProperty(value.Key);
                if (hasChangedAnything || startingValues[value.Key] != newVal)
                {
                    hasChangedAnything = true;
                    newValues
                        .Add(value.Key, newVal);
                }
            }

            if (hasChangedAnything)
            {
                preview.DoAction(() =>
                {
                    foreach (var value in allProps)
                    {
                        propertyEditable
                            .SetProperty(value.Key, newValues[value.Key]);
                    }
                },
                () =>
                {
                    foreach (var value in allProps)
                    {
                        propertyEditable
                            .SetProperty(value.Key, startingValues[value.Key]);
                    }
                });
            }
        }
    }
}
