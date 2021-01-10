using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Src2D;
using Src2D.Attributes;
using Src2D.Data;
using Src2D.Entities;
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

        }

        public override void Start()
        {
            Sprite = "Sprites/Gordon";
            base.Start();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void End()
        {
            base.End();
        }
    }
}
