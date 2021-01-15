using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Src2D;
using Src2D.Attributes;
using Src2D.Data;
using Src2D.Entities;
using Src2D.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame
{
    [SrcEntity("Test", Sprite = "Sprites/Gordon")]
    public class TestEntity : SpriteEntity
    {
        [SrcProperty("MyInt", DefaultValue = 1, Description = "An int")]
        public int MyInt { get; set; }

        [SrcProperty("MyEntity", Description = "An Entity")]
        public EntityReference MyEntity { get; set; }

        [SrcProperty("MyVector3", Description = "A Vector3")]
        public Vector3 MyVector3 { get; set; }

        [SrcAsset("MyAsset", SrcAssetType.Map)]
        public Asset<Map> MyAsset = new Asset<Map>();

        [SrcEvent("MyEvent")]
        public event SrcEvent MyEvent;

        [SrcAction("MyActions", HasParam = true, ParamOptions = "Yes|No")]
        public void MyAction(string args)
        {
            MyEvent?.Invoke(args);
        }

        Shape2D shape;

        public override void Start()
        {
            Sprite = "Sprites/Gordon";



            base.Start();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);

            if (shape == null)
            {
                shape = new Shape2D(
                    spriteBatch.GraphicsDevice,
                    new Point(10, -5),
                    new Point(100, -5),
                    new Point(100, -15),
                    new Point(110, 0),
                    new Point(100, 15),
                    new Point(100, 5),
                    new Point(10, 5));
            }
            else
            {
                shape.Draw(spriteBatch, Vector2.One * 100, 0, Vector2.One, Color.White);
            }
        }

        public override void End()
        {
            base.End();
        }
    }
}
