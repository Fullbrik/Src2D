using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor.Tools
{
    public interface IAction
    {
        void Do();
        void Undo();

        bool CanCollapseWith(IAction other);
    }
}
