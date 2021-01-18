using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Src2D
{
    public class Src2DGame : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;

        public SpriteBatch SpriteBatch { get => spriteBatch; }
        private SpriteBatch spriteBatch;

        public Data.GameInfo GameInfo { get => gameInfo; }
        private Data.GameInfo gameInfo;

        public Src2DGame(Data.GameInfo gameInfo)
        {
            this.gameInfo = gameInfo;

            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;
            graphicsDeviceManager.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Assets.ContentManager = Content;

            SceneManager.LoadMap(gameInfo.StartingMap);
        }

        protected override void Update(GameTime gameTime)
        {
            SceneManager.ActiveScene?.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var vp = GraphicsDevice.Viewport;
            var CameraScale = Vector2.One; //Temporary until we implement an actual camera

            var baseTrans = Matrix.CreateTranslation(
                ((vp.Width / CameraScale.X) / 2f), ((vp.Height / CameraScale.Y) / 2f), 1);
            SpriteBatch.Begin(transformMatrix: baseTrans);
            SceneManager.ActiveScene?.Draw2D(SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void EndRun()
        {
            SceneManager.ActiveScene?.End();

            base.EndRun();
        }
    }
}
