using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TRPZ.Entities
{
    [DataContract]
    public class Manager : Composite
    {
        public Manager(string fullName, string position, decimal wage) : base(fullName, position, wage)
        {
            
        }
    }
}