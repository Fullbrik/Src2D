using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Src2D.Editor.Content
{
    public class ContentFile
    {
        public static ContentFile Parse(string[] lines, string contentFolder)
        {
            ContentFile retVal = new ContentFile(contentFolder);

            ContentItem current = new ContentItem();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("/"))
                {
                    var cmdAndParam = lines[i].Split(':');

                    if (cmdAndParam.Length < 2) throw new Exception($"Error on line {0}: There has to be a /option followed by a : and a parameter");

                    HandleCmdAndParam(i, cmdAndParam[0], cmdAndParam[1], retVal, current, out bool replaceCurrent);

                    if (replaceCurrent)
                    {
                        retVal.ContentItems.Add(current);
                        current = new ContentItem();
                    }
                }
            }

            retVal.BuildFolders();

            return retVal;
        }

        private static void HandleCmdAndParam(int line, string cmd, string param, ContentFile retVal, ContentItem curent, out bool replaceCurrent)
        {
            string paramUntrimmed = param;
            param = param.Trim();

            replaceCurrent = false;

            switch (cmd)
            {
                case "/outputDir":
                    retVal.OutputDir = param;
                    break;
                case "/intermediateDir":
                    retVal.IntermediateDir = param;
                    break;
                case "/platform":
                    retVal.Platform = param;
                    break;
                case "/config":
                    retVal.Config = param;
                    break;
                case "/profile":
                    retVal.Profile = param;
                    break;
                case "/compress":
                    retVal.Compress = param.ToLower()[0] == 't';
                    break;

                case "/reference":
                    retVal.References.Add(param);
                    break;

                case "/importer":
                    curent.Importer = param;
                    break;
                case "/processor":
                    curent.Processor = param;
                    break;

                case "/processorParam":
                    var keyValue = param.Split('=');
                    if (keyValue.Length < 2) throw new Exception($"Error on line {line}: All processor params must have a param and = something");
                    curent.ProcessorParams.Add(keyValue[0], keyValue[1]);
                    break;

                case "/build":
                    curent.FileName = paramUntrimmed;
                    curent.Name = Path.GetFileName(paramUntrimmed);
                    curent.FoldersInOrder = Path.GetDirectoryName(paramUntrimmed).Split('\\', '/');
                    replaceCurrent = true;
                    break;
                default:
                    break;
            }
        }



        public readonly List<ContentItem> ContentItems = new List<ContentItem>();

        public readonly ContentFolder Content = new ContentFolder("Content");

        public readonly List<string> References = new List<string>();

        public string OutputDir { get; set; }
        public string IntermediateDir { get; set; }
        public string Platform { get; set; }
        public string Config { get; set; }
        public string Profile { get; set; }
        public bool Compress { get; set; }

        public string ContentFolder { get => contentFolder; }
        private string contentFolder;

        public ContentFile(string contentFolder)
        {
            this.contentFolder = contentFolder;
        }

        public void BuildFolders()
        {
            foreach (var item in ContentItems)
            {
                ContentFolder current = Content;

                foreach (var folder in item.FoldersInOrder)
                {
                    if (current.Folders.Exists((f) => f.Name == folder))
                    {
                        current = current.Folders.First((f) => f.Name == folder);
                    }
                    else
                    {
                        var newFolder = new ContentFolder(folder);

                        current.Folders.Add(newFolder);
                        newFolder.Parent = current;

                        current = newFolder;
                    }
                }

                current.Items.Add(item);
            }
        }
    }

    public class ContentItem
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public string[] FoldersInOrder { get; set; }
        public string Importer { get; set; }
        public string Processor { get; set; }

        public readonly Dictionary<string, string> ProcessorParams = new Dictionary<string, string>();
    }

    public class ContentFolder
    {
        public string Name { get; set; }

        public ContentFolder Parent { get; set; }
        public readonly List<ContentFolder> Folders = new List<ContentFolder>();
        public readonly List<ContentItem> Items = new List<ContentItem>();

        public ContentFolder(string name)
        {
            Name = name;
        }
    }
}
