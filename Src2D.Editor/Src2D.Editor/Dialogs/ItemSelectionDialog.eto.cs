using System;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor.Dialogs
{
    partial class ItemSelectionDialog : Dialog
    {
        private ListBox List;
        private Button Cancel;

        void InitializeComponent()
        {
            Title = "Select";

            Content = new StackLayout
            {
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                Items =
                {
                    new ListBox()
                    {
                        Size = new Size(-1, -1)
                    }.Export(out List),
                    new Button()
                    {
                        Text = "Cancel",
                    }.Export(out Cancel)
                }
            };

        }
    }
}
