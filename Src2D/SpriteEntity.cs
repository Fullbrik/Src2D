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

        [SrcProperty("Position", Description = "The position of the sprite")]
        public virtual Vector2 Position { get; set; } = Vector2.Zero;
        [SrcProperty("Rotation", Description = "The rotation of the sprite")]
        public virtual float Rotation { get; set; }
        [SrcProperty("Scale", Description = "The scale of the sprite")]
        public virtual Vector2 Scale { get; set; } = Vector2.One;
        [SrcProperty("FlipX", Description = "Weather to flip the sprite sideways")]
        public virtual bool FlipX { get; set; }
        [SrcProperty("FlipY", Description = "Weather to flip the sprite up and down")]
        public virtual bool FlipY { get; set; }
        [SrcProperty("Origin", Description = "The origin of the sprite (where to rotate it from, from 0-1. Use .5 to rotate from the center)")]
        public virtual Vector2 Origin { get; set; } = new Vector2(.5f, .5f);
        [SrcProperty("Color", Description = "The color to tint the sprite. Set it to white for no tint")]
        public virtual Color Color { get; set; } = Color.White;

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
