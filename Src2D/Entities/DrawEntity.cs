using Microsoft.Xna.Framework.Graphics;
using Src2D.Attributes;
using Src2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Entities
{
    public class DrawEntity : UpdateEnity, IDraw2DEntity
    {
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
