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
    public partial class EntityPropertyEditor : UserControl
    {
        public MapEditorEntity Entity
        {
            get => entity;
            set
            {
                entity = value;
                SetupPropertyList();
            }
        }
        private MapEditorEntity entity;

        public EntityPropertyEditor()
        {
            InitializeComponent();
        }

        private void SetupPropertyList()
        {
            PropertyList.SuspendLayout();
            PropertyList.Controls.Clear();

            if (Entity != null)
            {
                PropertyList.RowCount = Entity.Data.Properties.Count;

                foreach (var property in Entity.Data.Properties)
                {
                    EntityPropertyEditorProperty entityPropertyEditorProperty
                        = new EntityPropertyEditorProperty(property.Key, property.Value, Entity);
                    PropertyList.Controls.Add(entityPropertyEditorProperty);
                }
            }
            else
            {
                PropertyList.RowCount = 1;
            }
            PropertyList.ResumeLayout();
        }
    }
}
