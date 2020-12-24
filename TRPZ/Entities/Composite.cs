using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TRPZ.Interfaces;

namespace TRPZ.Entities
{
    [DataContract]
    public abstract class Composite : Employee, ICommander
    {
        [DataMember]
        public List<Employee> DirectSubordinates { get; }

        protected Composite(string fullName, string position, decimal wage) : base(fullName, position, wage)
        {
            DirectSubordinates = new List<Employee>();
        }
        public virtual void AddSubordinate(Employee subordinate)
        {
            if(subordinate!=null) DirectSubordinates.Add(subordinate);
            else throw new ArgumentNullException(nameof(subordinate), "Subordinate cannot be null");
        }
    }
}