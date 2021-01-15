using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Src2D.Editor.Previews.MapEditor;
using Src2D.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.Gizmos
{
    public class Gizmo : IDisposable
    {
        public MapEditorEntity Entity { get; }

        public List<GizmoHandle> Handles { get; } = new List<GizmoHandle>();
        public GizmoHandle CurrentHandle { get => currentHandle; }
        private GizmoHandle currentHandle;

        public bool IsMouseDown { get => isMouseDown; }
        private bool isMouseDown;

        private bool disposedValue;

        private Vector2 prevMousePos = Vector2.Zero;

        public Gizmo(MapEditorEntity entity)
        {
            Entity = entity;
        }

        public virtual void Reload()
        {
            Handles.ForEach(handle => handle.Reload());
        }

        public void Update(Vector2 mousePosition, bool isLeftMouseButtonDown)
        {
            bool wasMouseDown = isMouseDown;

            if (wasMouseDown && !isLeftMouseButtonDown)
            {
                if (currentHandle != null) currentHandle.OnEndDrag();
            }

            isMouseDown = isLeftMouseButtonDown;

            if (!isLeftMouseButtonDown)
            {
                bool didSelectHandle = false;
                Handles.ForEach(handle =>
                {
                    if (handle.Shape.IsPointInside(mousePosition,
                        Entity.Position,
                        handle.UseRotation? Entity.Rotation : 0))
                    {
                        didSelectHandle = true;
                        currentHandle = handle;
                    }
                });

                if (!didSelectHandle && !isLeftMouseButtonDown) currentHandle = null;
            }

            if (!wasMouseDown && isLeftMouseButtonDown)
            {
                if (currentHandle != null) currentHandle.OnStartDrag(mousePosition);
            }

            if (isLeftMouseButtonDown)
            {
                if (currentHandle != null) currentHandle.OnDrag(mousePosition - prevMousePos);
            }

            prevMousePos = mousePosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Handles.ForEach(handle => handle.Shape.Draw(
                spriteBatch,
                Entity.Position,
                handle.UseRotation? MathHelper.ToRadians(Entity.Rotation) : 0,
                Vector2.One,
                handle == currentHandle ?
                    (isMouseDown ? handle.DragColor : handle.HoverColor)
                    : handle.Color));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                Handles.ForEach(handle => handle.Dispose());

                disposedValue = true;
            }
        }

        ~Gizmo()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public abstract class GizmoHandle : IDisposable
    {
        public GraphicsDevice GraphicsDevice { get; }

        public Shape2D Shape { get => shape; }
        private Shape2D shape;

        private bool disposedValue;

        public GizmoHandle(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        public void Reload()
        {
            OnReload();
            shape = new Shape2D(GraphicsDevice, BuildShape());
        }

        public abstract bool UseRotation { get; }

        public abstract Color Color { get; }
        public abstract Color HoverColor { get; }
        public abstract Color DragColor { get; }

        public abstract void OnReload();
        public abstract Point[] BuildShape();
        public abstract void OnStartDrag(Vector2 mousePos);
        public abstract void OnDrag(Vector2 direction);
        public abstract void OnEndDrag();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                shape.Dispose();
                disposedValue = true;
            }
        }

        ~GizmoHandle()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
