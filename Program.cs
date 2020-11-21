using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TRPZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Company company = new Company();
            Worker worker1 = new Worker
            {
                FullName = "Ernie, the left hand fast but the right hand sturdy",
                Position = "Notorious rapper and a boxer"
            };
            Worker worker2 = new Worker
            {
                FullName = "Eggs Benny",
                Position = "Notorious rapper and a boxer"
            };
            Worker worker3 = new Worker
            {
                FullName = "Ghost",
                Position = "Notorious rapper and a boxer"
            };
            Worker worker4 = new Worker
            {
                FullName = "Jim, the iron chin",
                Position = "Notorious rapper and a boxer"
            };
            List<ICommandable> toddlers = new List<ICommandable>();
            toddlers.Add(worker1);
            toddlers.Add(worker2);
            toddlers.Add(worker3);
            toddlers.Add(worker4);

            Manager manager2 = new Manager
            {
                FullName = "Coach",
                Position = "The Chief of the field operation branch",
                DirectSubordinates = toddlers,
                Wage = 0
            };
           
          
           
            Worker worker5 = new Worker()
            {
                FullName = "Dave",
                Position = "Big Guy",
                Wage = 120000
            };
            Worker worker6 = new Worker()
            {
                FullName = "Marvin",
                Position = "Big Black Guy",
                Wage = 120000
            };
            Manager manager1 = new Manager
            {
                FullName = "Raymond",
                Position = "Mickey's right hand",
                Wage = 15000000
            };
            List<ICommandable> knuckleHeads = new List<ICommandable>();
            knuckleHeads.Add(worker5);
            knuckleHeads.Add(worker6);
           
            manager1.AddSubordinate(worker5);
            manager1.AddSubordinate(worker6);
            manager1.AddSubordinate(manager2);
            Worker personal = new Worker()
            {
                FullName = "Big Bunny",
                Position = "Chief of the Freezer",
                Wage = 12000
            };
            Director director = new Director
            {
                FullName = "Mickey Pearson",
                Position = "CEO, king of the jungle",
                Wage = 300000000
            };
          
            director.AddSubordinate(manager1);
            director.AddSubordinate(personal);
            company.Director = director;
            string jsonString = JsonConvert.SerializeObject(company, Formatting.Indented);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter("D:/Study/TRPZ/Company.txt"))
            using (JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer,company, typeof(Company));
            }

          //  File.WriteAllText("D:/Study/TRPZ/Company.txt", jsonString);
            Company newCompany = JsonConvert.DeserializeObject<Company>(File.ReadAllText("D:/Study/TRPZ/Company.txt"), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });
            DirectOrder display = new DirectOrder();
           var a = display.DisplayEmployees(company.Director);
           foreach (var item in a)
           {
               Console.WriteLine(item.FullName);
           }
        }
    }

        public class Serizalizer
        {

        }

    }