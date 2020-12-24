using System;
using System.Runtime.Serialization;

namespace TRPZ.Entities
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string FullName { get; }
        [DataMember]
        public string Position { get; }
        [DataMember]
        public decimal Wage { get; }

        public Employee(string fullName, string position, decimal wage)
        {
            FullName = fullName;
            Position = position;
            Wage = wage;
        }
    }
}