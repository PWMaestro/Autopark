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
        private const string FileExtension = ".csv";
        private Dictionary<string, int> _spareParts = new();

        public SparePartsDictionary()
        {
        }

        public SparePartsDictionary(string inFile)
        {
            var file = inFile + FileExtension;
            if (File.Exists(file))
            {
                using var sr = new StreamReader(File.Open(file, FileMode.Open), Encoding.Default);
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
                Console.WriteLine($"Error! File {file} does not exist.");
            }
        }

        public void Add(string key)
        {
            if (_spareParts.ContainsKey(key))
            {
                if (_spareParts.TryGetValue(key, out int value))
                {
                    _spareParts.Remove(key);
                    _spareParts.Add(key, ++value);
                }
            }
            else
            {
                _spareParts.Add(key, 1);
            }
        }

        public bool Delete(string key) => _spareParts.Remove(key);

        public bool Contains(string key) => _spareParts.ContainsKey(key);

        public void Print()
        {
            foreach (var keyValue in _spareParts)
            {
                Console.WriteLine("{0, 10} - {1, 2}", keyValue.Key, keyValue.Value);
            }
        }
    }
}
