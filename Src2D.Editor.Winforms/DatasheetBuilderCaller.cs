using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms
{
    public static class DatasheetBuilderCaller
    {
        public static void Call(string src2dFile, string configuration)
        {
            Process.Start(
                Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DSBuilder", "DSBuilder"), 
                $"-i {src2dFile} -c {configuration}").WaitForExit();
        }
    }
}
