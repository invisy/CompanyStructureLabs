using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TRPZ.Entities;

namespace TRPZ.Other
{
    public static class LoadSave
    {
        public static void Save(string path, Company company)
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;

            using (var sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, company, typeof(Company));
            }
        }

        public static Company Load(string path)
        {
            var company = JsonConvert.DeserializeObject<Company>(File.ReadAllText(path), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
            return company;
        }
    }
}