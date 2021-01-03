using Newtonsoft.Json;
using Src2D.Data;
using Src2D.Editor.Content;
using Src2D.Editor.EnityData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms
{
    public partial class ToolLauncher : Form
    {
        private string rootFolder;
        public GameInfo GameInfo { get => gameInfo; }
        private GameInfo gameInfo;

        public ContentFile Content { get => content; }
        private ContentFile content;

        public ToolLauncher(string gameInfoFile)
        {
            InitializeComponent();
            LoadGameInfo(gameInfoFile);
        }

        private void LoadGameInfo(string fileName)
        {
            if (File.Exists(fileName))
            {
                rootFolder = Path.GetDirectoryName(fileName);

                string text = File.ReadAllText(fileName);
                gameInfo = JsonConvert.DeserializeObject<GameInfo>(text);

                string eds = Path.Combine(rootFolder, gameInfo.DataSheetDirectory, "Enities.ds");
                text = File.ReadAllText(eds);
                EntityDataSheetManager.CurrentSheet = JsonConvert.DeserializeObject<EntityDataSheet>(text);
            }
            else
            {
                throw new Exception($"Couldn't find game info file ${fileName}");
            }
        }

        private void ToolLauncher_Load(object sender, EventArgs e)
        {
            string contentFolder = Path.Combine(rootFolder, gameInfo.ContentFolder);

            if (!File.Exists(contentFolder + "\\Content.mgcb")) throw new Exception($"Could not find content file at folder {contentFolder}. Please make sure there is a Content.mgcb in it's root.");

            string[] contentLines = File.ReadAllLines(contentFolder + "\\Content.mgcb");
            content = ContentFile.Parse(contentLines, contentFolder);

            ContentBrowser.InitializeContent(Content);
        }

        private void ContentBrowser_OnDoubleClickFile(object sender, ContentItemSelectEventArgs e)
        {
            Tools.Open(e.Item.FileName, Content);
        }
    }
}
