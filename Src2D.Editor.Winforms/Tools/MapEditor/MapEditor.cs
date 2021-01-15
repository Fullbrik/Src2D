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

        private readonly List<EventHandler> GizmoShortcuts = new List<EventHandler>();

        private int currentGizmo = 0;
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
            preview.OnEntitiesChanged += Preview_OnEntitiesChanged;
            preview.OnSelectedEntityChanged += Preview_OnSelectedEntityChanged;
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
            HasPendingChanges = true;
            UpdateUndoAndRedoButtons();
        }

        private void MapPreview_OnUndoOrRedo(object sender, EventArgs e)
        {
            PropertyEditor.Entity = PropertyEditor.Entity;
            HasPendingChanges = true;
            UpdateUndoAndRedoButtons();
        }

        private void EntityList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is MapEditorEntity entity)
            {
                preview.Selected = entity;
            }
        }

        private void Preview_OnSelectedEntityChanged()
        {
            PropertyEditor.Entity = preview.Selected;
            ReloadGizmoList();
            if (currentGizmo < GizmoShortcuts.Count)
                GizmoShortcuts[currentGizmo](this, EventArgs.Empty);
            else
                currentGizmo = 0;
        }

        private void Preview_OnEntitiesChanged()
        {
            HasPendingChanges = true;
            ReloadEntityList();
        }

        private void MapEditor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    if (!e.Control && !e.Alt && !e.Shift && GizmoShortcuts.Count >= 1)
                        GizmoShortcuts[0](this, EventArgs.Empty);
                    break;
                case Keys.W:
                    if (!e.Control && !e.Alt && !e.Shift && GizmoShortcuts.Count >= 2)
                        GizmoShortcuts[1](this, EventArgs.Empty);
                    break;
                case Keys.E:
                    if (!e.Control && !e.Alt && !e.Shift && GizmoShortcuts.Count >= 3)
                        GizmoShortcuts[2](this, EventArgs.Empty);
                    break;
                case Keys.R:
                    if (!e.Control && !e.Alt && !e.Shift && GizmoShortcuts.Count >= 4)
                        GizmoShortcuts[3](this, EventArgs.Empty);
                    break;
                case Keys.T:
                    if (!e.Control && !e.Alt && !e.Shift && GizmoShortcuts.Count >= 5)
                        GizmoShortcuts[4](this, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Entity List Drag
        //Note: Most of this code was copied from MSDN docs, then modified for my needs.

        private void EntityList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void EntityList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void EntityList_DragOver(object sender, DragEventArgs e)
        {

        }

        private void EntityList_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = EntityList.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = EntityList.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (draggedNode.Tag is MapEditorEntity entity &&
                !draggedNode.Equals(targetNode))
            {
                preview.RearangeEntity(entity, targetNode.Index);
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

        #region Context Menu
        private void createEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity();
        }

        private void removeEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DestroyEntity();
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
            EntityList.ExpandAll();
        }

        public void ReloadGizmoList()
        {
            GizmoSelector.Items.Clear();
            GizmoShortcuts.Clear();

            if (preview.Selected != null)
            {
                {
                    //Add no gizmo button
                    var tsb = new ToolStripButton(Image.FromFile("EmptyBucket_16x.png"));
                    GizmoSelector.Items.Add(tsb);
                    EventHandler onClick = (o, e) =>
                    {
                        preview.Gizmo = null;
                        currentGizmo = 0;
                    };
                    GizmoShortcuts.Add(onClick);
                    tsb.Click += onClick;
                }

                //yes, I know what a for loop is. No, I'm not using one.
                int i = 1;
                foreach (var gizmoName in preview.Selected.Data.Gizmos)
                {
                    int gizmoNum = i;

                    string scriptFile = Path.Combine(
                                    Path.GetDirectoryName(Application.ExecutablePath),
                                    "Gizmos",
                                    gizmoName + ".js");
                    string imageFile = Path.Combine(
                                    Path.GetDirectoryName(Application.ExecutablePath),
                                    "Gizmos",
                                    gizmoName + ".png");

                    var tsb = new ToolStripButton(Image.FromFile(imageFile))
                    {
                        Tag = gizmoName,
                    };


                    EventHandler onClick = (o, e) =>
                    {
                        preview.Gizmo = new Gizmos.ScriptGizmo(preview.Selected,
                            preview.SpriteBatch.GraphicsDevice,
                            () => File.ReadAllText(scriptFile));
                        currentGizmo = gizmoNum;
                    };

                    GizmoShortcuts.Add(onClick);

                    tsb.Click += onClick;

                    GizmoSelector.Items.Add(tsb);

                    i++;
                }
            }
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
            if (EntitySelectionDialog.Show(out MapEntity entity) == DialogResult.OK)
            {
                preview.CreateEntity(entity);
            }
        }

        private void DestroyEntity()
        {
            if (preview.Selected != null)
                preview.DestroyEntity(preview.Selected);
        }

        #endregion

        #region Mouse and KeyboardEvents
        private void MapPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                preview.OnLeftMouseDown(new Microsoft.Xna.Framework.Point(e.X, e.Y));
            }
        }

        private void MapPreview_OnMouseWheelDownwards(MouseEventArgs e)
        {
            preview.MouseScroll(e.Delta);
        }

        private void MapPreview_OnMouseWheelUpwards(MouseEventArgs e)
        {
            preview.MouseScroll(e.Delta);
        }

        private void EntityList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            preview.MoveCameraToSelectedEntity();
        }
        #endregion
    }
}
