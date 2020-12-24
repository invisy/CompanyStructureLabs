using System.Collections.Generic;
using TRPZ.Entities;

namespace TRPZ.Interfaces
{
    public interface ICompany
    {
        Director Director { get; }

        IDisplayable DisplayWorkers { get; set; }
        List<Employee> Display();
        List<Employee> SearchByWage(decimal wage);
        List<Employee> SearchDirectSubordinates(ICommander commander);
        List<Employee> SearchByPosition(string position);
    }
}