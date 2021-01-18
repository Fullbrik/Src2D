using CommandLine;
using Newtonsoft.Json;
using Src2D.Data;
using Src2D.Editor.EnityData;
using Src2D.Editor.SchemaData;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Src2D.Editor.DataSheet.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
                {
                    options.ProjectFile = options.ProjectFile.Trim();
                    options.Configuration = options.Configuration.Trim();
                    options.OutputFolder = options.OutputFolder.Trim();

                    if (File.Exists(options.ProjectFile))
                    {
                        if (Path.GetExtension(options.ProjectFile) == ".src2d")
                        {
                            LoadFile(options);
                        }
                        else
                        {
                            throw new Exception($"File {options.ProjectFile} is not a src2d file. It is a {Path.GetExtension(options.ProjectFile)} file");
                        }
                    }
                    else
                    {
                        throw new Exception($"File {options.ProjectFile} doesn't exist.");
                    }

                });
            }
            catch (Exception e)
            {

                Console.WriteLine($"Exception thrown of type \"{e.GetType().Name}\".\n{e.Message}");
                Console.ReadKey();
            }
        }

        private static void LoadFile(Options options)
        {
            string text = File.ReadAllText(options.ProjectFile);
            GameInfo gameInfo = JsonConvert.DeserializeObject<GameInfo>(text);

            var bc = gameInfo.BuildConfigurations.FirstOrDefault(config => config.Name == options.Configuration);

            if (bc.Name == options.Configuration)
            {
                var assembly = Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(options.ProjectFile), bc.DLL));

                var esd = EntityDataSheetBuilder.FromAssemblies(typeof(Src2DGame).Assembly, assembly);

                var ssd = SchemaDataSheetBuilder.FromAssemblies(typeof(Src2DGame).Assembly, assembly);

                string dir = Path.Combine(Path.GetDirectoryName(options.ProjectFile), options.OutputFolder);

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(Path.Combine(dir, "Enities.ds"), JsonConvert.SerializeObject(esd));
                File.WriteAllText(Path.Combine(dir, "Schemas.ds"), JsonConvert.SerializeObject(ssd));
            }
            else
            {
                throw new Exception($"Build configuration {options.Configuration} doesn't exist in {options.ProjectFile}.");
            }
        }
    }

    class Options
    {
        [Option('i', "input", Required = true, HelpText = "The Src2d file to generate the DataSheets for. This will be automatically update to include the DataSheets' path.")]
        public string ProjectFile { get; set; }
        [Option('c', "config", Required = true, HelpText = "The build configuration to make the DataSheet from.")]
        public string Configuration { get; set; }
        [Option('o', "output", Default = "Data", HelpText = "What folder to store the output in relative to the src2d file.")]
        public string OutputFolder { get; set; }
    }
}
