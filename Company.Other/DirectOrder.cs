using Company.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Other
{
    public class DirectOrder : IDisplayable
    {
        private readonly List<IEmployee> _employees = new List<IEmployee>();

        public List<IEmployee> DisplayEmployees(IComposite commander)
        {
            _employees.Add(commander as IEmployee);
            foreach (var item in commander.DirectSubordinates)
            {
                if (item is IComposite) DisplayEmployees(item as IComposite);
                if (!(item is IComposite)) _employees.Add(item as IEmployee);
            }

            return _employees;
        }
    }
}
