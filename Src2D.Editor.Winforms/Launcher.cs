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
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            RecentFilesList.Items.Clear();
            foreach (var file in RecentFiles.Instance)
            {
                RecentFilesList.Items.Add(file);
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = Strings.GameInfoFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;

                dialog.Dispose();

                RecentFiles.Instance.Add(fileName);
                OpenFile(fileName);
            }
            else
            {
                dialog.Dispose();
            }

        }

        private void RecentFilesList_DoubleClick(object sender, EventArgs e)
        {
            var selected = RecentFilesList.SelectedItem;

            if (selected != null)
            {
                OpenFile(selected.ToString());
            }
        }

        private void OpenFile(string fileName)
        {
            DatasheetBuilderCaller.Call(fileName, "Debug");

            ToolLauncher launcher = new ToolLauncher(fileName);
            launcher.ShowDialog();
            Close();
            //Close();
        }
    }
}
