using System.Collections.Generic;
using TRPZ.Entities;
using TRPZ.Interfaces;

namespace TRPZ.Other
{
    public class OrderByPosition : IDisplayable
    {
        private readonly List<Employee> employees = new List<Employee>();

        public List<Employee> DisplayEmployees(ICommander commander)
        {
            employees.Add(commander as Employee);
            foreach (var item in commander.DirectSubordinates)
                if (!(item is ICommander))
                    employees.Add(item as Employee);

            foreach (var item in commander.DirectSubordinates)
                if (item is ICommander)
                    DisplayEmployees(item as ICommander);

            return employees;
        }
    }
}