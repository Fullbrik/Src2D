using System;
using System.Reflection;
using Src2D;
using ExampleGame;
using System.IO;
using Src2D.Data;
using Newtonsoft.Json;

namespace Windows
{
    class Program
    {
        static void Main(string[] args)
        {
            string gameInfoText = File.ReadAllText("ExampleGame.src2d");
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
