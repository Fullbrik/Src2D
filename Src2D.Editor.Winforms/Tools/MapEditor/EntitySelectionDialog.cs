using Src2D.Data;
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

namespace Src2D.Editor.Winforms.Tools.MapEditor
{
    public partial class EntitySelectionDialog : Form
    {
        public static DialogResult Show(out MapEntity entity)
        {
            using (var dialog = new EntitySelectionDialog())
            {
                var result = dialog.ShowDialog();
                entity = dialog.Entity;
                return result;
            }
        }

        public MapEntity Entity { get; set; }

        public EntitySelectionDialog()
        {
            InitializeComponent();
        }

        private void EnitySelectionDialog_Load(object sender, EventArgs e)
        {
            foreach (var entity in EntityDataSheetManager.CurrentSheet.Entities)
            {
                listView1.Items.Add(new ListViewItem(entity.Key)
                {
                    Tag = entity.Value,
                    ToolTipText = entity.Value.Description,
                });
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0
                && listView1.SelectedItems[0].Tag is DataSheetEntity dse)
            {
                Entity = dse.ToMapEntity(listView1.SelectedItems[0].Text);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
