using System.Collections.Generic;

namespace TRPZ
{
    public interface IDisplayable
    {
        List<Employee> DisplayEmployees(Director director);
    }
}