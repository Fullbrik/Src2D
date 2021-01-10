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

namespace Src2D.Editor.Previews.MapEditor
{
    public class MapEditorPreview : EditorPreview
    {
        #region Props
        public bool IsLoaded { get => isLoaded; }
        private bool isLoaded;

        public string[] EntityNames
        {
            get => Entities.Select(e => e.Name).ToArray();
        }
        #endregion

        #region Fields
        public readonly List<MapEditorEntity> Entities = new List<MapEditorEntity>();
        public event Action OnEntitiesChanged;
        #endregion

        #region Life Cycle
        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsLoaded)
            {
                Entities.ForEach(entity =>
                {
                    if (entity.SpritePreview != null)
                    {
                        Vector2 spriteSize = new Vector2(entity.SpritePreview.Width, entity.SpritePreview.Height);

                        spriteBatch.Draw(
                            entity.SpritePreview,
                            entity.Position,
                            null,
                            Color.White,
                            MathHelper.ToRadians(entity.Rotation),
                            entity.Origin * spriteSize,
                            entity.Scale,
                            SpriteEffects.None,
                            0);
                    }
                });
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
            if(Entities.Remove(entity))
            {
                if(newIndex >= Entities.Count)
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

        public void ReloadAssets()
        {
            isLoaded = false;
            ContentManager.Unload();
            Entities.ForEach(ent => ent.ReloadAssets(ContentManager));
            isLoaded = true;
        }
    }
}
