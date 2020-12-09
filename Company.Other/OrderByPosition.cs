using Company.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Other
{
    public class OrderByPosition : IDisplayable
    {
        private readonly List<IEmployee> employees = new List<IEmployee>();

        public List<IEmployee> DisplayEmployees(IComposite commander)
        {
            employees.Add(commander as IEmployee);
            foreach (var item in commander.DirectSubordinates)
                if (!(item is IComposite))
                    employees.Add(item as IEmployee);

            foreach (var item in commander.DirectSubordinates)
                if (item is IComposite)
                    DisplayEmployees(item as IComposite);

            return employees;
        }
    }
}
