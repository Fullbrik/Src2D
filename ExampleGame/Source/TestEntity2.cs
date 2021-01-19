using Src2D;
using Src2D.Attributes;
using Src2D.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame
{
    [SrcEntity("prop_test2", Icon = "Sprites/Motercycle")]
    public class TestEntity2 : SpriteEntity
    {
        [SrcProperty("MySchema")]
        public MySchema MySchema { get; set; } = new MySchema();

        [SrcProperty("MyList")]
        public SrcList<MySchema> MyList { get; set; } = new SrcList<MySchema>();

        public override void Start()
        {
            Sprite = "Sprites/Motercycle";
            base.Start();
        }
    }
}
