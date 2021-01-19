﻿using Src2D.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Entities
{
    [SrcEntity("func_print")]
    public class PrintEntity : BaseEntity
    {
        [SrcAction("Print", HasParam = true)]
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
