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
using Src2D.Editor.Previews.MapEditor;
using Src2D.Attributes;

namespace Src2D.Editor.Winforms.Tools.MapEditor
{
    [Tool("Map Editor", SrcAssetType.Map)]
    public partial class MapEditor : Form
    {
        #region Props
        public bool HasPendingChanges
        {
            get => hasPendingChanges;
            set
            {
                hasPendingChanges = value;

                Text = $"Map Editor - {levelFile}{(hasPendingChanges ? "*" : "")}";
            }
        }
        private bool hasPendingChanges;

        public string LevelFile { get => levelFile; }
        private string levelFile;
        #endregion

        #region Fields
        private MapEditorPreview preview;

        private ContentFile content;
        #endregion

        #region Life Cycle
        public MapEditor(string levelFile, ContentFile content)
        {
            InitializeComponent();

            this.content = content;
            this.levelFile = levelFile;

            HasPendingChanges = false;

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

            PropertyEditor.Preview = preview;
            PropertyEditor.ContentFile = content;

            ReloadEntityList();
            UpdateUndoAndRedoButtons();
        }
        #endregion

        #region Events
        private void MapPreview_OnAction(object sender, EventArgs e)
        {
            UpdateUndoAndRedoButtons();
        }

        private void MapPreview_OnUndoOrRedo(object sender, EventArgs e)
        {
            PropertyEditor.Entity = PropertyEditor.Entity;
            UpdateUndoAndRedoButtons();
        }

        private void EntityList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is MapEditorEntity entity)
            {
                PropertyEditor.Entity = entity;
            }
        }

        private void MapEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Y:
                        preview.Redo();
                        break;
                    case Keys.Z:
                        preview.Undo();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region ToolStripMenu
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preview.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preview.Redo();
        }
        #endregion

        #region Actions
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

        private void UpdateUndoAndRedoButtons()
        {
            undoToolStripMenuItem.Enabled = preview.CanUndo;
            redoToolStripMenuItem.Enabled = preview.CanRedo;
        }

        private void Save()
        {
            File.WriteAllText(Path.Combine(content.ContentFolder, levelFile),
                preview.Serialize());
            HasPendingChanges = false;
        }

        private void CreateEntity()
        {

        }
        #endregion

        private void createEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity();
        }
    }
}
