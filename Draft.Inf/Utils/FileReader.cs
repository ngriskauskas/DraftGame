using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Draft.Inf.Utils
{
    public static class FileReader
    {
        public static List<Entity> GetCollection<Entity>(string path)
        {
            List<Entity> entities;
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                entities = JsonConvert.DeserializeObject<List<Entity>>(json);
            }
            return entities;
        }

        public static int[][] GetTable(string path)
        {
            return File.ReadAllLines(path)
                    .Select(l =>
                        l.Split('\t')
                        .Select(i => int.Parse(i))
                        .ToArray())
                    .ToArray();

        }
    }
}