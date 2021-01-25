using System;
using Eto.Forms;
using Eto.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace Src2D.Editor.Dialogs
{
    public partial class ItemSelectionDialog : Dialog
    {
        public DialogResult DialogResult
        {
            get => dialogResult;
            protected set
            {
                dialogResult = value;
                Close();
            }
        }
        private DialogResult dialogResult;
        public object Result { get; set; }

        private IEnumerable<object> items;
        private Func<object, string> toString;

        public ItemSelectionDialog(string title, IEnumerable<object> items) : this(title, null, items)
        {
        }

        public ItemSelectionDialog(string title, Func<object, string> toString, IEnumerable<object> items)
        {
            InitializeComponent();
            TitleLabel.Text = title;

            this.items = items;
            this.toString = toString ?? ((t) => t.ToString());

            Load += ItemSelectionDialog_Load;

            List.MouseDoubleClick += List_MouseDoubleClick;

            Cancel.Click += Cancel_Click;
        }

        public ItemSelectionDialog(string title, params string[] items) : this(title, null, items)
        {

        }

        private void ItemSelectionDialog_Load(object sender, EventArgs e)
        {
            foreach (var item in items)
            {
                List.Items.Add(new ListItem()
                {
                    Text = toString(item),
                    Tag = item
                });
            }
        }

        private void List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (List.SelectedIndex >= 0
                && List.Items[List.SelectedIndex] is ListItem listItem
                && listItem.Tag is object obj)
            {
                Result = obj;
                DialogResult = DialogResult.Ok;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
