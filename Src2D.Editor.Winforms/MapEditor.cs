using Src2D.Editor.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Src2D.Data;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Xna.Framework.Graphics;
using Src2D.Editor.EnityData;

namespace Src2D.Editor.Winforms
{
    public partial class MapEditor : Form
    {
        private MapEditorPreveiw preview;

        private ContentFile content;

        public string LevelFile { get => levelFile; }
        private string levelFile;

        public MapEditor(string levelFile, ContentFile content)
        {
            InitializeComponent();

            this.content = content;
            this.levelFile = levelFile;

            Text = $"Map Editor - {levelFile}";

            ContentBrowser.InitializeContent(content);
            preview = MapPreview.EditorPreveiw;
        }

        private async void LevelEditor_Load(object sender, EventArgs e)
        {
            Map map = new Map();

            await Task.Run(() =>
            {
                var text = File.ReadAllText(Path.Combine(content.ContentFolder, levelFile));
                map = JsonConvert.DeserializeObject<Map>(text);
            });

            preview.LoadMap(map, out string[] errors, content);
            foreach (var error in errors)
            {
                MessageBox.Show(error, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ReloadEntityList();
        }

        public void ReloadEntityList()
        {
            EntityList.Nodes.Clear();
            TreeNode root = new TreeNode("Entities");

            preview.Entities.ForEach(entity =>
            {
                TreeNode entNode = new TreeNode($"{entity.Name} ({entity.EntityType})")
                {
                    Tag = entity
                };
                entity.OnNameChanged += (n) => entNode.Text = $"{n} ({entity.EntityType})";
                root.Nodes.Add(entNode);
            });

            EntityList.Nodes.Add(root);
        }

        private void EntityList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag is MapEditorEntity entity)
            {
                PropertyEditor.Entity = entity;
            }
        }
    }
}
