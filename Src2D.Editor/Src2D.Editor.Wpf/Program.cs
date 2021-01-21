using Eto.Forms;
using System;
using System.IO;

namespace Src2D.Editor.Wpf
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length > 0
                && File.Exists(args[0])
                && Path.GetExtension(args[0]).ToLower() == ".src2d")
                new Application(Eto.Platforms.Wpf).Run(new ProjectView(args[0]));
            else
                new Application(Eto.Platforms.Wpf).Run(new Launcher());
        }
    }
}
