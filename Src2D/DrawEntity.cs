using Microsoft.Xna.Framework.Graphics;
using Src2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    [SrcEntity("Draw", Description = "An entity that updates every frame and draws something to the screen")]
    public class DrawEntity : UpdateEnity, IDraw2DEntity
    {
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
