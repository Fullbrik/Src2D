using Src2D.Attributes;
using Src2D.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    internal struct Binding
    {
        public SrcEvent OurAction; 
        public BaseEntity Them; 
        public string TheirEvent;

        public Binding(SrcEvent ourAction, BaseEntity them, string theirEvent)
        {
            OurAction = ourAction;
            Them = them;
            TheirEvent = theirEvent;
        }
    }
}
