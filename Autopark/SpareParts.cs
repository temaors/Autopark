using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class SparePartsDictionary
    {
        private Dictionary<string, int> SpareParts = new();

        public SparePartsDictionary()
        {
        }

        public SparePartsDictionary(string inFile)
        {
            if (File.Exists(inFile))
            {
                using var sr = new StreamReader(File.Open(inFile, FileMode.Open), Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    foreach (var part in parts)
                    {
                        Add(part);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error! File {inFile} does not exist.");
            }
        }

        public void Add(string key)
        {
            if (SpareParts.ContainsKey(key))
            {
                if (SpareParts.TryGetValue(key, out int value))
                {
                    SpareParts.Remove(key);
                    SpareParts.Add(key, ++value);
                }
            }
            else
            {
                SpareParts.Add(key, 1);
            }
        }

        public bool Delete(string key) => SpareParts.Remove(key);

        public bool Contains(string key) => SpareParts.ContainsKey(key);

        public void Print()
        {
            foreach (var keyValue in SpareParts)
            {
                Console.WriteLine("{0, 10} - {1, 2}", keyValue.Key, keyValue.Value);
            }
        }
    }
}