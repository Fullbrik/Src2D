using Microsoft.Xna.Framework.Graphics;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Src2D.Editor.EnityData;
using Src2D.Editor.Content;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Src2D.Editor.Gizmos;
using Microsoft.Xna.Framework.Input;

namespace Src2D.Editor.Previews.MapEditor
{
    public class MapEditorPreview : EditorPreview
    {
        #region Props
        public bool IsLoaded { get => isLoaded; }
        private bool isLoaded;

        public MapEditorEntity Selected
        {
            get => selected;
            set
            {
                selected = value;
                Gizmo = null;
                OnSelectedEntityChanged?.Invoke();
            }
        }
        private MapEditorEntity selected;

        public Gizmo Gizmo
        {
            get => gizmo;
            set
            {
                if (gizmo != null) gizmo.Dispose();
                gizmo = value;
                if (gizmo != null) gizmo.Reload();
            }
        }
        private Gizmo gizmo = null;

        public string[] EntityNames
        {
            get => Entities.Select(e => e.Name).ToArray();
        }
        #endregion

        #region Fields
        public readonly List<MapEditorEntity> Entities = new List<MapEditorEntity>();
        public event Action OnEntitiesChanged;
        public event Action OnSelectedEntityChanged;

        private Point lastMousePosition = Point.Zero;
        #endregion

        #region Life Cycle
        public override void Start()
        {
            OnEntitiesChanged += MapEditorPreview_OnEntitiesChanged;
        }

        private void MapEditorPreview_OnEntitiesChanged()
        {
            if (!Entities.Contains(Selected))
            {
                Selected = null;
            }
        }

        public override void Update(MouseState mouseState, float deltaTime)
        {
            if (IsLoaded)
            {
                Gizmo?
                    .Update(
                        ScreenPositionToWorldPosition(mouseState.Position)
                        .ToVector2(),
                        mouseState.LeftButton == ButtonState.Pressed);

                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    var direction =
                        ScreenPositionToWorldPosition(mouseState.Position) - ScreenPositionToWorldPosition(lastMousePosition);
                    CameraPosition += direction.ToVector2();
                }
            }

            lastMousePosition = mouseState.Position;
        }

        public void OnLeftMouseDown(Point mousePosition)
        {
            if ((Gizmo == null || Gizmo.CurrentHandle == null))
            {
                MapEditorEntity nextEntity = null;

                mousePosition = ScreenPositionToWorldPosition(mousePosition);

                Entities.ForEach(entity =>
                {
                    if (entity.SpritePreview != null)
                    {
                        if (entity.IsInside(mousePosition.ToVector2()))
                        {
                            nextEntity = entity;
                        }
                    }
                });

                if (Selected != nextEntity)
                    Selected = nextEntity;
            }
        }

        public void MouseScroll(int amount)
        {
            CameraScale += CameraScale * amount * .001f;
            if(CameraScale.X <= 0) CameraScale = Vector2.Zero;
        }

        protected override void Draw(SpriteBatch spriteBatch)
        {
            if (IsLoaded)
            {
                MapEditorEntity[] ents = new MapEditorEntity[Entities.Count];
                Entities.CopyTo(ents);
                foreach (var entity in ents)
                {
                    if (entity.SpritePreview != null)
                    {
                        //Draw the outline
                        if (entity == Selected)
                        {
                            spriteBatch.Draw(
                                Selected.SpritePreview,
                                Selected.Position,
                                null,
                                Color.Black,
                                MathHelper.ToRadians(Selected.Rotation),
                                Selected.SpriteOrgin,
                                Selected.Scale * 1.01f,
                                SpriteEffects.None,
                                0);
                        }

                        //Draw main entity
                        spriteBatch.Draw(
                            entity.SpritePreview,
                            entity.Position,
                            null,
                            Color.White,
                            MathHelper.ToRadians(entity.Rotation),
                            entity.SpriteOrgin,
                            entity.Scale,
                            SpriteEffects.None,
                            0);
                    }
                }

                Gizmo?.Draw(spriteBatch);
            }
        }

        public override void End()
        {

        }
        #endregion

        #region Map Data and Loading
        public void LoadMap(Map map, out string[] errors, ContentFile content)
        {
            isLoaded = false;

            ContentManager.RootDirectory = content.ContentFolder + "\\" + content.OutputDir;

            PopulateEntities(map, out errors);

            isLoaded = true;
        }

        private void PopulateEntities(Map map, out string[] errors)
        {
            List<string> errs = new List<string>();

            for (int i = 0; i < map.Entities.Length; i++)
            {
                var entity = map.Entities[i];

                if (EntityDataSheetManager.CurrentSheet.Entities.ContainsKey(entity.EntityType))
                {
                    Entities.Add(new MapEditorEntity(this, entity, ContentManager));
                }
                else
                {
                    errs.Add($"The entity {entity.EntityType} could not be created. It may have been deleted. The entity in question will be removed.");
                }
            }

            errors = errs.ToArray();
        }

        public Map ToMap()
        {
            return new Map()
            {
                Entities = Entities.Select(ent => ent.ToMapEntity()).ToArray()
            };
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(ToMap());
        }
        #endregion

        #region Actions
        public void CreateEntity(MapEntity entity)
        {
            MapEditorEntity newEnt = new MapEditorEntity(this, entity, ContentManager);

            DoAction(() => AddEntity(newEnt), () => RemoveEntity(newEnt));
        }

        public void DestroyEntity(MapEditorEntity entity)
        {
            DoAction(() => RemoveEntity(entity), () => AddEntity(entity));
        }

        public void RearangeEntity(MapEditorEntity entity, int newIndex)
        {
            int oldIndex = Entities.IndexOf(entity);

            DoAction(
                () => MoveEntityToIndex(entity, newIndex),
                () => MoveEntityToIndex(entity, oldIndex));
        }
        #endregion

        #region Entity Actions Implementations
        private void AddEntity(MapEditorEntity entity)
        {
            Entities.Add(entity);

            OnEntitiesChanged?.Invoke();
        }

        private void RemoveEntity(MapEditorEntity entity)
        {
            Entities.Remove(entity);

            OnEntitiesChanged?.Invoke();
        }

        private void MoveEntityToIndex(MapEditorEntity entity, int newIndex)
        {
            if (Entities.Remove(entity))
            {
                if (newIndex >= Entities.Count)
                {
                    Entities.Add(entity);
                }
                else
                {
                    Entities.Insert(newIndex, entity);
                }

                OnEntitiesChanged?.Invoke();
            }
        }
        #endregion

        public void MoveCameraToSelectedEntity()
        {
            CameraPosition = (Selected != null)? -Selected.Position : Vector2.Zero;
        }

        public void ReloadAssets()
        {
            isLoaded = false;
            ContentManager.Unload();
            Entities.ForEach(ent => ent.ReloadAssets(ContentManager));
            isLoaded = true;
        }
    }
}
