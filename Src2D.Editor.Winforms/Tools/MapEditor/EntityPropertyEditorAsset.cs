using Src2D.Editor.Content;
using Src2D.Editor.EnityData;
using Src2D.Editor.Previews.MapEditor;
using Src2D.Editor.Winforms.ContentBrowser;
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
    public partial class EntityPropertyEditorAsset : UserControl
    {
        public string Description { get; }

        MapEditorPreview preveiw;
        public MapEditorEntity Entity { get; }
        public string AssetName { get; }
        public SrcAssetType AssetType { get; }
        public ContentFile ContentFile { get; }

        public event EventHandler OnShowDescription;

        public EntityPropertyEditorAsset(MapEditorPreview preveiw, ContentFile contentFile, string name, DataSheetAsset asset, MapEditorEntity entity)
        {
            InitializeComponent();

            this.preveiw = preveiw;
            ContentFile = contentFile;
            Entity = entity;
            AssetType = asset.AssetType;
            AssetName = name;
            Description = asset.Description;
        }

        private void EntityPropertyEditorAsset_Load(object sender, EventArgs e)
        {
            PropertyName.Text = AssetName + ":";
            AssetNameText.Text = Entity.GetAsset(AssetName);
            Invalidate();
        }

        private void BrowsButton_Click(object sender, EventArgs e)
        {
            if (ContentBrowserDialog.Show(ContentFile, out string asset, AssetType) == DialogResult.OK)
            {
                Entity.SetAsset(AssetName, asset);
                AssetNameText.Text = asset;
            }
        }

        private void EntityPropertyEditorAsset_MouseEnter(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.LightBlue;
            OnShowDescription?.Invoke(this, EventArgs.Empty);
        }

        private void EntityPropertyEditorAsset_MouseLeave(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.Transparent;
        }

        private void PropertyName_MouseEnter(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.LightBlue;
            OnShowDescription?.Invoke(this, EventArgs.Empty);
        }

        private void PropertyName_MouseLeave(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.Transparent;
        }
    }
}
