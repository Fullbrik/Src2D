using Eto.Drawing;
using Eto.Forms;
using System;

namespace Src2D.Editor
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();

            Load += Launcher_Load;

            RecentFilesList.MouseDoubleClick += RecentFilesList_MouseDoubleClick;

            NewButton.Click += NewButton_Click;
            OpenButton.Click += OpenButton_Click;
        }

        private void RecentFilesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (RecentFilesList.SelectedIndex >= 0)
            {
                OpenProject(RecentFilesList.Items[RecentFilesList.SelectedIndex].Text);
            }
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
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
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filters.Add(new FileFilter("Src2D Game", ".src2d"));

                if (dialog.ShowDialog(this) == DialogResult.Ok)
                {
                    RecentFiles.Instance.Add(dialog.FileName);
                    OpenProject(dialog.FileName);
                }
            }
        }

        private void OpenProject(string file)
        {
            ShowInTaskbar = false;
            var projVeiw = new ProjectView(file);
            projVeiw.Closed += (o, e) => Close();
            projVeiw.Show();
            Minimize();
        }
    }
}
