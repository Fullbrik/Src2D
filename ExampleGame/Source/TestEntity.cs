﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Src2D;
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

        public override void Start()
        {
            Sprite = "Sprites/Gordon";
            base.Start();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
