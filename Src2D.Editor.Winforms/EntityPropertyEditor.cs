using Src2D.Editor.Content;
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
                if (entity != null) entity.OnNameChanged -= Entity_OnNameChanged;
                entity = value;
                SetupEntity();
            }
        }

        public MapEditorPreveiw Preview { get; set; }
        public ContentFile ContentFile { get; set; }

        private MapEditorEntity entity;

        public EntityPropertyEditor()
        {
            InitializeComponent();
        }

        private void SetupEntity()
        {
            PropertyList.SuspendLayout();
            PropertyList.Controls.Clear();
            AssetList.SuspendLayout();
            AssetList.Controls.Clear();

            if (Entity != null)
            {
                entity.OnNameChanged += Entity_OnNameChanged;
                Entity_OnNameChanged(entity.Name);

                SetupPropertyList();
                SetupAssetList();
            }
            else
            {
                PropertyList.RowCount = 1;
                AssetList.RowCount = 1;
            }
            PropertyList.ResumeLayout(true);
            AssetList.ResumeLayout(true);
        }

        private void Entity_OnNameChanged(string name)
        {
            EntityName.Text = $"{name} ({entity.EntityType}):";
        }

        private void SetupPropertyList()
        {
            PropertyList.RowCount = Entity.Data.Properties.Count;

            foreach (var property in Entity.Data.Properties)
            {
                EntityPropertyEditorProperty entityPropertyEditorProperty
                    = new EntityPropertyEditorProperty(Preview, property.Key, property.Value, Entity);
                PropertyList.Controls.Add(entityPropertyEditorProperty);
            }
        }

        private void SetupAssetList()
        {
            AssetList.RowCount = Entity.Data.Assets.Count;

            foreach (var asset in Entity.Data.Assets)
            {
                EntityPropertyEditorAsset entityPropertyEditorAsset
                    = new EntityPropertyEditorAsset(Preview, ContentFile, asset.Key, asset.Value, Entity);
                AssetList.Controls.Add(entityPropertyEditorAsset);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
