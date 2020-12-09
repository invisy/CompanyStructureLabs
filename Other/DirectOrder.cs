using System.Collections.Generic;
using TRPZ.Entities;
using TRPZ.Interfaces;

namespace TRPZ.Other
{
    public class DirectOrder : IDisplayable
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public List<Employee> DisplayEmployees(ICommander commander)
        {
            _employees.Add(commander as Employee);
            foreach (var item in commander.DirectSubordinates)
            {
                if (item is ICommander) DisplayEmployees(item as ICommander);
                if (!(item is ICommander)) _employees.Add(item as Employee);
            }

            return _employees;
        }
    }
}