using System.Runtime.Serialization;

namespace TRPZ.Entities
{
    [DataContract]
    public abstract class Employee
    {
        [DataMember] 
        public string FullName { get; set; }

        [DataMember] 
        public string Position { get; set; }

        [DataMember] 
        public decimal Wage { get; set; }
    }
}