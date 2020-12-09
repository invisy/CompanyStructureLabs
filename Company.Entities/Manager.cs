using Company.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Company.Entities
{
    [DataContract]
    public class Manager : Employee, IComposite
    {
        public Manager(string name, string position, decimal wage)
        {
            FullName = name;
            Position = position;
            Wage = wage;
            DirectSubordinates = new List<IEmployee>();
        }

        [DataMember]
        public List<IEmployee> DirectSubordinates { get; set; }

        public void AddSubordinate(IEmployee subordinate)
        {
            if (subordinate != null) DirectSubordinates.Add(subordinate);
            else throw new ArgumentNullException(nameof(subordinate), "Subordinate cannot be null");
        }
    }
}
