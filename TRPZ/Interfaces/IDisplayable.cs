using System.Collections.Generic;
using TRPZ.Entities;

namespace TRPZ.Interfaces
{
    public interface IDisplayable
    {
        List<Employee> DisplayEmployees(ICommander commander);
    }
}