using Eto.Forms;
using System;
using System.IO;

namespace Src2D.Editor.Gtk
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ProjectManager.DynamicAssemblyManager = new Src2D.Editor.CoreHacks.CoreHackDynamicAssemblyManager();

            if (args.Length > 0
                && File.Exists(args[0])
                && Path.GetExtension(args[0]).ToLower() == ".src2d")
                new Application(Eto.Platforms.Gtk).Run(new ProjectView(args[0]));
            else
                new Application(Eto.Platforms.Gtk).Run(new Launcher());
        }
    }
}
