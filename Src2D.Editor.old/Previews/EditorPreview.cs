using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.Previews
{
    public abstract class EditorPreview
    {
        public event Action OnAction;
        public event Action OnUndoOrRedo;

        public bool CanUndo { get => UndoStack.Count > 0; }
        public bool CanRedo { get => RedoStack.Count > 0; }

        private readonly Stack<(Action action, Action undo)> UndoStack
            = new Stack<(Action action, Action undo)>();
        private readonly Stack<(Action action, Action undo)> RedoStack
            = new Stack<(Action action, Action undo)>();

        public ContentManager ContentManager { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        public Vector2 CameraPosition { get; set; }
        public Vector2 CameraScale { get; set; } = Vector2.One;

        public abstract void Start();

        public abstract void Update(MouseState mouseState, float deltaTime);
        public void Draw()
        {
            var vp = SpriteBatch.GraphicsDevice.Viewport;

            var baseTrans = Matrix.CreateTranslation(
                ((vp.Width / CameraScale.X) / 2f), ((vp.Height / CameraScale.Y) / 2f), 1);
            var trans = Matrix.CreateTranslation(CameraPosition.X, CameraPosition.Y, 0);
            var scal = Matrix.CreateScale(CameraScale.X, CameraScale.Y, 1);

            SpriteBatch.Begin(transformMatrix: baseTrans * trans * scal);
            Draw(SpriteBatch);
            SpriteBatch.End();
        }
        protected abstract void Draw(SpriteBatch spriteBatch);

        public abstract void End();

        public Point ScreenPositionToWorldPosition(Point screenPosition)
        {
            var vp = SpriteBatch.GraphicsDevice.Viewport;

            var baseTrans = Matrix.CreateTranslation(
                ((vp.Width / CameraScale.X) / 2f), ((vp.Height / CameraScale.Y) / 2f), 1);
            var trans 
                = Matrix.CreateTranslation(CameraPosition.X, CameraPosition.Y, 0);
            var scal = Matrix.CreateScale(CameraScale.X, CameraScale.Y, 1);

            var matrix = Matrix.Invert(baseTrans * trans * scal);

            Vector2 final = Vector2.Transform(screenPosition.ToVector2(), matrix);

            return final.ToPoint();
        }

        public void DoAction(Action action, Action undo)
        {
            RedoStack.Clear();
            action?.Invoke();
            UndoStack.Push((action, undo));
            OnAction?.Invoke();
        }

        public void Undo()
        {
            if (CanUndo)
            {
                var action = UndoStack.Pop();
                action.undo?.Invoke();
                RedoStack.Push(action);
                OnUndoOrRedo?.Invoke();
            }
        }

        public void Redo()
        {
            if (CanRedo)
            {
                var action = RedoStack.Pop();
                action.action?.Invoke();
                UndoStack.Push(action);
                OnUndoOrRedo?.Invoke();
            }
        }
    }
}
