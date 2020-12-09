using Company.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Company.Entities
{
    [DataContract]
    public class Employee : IEmployee
    {
        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Position { get; set; }

        [DataMember]
        public decimal Wage { get; set; }
    }
}
