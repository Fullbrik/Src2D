using Src2D.Attributes;
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

namespace Src2D.Editor.Winforms.ContentBrowser
{
    public partial class ContentBrowserDialog : Form
    {
        public static DialogResult Show(ContentFile content,
            out string asset,
            params SrcAssetType[] allowedAssetTypes)
        {
            var dialog = new ContentBrowserDialog(content, allowedAssetTypes);
            var result = dialog.ShowDialog();
            asset = dialog.asset;
            return result;
        }

        private string asset;

        public ContentBrowserDialog(ContentFile content, params SrcAssetType[] allowedAssetTypes)
        {
            InitializeComponent();
            if (allowedAssetTypes.Length > 0)
            {
                CB.UseFilter = true;
                CB.AllowedTypes = allowedAssetTypes;
            }
            CB.InitializeContent(content);
        }

        private void CB_OnDoubleClickFile(object sender, ContentItemSelectEventArgs e)
        {
            asset = e.Item.FileName;
            DialogResult = DialogResult.OK;
        }
    }
}
