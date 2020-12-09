using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TRPZ.Interfaces;

namespace TRPZ.Entities
{
    [DataContract]
    public class Manager : Employee, ICommander
    {
        public Manager()
        {
            DirectSubordinates = new List<ICommander>();
        }

        [DataMember] 
        public List<ICommander> DirectSubordinates { get; set; }

        public void AddSubordinate(ICommander subordinate)
        {
            if (subordinate != null) DirectSubordinates.Add(subordinate);
            else throw new ArgumentNullException(nameof(subordinate), "Subordinate cannot be null");
        }
    }
}