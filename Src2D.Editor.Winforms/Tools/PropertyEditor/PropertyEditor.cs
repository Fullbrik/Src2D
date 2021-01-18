using Src2D.Data;
using Src2D.Editor.Previews;
using Src2D.Editor.Previews.MapEditor;
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
    public partial class PropertyEditor : UserControl
    {
        [Browsable(false)]
        public IPropertyEditable PropertyEditable
        {
            get => propertyEditable;
            set
            {
                propertyEditable = value;
                SetupPropertyList();
            }
        }
        IPropertyEditable propertyEditable;

        [Browsable(false)]
        public EditorPreview Preview { get; set; } = null;

        public bool CanCommitChnages { get; set; } = true;

        public PropertyEditor()
        {
            InitializeComponent();
            PropertyEditable = propertyEditable;
        }

        private void SetupPropertyList()
        {
            PropertyList.SuspendLayout();
            PropertyList.Controls.Clear();

            if (PropertyEditable != null)
            {
                var properties = propertyEditable.GetAllProperties();

                PropertyList.RowCount = properties.Count;

                foreach (var property in properties)
                {
                    PropertyEditorProperty entityPropertyEditorProperty
                        = new PropertyEditorProperty(
                            Preview, property.Key, property.Value, PropertyEditable, CanCommitChnages);
                    PropertyList.Controls.Add(entityPropertyEditorProperty);
                }
            }
            else
            {
                PropertyList.RowCount = 1;
            }

            PropertyList.ResumeLayout(true);
        }
    }
}
