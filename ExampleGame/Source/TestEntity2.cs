using Src2D;
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
        [SrcProperty("MySchema")]
        public MySchema MySchema { get; set; }

        [SrcProperty("MyList")]
        public SrcList<MySchema> MyList { get; set; }

        public override void Start()
        {
            Sprite = "Sprites/Gordon";
            base.Start();
        }
    }
}
