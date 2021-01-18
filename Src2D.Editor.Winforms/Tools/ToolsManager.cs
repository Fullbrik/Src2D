using Src2D.Attributes;
using Src2D.Data;
using Src2D.Editor.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms.Tools
{
    public static class ToolsManager
    {
        public static void Open(string file, ContentFile content)
        {
            string ext = Path.GetExtension(file);
            SrcAssetType assetType = AssetData.GetSrcAssetTypeFor(ext);

            var tools = ToolAttribute.Get(assetType);

            if (tools.Length > 0)
            {
                if (tools.Length == 1)
                {
                    LaunchTool(tools[0].type, file, content);
                }
                else
                {
                    ShowDialog(tools, file, content);
                }
            }
        }

        private static void ShowDialog((Type type, ToolAttribute ta)[] tools, 
            string file, ContentFile content)
        {
            var dialog = new Form();
            var list = new ListView();
            list.MultiSelect = false;

            for (int i = 0; i < tools.Length; i++)
            {
                list.Items.Add(new ListViewItem(tools[i].ta.Name)
                {
                    Tag = tools[i].type
                });
            }

            dialog.Controls.Add(list);
            list.Dock = DockStyle.Fill;

            list.DoubleClick += (o, e) =>
            {
                if (list.SelectedItems.Count > 0)
                {
                    if (list.SelectedItems[0].Tag is Type toolType)
                    {
                        LaunchTool(toolType, file, content);
                    }
                }
            };

            dialog.ShowDialog();
        }

        private static void LaunchTool(Type toolType, 
            string file, ContentFile content)
        {
            if (toolType.TryExecuteConstructor(out object obj, file, content)
                        && obj is Form tool)
            {
                tool.Show();
            }
        }
    }
}
