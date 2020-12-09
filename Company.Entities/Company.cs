using Company.Interfaces;
using Company.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Entities
{
    public class Company : ICompany
    {

        public Company()
        {
        }

        public Company(IDisplayable displayWorkers)
        {
            DisplayWorkers = displayWorkers;
        }

        public IComposite Director { get; set; }

        public IDisplayable DisplayWorkers { get; set; }

        private List<IEmployee> DefaultSearch()
        {
            var defaultDisplay = new DirectOrder();
            return defaultDisplay.DisplayEmployees(Director);
        }

        public List<IEmployee> Display()
        {
            return DisplayWorkers.DisplayEmployees(Director);
        }

        public void AddWorker(IComposite commander, IEmployee employee)
        {
            commander.AddSubordinate(employee);
        }

        public List<IEmployee> SearchByWage(decimal wage)
        {
            var employees = new List<IEmployee>();
            var allEmployees = DefaultSearch();
            foreach (var item in allEmployees)
                if (item.Wage >= wage)
                    employees.Add(item);

            return employees;
        }

        public List<IEmployee> SearchDirectSubordinates(IComposite commander)
        {
            return commander.DirectSubordinates;
        }

        public List<IEmployee> SearchByPosition(string position)
        {
            var employees = new List<IEmployee>();
            foreach (var item in DefaultSearch())
                if (item.Position.ToLower().Equals(position.ToLower()))
                    employees.Add(item);

            return employees;
        }
    }
}
