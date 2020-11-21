using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TRPZ
{
    [DataContract]
    public class Director :Employee, ICommander
    {
        [DataMember]
        public List<ICommandable> DirectSubordinates { get; set; }

        public Director()
        {
            DirectSubordinates = new List<ICommandable>();
        }
        public void AddSubordinate(ICommandable subordinate)
        {
            if(subordinate!=null) DirectSubordinates.Add(subordinate);
        }
    }
}