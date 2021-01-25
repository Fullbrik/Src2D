using System;
using Eto.Forms;
using Eto.Drawing;
using System.IO;
using Src2D.Data;
using Newtonsoft.Json;
using Src2D.Editor.Tools;
using Src2D.Editor.Dialogs;

namespace Src2D.Editor
{
    public partial class ProjectView : Form
    {
        private string projectFile;

        private Tuple<string, bool> currentSelectedNameAndIsDirectory;

        private ProjectView()
        {
            InitializeComponent();
        }

        public ProjectView(string projectFile)
        {
            InitializeComponent();

            this.projectFile = projectFile;

            Load += ProjectView_Load;

            ContentBrowser.SelectFile += ContentBrowser_SelectFile;
            ContentBrowser.OpenFile += ContentBrowser_OpenFile;

            NewCommand.Executed += NewCommand_Executed;
            ImportCommand.Executed += ImportCommand_Executed;
            DeleteCommand.Executed += DeleteCommand_Executed;
            RefreshCommand.Executed += RefreshCommand_Executed;
        }

        private void ProjectView_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(projectFile))
            {
                ProjectManager.LoadProject(projectFile);

                AssemblyManager.LoadAssembly(typeof(Src2DGame).Assembly);

                SelectConfig();

                ContentBrowser.Refresh(true, true);
            }
        }

        private void SelectConfig()
        {
            using (var confSelector = new ItemSelectionDialog("Select a configuration: ", ProjectManager.Configurations))
            {
                confSelector.ShowModal();
                if (confSelector.DialogResult == DialogResult.Ok)
                {
                    ProjectManager.LoadProjectAssembly(confSelector.Result.ToString());
                }
                else
                {
                    MessageBox.Show("You must select a configuration to load. If in doubt, choose Debug. If there is no debug, the you must be advanced enough to figure it out, or watched a bad tutorial. Never edit the .src2d file unless you know what you're doing.", MessageBoxType.Error);
                    SelectConfig();
                }
            }
        }

        private void ContentBrowser_OpenFile(object sender, ContentManager.ContentFileEventArgs e)
        {
            ToolLauncher.LaunchTool(e.FileName);
        }

        private void ContentBrowser_SelectFile(object sender, ContentManager.ContentFileEventArgs e)
        {
            currentSelectedNameAndIsDirectory = new Tuple<string, bool>(e.FileName, e.IsDirectory);
        }

        private void NewCommand_Executed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ImportCommand_Executed(object sender, EventArgs e)
        {
            if (Directory.Exists(ContentBrowser.CurrentDirectory))
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog(this) == DialogResult.Ok)
                    {
                        foreach (var file in dialog.Filenames)
                        {
                            var fileName = Path.GetFileName(file);
                            var newFile = Path.Combine(ContentBrowser.CurrentDirectory, fileName);
                            File.Copy(file, newFile);
                            ContentBrowser.Refresh(true, true);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please open a folder to import assets into.", MessageBoxType.Error);
            }
        }

        private void DeleteCommand_Executed(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(currentSelectedNameAndIsDirectory.Item1))
            {
                if (currentSelectedNameAndIsDirectory.Item2)
                {
                    if (Directory.Exists(currentSelectedNameAndIsDirectory.Item1))
                    {
                        Directory.Delete(currentSelectedNameAndIsDirectory.Item1, true);
                    }
                    else
                    {
                        goto Error;
                    }
                }
                else
                {
                    if (File.Exists(currentSelectedNameAndIsDirectory.Item1))
                    {
                        File.Delete(currentSelectedNameAndIsDirectory.Item1);
                    }
                    else
                    {
                        goto Error;
                    }
                }
            }
            else
            {
                goto Error;
            }

            ContentBrowser.Refresh(true, true);
            return;

            Error:
            MessageBox.Show("Please select a file or folder to delete it", MessageBoxType.Error);
        }

        private void RefreshCommand_Executed(object sender, EventArgs e)
        {
            ContentBrowser.Refresh(true, true);
        }
    }
}
