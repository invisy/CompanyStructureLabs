using System.IO;
using Newtonsoft.Json;
using TRPZ.Entities;
using TRPZ.Interfaces;

namespace TRPZ.Other
{
    public class LoadSave : ILoadSave
    {
       public void Save(string path, ICompany company)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, company, typeof(Company));
            }
        }

       public ICompany Load(string path)
        {
            ICompany company = JsonConvert.DeserializeObject<Company>(File.ReadAllText(path), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });
            return company;
        }
    }
}