using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Interfaces
{
    public interface IUpdateEntity
    {
        void Update(float deltaTime);
    }

    public interface IDraw2DEntity
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
