using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Src2D.Shapes
{
    public class Shape2D : IDisposable
    {
        public static IEnumerable<Point> GenerateNGon(int n, float radius)
        {
            for (int i = 0; i < n; i++)
            {
                yield return new Vector2(
                    radius * (float)Math.Cos(2 * Math.PI * i / n),
                    radius * (float)Math.Sin(2 * Math.PI * i / n)).ToPoint();
            }
        }

        private bool disposedValue;

        int MinX { get; }
        int MinY { get; }

        int MaxX { get; }
        int MaxY { get; }

        int Width { get; }
        int Height { get; }

        Texture2D Texture { get; }
        Vector2 Orgin { get; }

        private readonly Point[] verticies;
        private readonly Vector2[] orginVerticies;

        public Shape2D(GraphicsDevice graphicsDevice, params Point[] verticies)
        {
            this.verticies = verticies;

            MinX = verticies.MinX();
            MinY = verticies.MinY();

            MaxX = verticies.MaxX();
            MaxY = verticies.MaxY();

            Width = Math.Abs(MaxX - MinX) + 1;
            Height = Math.Abs(MaxY - MinY) + 1;

            Texture = new Texture2D(graphicsDevice, Width, Height);
            Orgin = new Vector2(-MinX, -MinY);

            orginVerticies = verticies.Select(v => v.ToVector2() + Orgin).ToArray();

            Color[] data = GetTextureDataFromVerticies();
            Texture.SetData(data);
            GC.Collect();
        }

        private Color[] GetTextureDataFromVerticies()
        {
            List<Color> data = new List<Color>();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    data.Add(IsPointInside(new Vector2(x, y)) ? Color.White : Color.Transparent);
                }
            }

            return data.ToArray();
        }

        public bool IsPointInside(Vector2 testPoint, Vector2 position, float rotation)
        {
            var trasn
                = Matrix.CreateTranslation(
                    position.X - Orgin.X, position.Y - Orgin.Y, 0);
            var rot = Matrix.CreateRotationZ(MathHelper.ToRadians(rotation));

            testPoint -= position;
            testPoint = Vector2.Transform(testPoint,
                Matrix.Invert(trasn * rot));
            testPoint += position;
            return IsPointInside(testPoint);
        }

        public bool IsPointInside(Vector2 testPoint)
        {
            var polygon = orginVerticies;

            bool result = false;
            int j = polygon.Length - 1;
            for (int i = 0; i < polygon.Length; i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, Vector2 scale, Color color)
        {
            spriteBatch.Draw(
                Texture,
                position,
                null,
                color,
                rotation,
                Orgin,
                scale,
                SpriteEffects.None,
                0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                Texture.Dispose();
                disposedValue = true;
            }
        }

        ~Shape2D()
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
