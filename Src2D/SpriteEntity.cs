using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    [SrcEntity("Sprite", Gizmos = "Position2d|Rotation1d|Scale2d", Description = "A sprite with a position and rotation")]
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

            Vector2 spriteSize = new Vector2(Sprite.Value.Width, Sprite.Value.Height);

            SpriteEffects effect = SpriteEffects.None;
            if(FlipX) effect |= SpriteEffects.FlipHorizontally;
            if(FlipY) effect |= SpriteEffects.FlipVertically;

            spriteBatch.Draw(Sprite, Position, null, Color, MathHelper.ToRadians(Rotation), Origin * spriteSize, Scale, effect, 0);
        }
    }
}
