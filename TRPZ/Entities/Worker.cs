using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TRPZ.Entities
{
    [DataContract]
    public class Worker : Employee
    {
        public Worker(string fullName, string position, decimal wage) : base(fullName, position, wage)
        {
            
        }
    }
}