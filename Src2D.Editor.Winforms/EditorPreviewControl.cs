using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src2D.Editor.Winforms
{
    public abstract class EditorPreviewControl<T> : MonoGameControl
        where T : EditorPreveiw, new()
    {
        public T EditorPreveiw { get => editorPreveiw; }
        private T editorPreveiw = new T();

        protected override void Initialize()
        {
            base.Initialize();
            editorPreveiw.ContentManager = Editor.Content;
            EditorPreveiw.Start();
        }

        protected override void Update(GameTime gameTime)
        {
            EditorPreveiw.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();
            EditorPreveiw.Draw(Editor.spriteBatch);
            Editor.spriteBatch.End();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            EditorPreveiw.End();
            Parent?.Controls.Remove(this);
            base.OnHandleDestroyed(e);
        }
    }
}
