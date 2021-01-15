using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Shapes
{
    public static class Extensions
    {
        public static void DrawShape(this SpriteBatch spriteBatch, Shape2D shape, Vector2 position, float rotation, Vector2 scale, Color color)
        {
            shape.Draw(spriteBatch, position, rotation, scale, color);
        }
    }
}
