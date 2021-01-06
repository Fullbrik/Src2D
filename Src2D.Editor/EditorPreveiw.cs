using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor
{
    public abstract class EditorPreveiw
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

        public abstract void Start();

        public abstract void Update(float deltaTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void End();

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
