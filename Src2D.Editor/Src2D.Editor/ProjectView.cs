using System;
using Eto.Forms;
using Eto.Drawing;
using System.IO;
using Src2D.Data;
using Newtonsoft.Json;
using Src2D.Editor.Tools;

namespace Src2D.Editor
{
    public partial class ProjectView : Form
    {
        public string ProjectFile { get; }
        public string ProjectDirectory { get; }

        public GameInfo GameInfo { get => gameInfo; }
        private GameInfo gameInfo;

        public ProjectView(string projectFile)
        {
            InitializeComponent();

            ProjectFile = projectFile;
            ProjectDirectory = Path.GetDirectoryName(projectFile);

            Load += ProjectView_Load;

            ContentBrowser.OpenFile += ContentBrowser_OpenFile;
        }

        private void ProjectView_Load(object sender, EventArgs e)
        {
            LoadGameInfo();
        }

        private void LoadGameInfo()
        {
            var text = File.ReadAllText(ProjectFile);
            gameInfo = JsonConvert.DeserializeObject<GameInfo>(text);

            ContentBrowser.ContentFolder = Path.Combine(ProjectDirectory, GameInfo.ContentFolder);
            ContentBrowser.Refresh();
        }

        private void ContentBrowser_OpenFile(object sender, ContentManager.ContentFileOpenEventArgs e)
        {
            ToolLauncher.LaunchTool(e.FileName);
        }
    }
}
