using System;
using System.IO;
using System.Reflection;
using Src2D;
using Src2D.Data;
using Newtonsoft.Json;

namespace OpenGL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().Location);

            string gameInfoText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ExampleGame.src2d"));
            GameInfo gameInfo = JsonConvert.DeserializeObject<GameInfo>(gameInfoText);

            using (Src2DGame game = new Src2DGame(gameInfo))
            {
                AssemblyManager.LoadAssembly(typeof(Src2DGame).Assembly);
                AssemblyManager.LoadAssembly(Assembly.Load("ExampleGame"));
                game.Run();
            }
        }
    }
}
