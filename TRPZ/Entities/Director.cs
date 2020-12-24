using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TRPZ.Entities
{
    public class Director : Composite
    {
        public Director(string fullName, string position, decimal wage) : base(fullName, position, wage)
        {
            
        }
    }
}