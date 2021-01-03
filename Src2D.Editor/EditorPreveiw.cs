using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor
{
    public abstract class EditorPreveiw
    {
        public ContentManager ContentManager { get; set; }

        public abstract void Start();

        public abstract void Update(float deltaTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void End();
    }
}
