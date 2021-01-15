using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using mgi = Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using Src2D.Editor.Previews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms.Tools
{
    public abstract class EditorPreviewControl<T> : MonoGameControl
        where T : EditorPreview, new()
    {
        public event EventHandler OnAction;
        public event EventHandler OnUndoOrRedo;

        public T EditorPreveiw { get => editorPreveiw; }
        private T editorPreveiw = new T();

        private MouseState mouseState = new MouseState();

        protected override void Initialize()
        {
            base.Initialize();
            editorPreveiw.ContentManager = Editor.Content;
            editorPreveiw.SpriteBatch = Editor.spriteBatch;
            editorPreveiw.OnAction += () => OnAction?.Invoke(this, EventArgs.Empty);
            editorPreveiw.OnUndoOrRedo += () => OnUndoOrRedo?.Invoke(this, EventArgs.Empty);
            EditorPreveiw.Start();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            mgi.ButtonState isMBDown(MouseButtons mb)
            {
                return e.Button.HasFlag(mb)? 
                    mgi.ButtonState.Pressed : mgi.ButtonState.Released;
            }

            mouseState = new MouseState(e.X, e.Y, 
                e.Delta, 
                isMBDown(MouseButtons.Left), 
                isMBDown(MouseButtons.Middle),
                isMBDown(MouseButtons.Right),
                isMBDown(MouseButtons.XButton1),
                isMBDown(MouseButtons.XButton2));

        }

        protected override void Update(GameTime gameTime)
        {
            EditorPreveiw.Update(mouseState, (float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            EditorPreveiw.Draw();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            EditorPreveiw.End();
            Parent?.Controls.Remove(this);
            base.OnHandleDestroyed(e);
        }
    }
}
