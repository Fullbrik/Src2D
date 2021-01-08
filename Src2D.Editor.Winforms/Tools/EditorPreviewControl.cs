﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using Src2D.Editor.Previews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src2D.Editor.Winforms.Tools
{
    public abstract class EditorPreviewControl<T> : MonoGameControl
        where T : EditorPreview, new()
    {
        public event EventHandler OnAction;
        public event EventHandler OnUndoOrRedo;

        public T EditorPreveiw { get => editorPreveiw; }
        private T editorPreveiw = new T();

        protected override void Initialize()
        {
            base.Initialize();
            editorPreveiw.ContentManager = Editor.Content;
            editorPreveiw.OnAction += () => OnAction?.Invoke(this, EventArgs.Empty);
            editorPreveiw.OnUndoOrRedo += () => OnUndoOrRedo?.Invoke(this, EventArgs.Empty);
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
