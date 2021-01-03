using Microsoft.Xna.Framework.Graphics;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Src2D.Editor.EnityData;
using Src2D.Editor.Content;
using Microsoft.Xna.Framework;

namespace Src2D.Editor
{
    public class MapEditorPreveiw : EditorPreveiw
    {
        public readonly List<MapEditorEntity> Entities = new List<MapEditorEntity>();

        public bool IsLoaded { get => isLoaded; }
        private bool isLoaded;

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {
            //scene?.Update(deltaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsLoaded)
            {
                Entities.ForEach(entity =>
                {
                    if (entity.SpritePreveiw != null)
                    {
                        Vector2 spriteSize = new Vector2(entity.SpritePreveiw.Width, entity.SpritePreveiw.Height);

                        spriteBatch.Draw(
                            entity.SpritePreveiw,
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
                    Entities.Add(new MapEditorEntity(entity, ContentManager));
                }
                else
                {
                    errs.Add($"The entity {entity.EntityType} could not be created. It may have been deleted. The entity in question will be removed.");
                }
            }

            errors = errs.ToArray();
        }
    }
}
