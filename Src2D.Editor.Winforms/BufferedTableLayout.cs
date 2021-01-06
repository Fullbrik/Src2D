using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms
{
    public class BufferedTableLayout : TableLayoutPanel
    {
        public BufferedTableLayout() :base()
        {
            DoubleBuffered = true;
        }
    }
}
