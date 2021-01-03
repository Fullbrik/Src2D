using Microsoft.Xna.Framework.Graphics;
using Src2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    [SrcEntity("Update", Description = "An entity that updates every frame")]
    public class UpdateEnity : BaseEntity, IUpdateEntity
    {
        public virtual void Update(float deltaTime)
        {
            
        }
    }
}
