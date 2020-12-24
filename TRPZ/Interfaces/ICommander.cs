using System.Collections.Generic;
using TRPZ.Entities;

namespace TRPZ.Interfaces
{
    public interface ICommander
    { 
        List<Employee> DirectSubordinates { get; }
        void AddSubordinate(Employee subordinate);
    }
}