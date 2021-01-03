using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    [SrcEntity("Print")]
    public class PrintEntity : BaseEntity
    {
        [SrcAction("Print", HasParam = true)]
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
