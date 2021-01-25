using System;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor.Dialogs
{
    partial class ItemSelectionDialog : Dialog
    {
        private Label TitleLabel;

        private ListBox List;
        private Button Cancel;

        void InitializeComponent()
        {
            Title = "Select one";
            Padding = 5;

            Content = new StackLayout
            {
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                Items =
                {
                    new Label()
                    {
                        Text = "Select an item: ",
                        Font = new Font(SystemFont.Bold, 20)
                    }.Export(out TitleLabel),
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
