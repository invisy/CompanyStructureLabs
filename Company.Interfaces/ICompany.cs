using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Interfaces
{
    public interface ICompany
    {
        IComposite Director { get; set; }
        IDisplayable DisplayWorkers { get; set; }

        void AddWorker(IComposite commander, IEmployee employee);
        List<IEmployee> Display();
        List<IEmployee> SearchByPosition(string position);
        List<IEmployee> SearchByWage(decimal wage);
        List<IEmployee> SearchDirectSubordinates(IComposite commander);
    }
}
