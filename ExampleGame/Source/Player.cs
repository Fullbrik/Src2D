using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Src2D;
using Src2D.Attributes;
using Src2D.Entities;
using Src2D.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame
{
    [SrcEntity("player", Icon = "Sprites/Motercycle")]
    public class Player : SpriteEntity
    {
        public override Vector2 Position { get => camera.Position; set => camera.Position = value; }
        public override float Rotation { get => camera.Rotation; set => camera.Rotation = value; }

        [SrcProperty("Speed", DefaultValue = 100)]
        public float Speed { get; set; } = 100;

        Camera camera = new Camera();

        public override void Start()
        {
            Sprite = "Sprites/Motercycle";
            base.Start();
            Scene.Camera = camera;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (InputManager.IsKeyDown(Keys.W)) 
                Position -= Up * Speed * deltaTime;

            if (InputManager.IsKeyDown(Keys.S)) 
                Position += Up * Speed * deltaTime;

            if (InputManager.IsKeyDown(Keys.A)) 
                Position -= Right * Speed * deltaTime;

            if (InputManager.IsKeyDown(Keys.D)) 
                Position += Right * Speed * deltaTime;

            if(InputManager.IsKeyDown(Keys.E))
                Rotation += 5 * deltaTime;

            if(InputManager.IsKeyDown(Keys.Q))
                Rotation -= 5 * deltaTime;

            if(InputManager.MouseScrollDelta > 0)
                camera.Zoom += deltaTime * Speed;

            if(InputManager.MouseScrollDelta < 0)
                camera.Zoom -= deltaTime * Speed;
        }
    }
}
