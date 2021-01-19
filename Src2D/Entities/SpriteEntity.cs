using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Src2D.Attributes;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Entities
{
    [Gizmo("Position2d")]
    [Gizmo("Rotation1d")]
    [Gizmo("Scale2d")]
    public class SpriteEntity : DrawEntity
    {
        [SrcAsset("Sprite", SrcAssetType.Texture2D, Description = "The sprite to render")]
        public Asset<Texture2D> Sprite = new Asset<Texture2D>();

        public override void PreCache()
        {
            base.PreCache();
            Sprite.Precache();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (Sprite.Value != null)
            {
                Vector2 spriteSize = new Vector2(Sprite.Value.Width, Sprite.Value.Height);

                SpriteEffects effect = SpriteEffects.None;
                if (FlipX) effect |= SpriteEffects.FlipHorizontally;
                if (FlipY) effect |= SpriteEffects.FlipVertically;

                spriteBatch.Draw(Sprite, Position, null, Color, MathHelper.ToRadians(Rotation), Origin * spriteSize, Scale, effect, 0);
            }
        }
    }
}
