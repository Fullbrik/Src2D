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

namespace Src2D.Editor.Winforms.Tools.MapEditor
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
                SetupBindingsList();
            }
            else
            {
                PropertyList.RowCount = 1;
                AssetList.RowCount = 1;
                BindingsList.Items.Clear();
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
                entityPropertyEditorProperty.OnShowDescription
                    += EntityPropertyEditorProperty_OnShowDescription;
                PropertyList.Controls.Add(entityPropertyEditorProperty);
            }
        }

        private void EntityPropertyEditorProperty_OnShowDescription(object sender, EventArgs e)
        {
            DescriptionGB.Text = $"Description: ({(sender as EntityPropertyEditorProperty).PropertyName})";
            DescriptionText.Text =
                (sender as EntityPropertyEditorProperty).Description;
        }

        private void SetupAssetList()
        {
            AssetList.RowCount = Entity.Data.Assets.Count;

            foreach (var asset in Entity.Data.Assets)
            {
                EntityPropertyEditorAsset entityPropertyEditorAsset
                    = new EntityPropertyEditorAsset(Preview, ContentFile, asset.Key, asset.Value, Entity);
                entityPropertyEditorAsset.OnShowDescription
                    += EntityPropertyEditorAsset_OnShowDescription;
                AssetList.Controls.Add(entityPropertyEditorAsset);
            }
        }

        private void EntityPropertyEditorAsset_OnShowDescription(object sender, EventArgs e)
        {
            DescriptionGB.Text = $"Description: ({(sender as EntityPropertyEditorAsset).AssetName})";
            DescriptionText.Text =
                (sender as EntityPropertyEditorAsset).Description;
        }

        private void SetupBindingsList()
        {
            BindingsList.Items.Clear();
            Entity.Bindings.ForEach(bind =>
            {
                BindingsList.Items.Add(new ListViewItem(
                    $"{bind.EventName} -> {bind.OtherEntityName}.{bind.ActionName}")
                {
                    Tag = bind
                });
            });
        }

        private void BindingsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (BindingsList.SelectedItems.Count > 0)
            {
                if (BindingsList.SelectedItems[0].Tag is MapPreviewBinding binding)
                {
                    using (var dialog = new BindingEditorDialog(entity, binding, Preview))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            Invalidate();
                        }
                    }
                }
            }
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);

            if (Entity != null)
                SetupBindingsList();
        }
    }
}
