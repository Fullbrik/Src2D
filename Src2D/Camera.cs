using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Src2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    public class Camera
    {
        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                posMatrix = Matrix.CreateTranslation(-position.X, -position.Y, 0);
            }
        }
        private Vector2 position = Vector2.Zero;
        private Matrix posMatrix = Matrix.Identity;


        public float Rotation
        {
            get => rotation;
            set
            {
                rotation = value;
                rotMatrix = Matrix.CreateRotationZ(MathHelper.ToRadians(-rotation));
            }
        }
        private float rotation = 0;
        private Matrix rotMatrix = Matrix.Identity;

        public float Zoom
        {
            get => zoom;
            set
            {
                zoom = Math.Max(.00000000000000001f, value);
                zoomMatrix = Matrix.CreateScale(zoom, zoom, 1);
            }
        }
        private float zoom = 1f;
        private Matrix zoomMatrix = Matrix.Identity;

        public Vector2 Up
        {
            get => Vector2.UnitY.Rotate(MathHelper.ToRadians(rotation));
        }

        public Vector2 Right
        {
            get => Vector2.UnitX.Rotate(MathHelper.ToRadians(rotation));
        }

        public void RenderEntities(SpriteBatch spriteBatch, SceneEnityColection entities)
        {
            var vp = spriteBatch.GraphicsDevice.Viewport;

            var baseTrans = Matrix.CreateTranslation(
                ((vp.Width / zoom) / 2f), ((vp.Height / zoom) / 2f), 1);

            spriteBatch.Begin(transformMatrix: posMatrix * rotMatrix * baseTrans * zoomMatrix);
            entities?.ForEach(ent =>
            {
                if (ent is IDraw2DEntity draw2DEntity && ent.HasStarted)
                {
                    draw2DEntity.Draw(spriteBatch);
                }
            });
            spriteBatch.End();
        }
    }
}
