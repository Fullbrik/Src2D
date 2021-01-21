using Eto.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Src2D.Editor
{
    public class RecentFiles : ICollection<string>, IEnumerable<string>
    {
        public static string StoreFile
        {
            get => Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "RecentFiles.txt");
        }

        public readonly static RecentFiles Instance = new RecentFiles();

        private readonly List<string> recentFiles = new List<string>();

        public int Count => recentFiles.Count;

        public bool IsReadOnly => false;

        public RecentFiles()
        {
            Load();
        }

        private void Load()
        {
            if (!File.Exists(StoreFile))
            {
                File.Create(StoreFile);
            }
            else
            {
                string[] lines = File.ReadAllLines(StoreFile);
                recentFiles.AddRange(lines);
            }
        }

        private void Save()
        {
            File.WriteAllLines(StoreFile, recentFiles.ToArray());
        }

        public void Add(string item)
        {
            if (!string.IsNullOrWhiteSpace(item) && !recentFiles.Contains(item))
                recentFiles.Add(item);
            Save();
        }

        public void Clear()
        {
            recentFiles.Clear();
            Save();
        }

        public bool Contains(string item)
        {
            return recentFiles.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            recentFiles.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            if (recentFiles.Remove(item))
            {
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return recentFiles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return recentFiles.GetEnumerator();
        }
    }
}
