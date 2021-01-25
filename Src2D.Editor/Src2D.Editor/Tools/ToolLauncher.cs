using Eto.Forms;
using Src2D.Editor.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Src2D.Editor.Tools
{
    public static class ToolLauncher
    {
        public static void LaunchTool(string file)
        {
            var ext = Path.GetExtension(file);

            var tools = ToolAttribute.GetAllToolsForExtention(ext).ToArray();

            if (tools.Length == 1)
            {
                var tool = tools[0].Type;

                if (tool.TryExecuteConstructor(out object obj, file)
                    && obj is Form form)
                {
                    form.Show();
                }
            }
            else if (tools.Length > 1)
            {
                using (var dialog = new ItemSelectionDialog(
                    "Select a tool: ",
                    (tool) => ((ToolAttribute.Data)tool).Attr.Name, tools.Cast<object>()))
                {
                    dialog.ShowModal();
                    if (dialog.DialogResult == DialogResult.Ok
                        && (dialog.Result is ToolAttribute.Data tool))
                    {
                        if (tool.Type.TryExecuteConstructor(out object obj, file)
                            && obj is Form form)
                        {
                            form.Show();
                        }
                    }
                }
            }
        }
    }
}
