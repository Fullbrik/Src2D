using Src2D;
using Src2D.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame
{
    [SrcSchema("MySchema")]
    public class MySchema : SrcSchema
    {
        [SrcProperty("MyInt")]
        public int MyInt { get; set; }

        [SrcProperty("MyBool")]
        public bool MyBool { get; set; }
    }
}
