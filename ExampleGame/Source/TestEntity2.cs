using Src2D.Attributes;
using Src2D.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame
{
    [SrcEntity("Test2", Sprite = "Sprites/Motercycle")]
    public class TestEntity2 : SpriteEntity
    {
        public override void Start()
        {
            Sprite = "Sprites/Gordon";
            base.Start();
        }
    }
}
