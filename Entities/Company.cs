using System.Collections.Generic;
using TRPZ.Interfaces;
using TRPZ.Other;

namespace TRPZ.Entities
{
    public class Company
    {
        public Company()
        {
        }

        public Company(IDisplayable displayWorkers)
        {
            DisplayWorkers = displayWorkers;
        }

        public Director Director { get; set; }

        public IDisplayable DisplayWorkers { get; set; }

        private List<Employee> DefaultSearch()
        {
            var defaultDisplay = new DirectOrder();
            return defaultDisplay.DisplayEmployees(Director);
        }

        public List<Employee> Display()
        {
            return DisplayWorkers.DisplayEmployees(Director);
        }

        public static Company BuildStructure(string path)
        {
            return LoadSave.Load(path);
        }

        public void AddWorker(string FullName, string Position, decimal Wage, ICommander commander)
        {
            var worker = new Manager
            {
                FullName = FullName,
                Position = Position,
                Wage = Wage
            };
            commander.AddSubordinate(worker);
        }

        public List<Employee> SearchByWage(decimal wage)
        {
            var employees = new List<Employee>();
            var allEmployees = DefaultSearch();
            foreach (var item in allEmployees)
                if (item.Wage >= wage)
                    employees.Add(item);

            return employees;
        }

        public List<ICommander> SearchDirectSubordinates(ICommander commander)
        {
            return commander.DirectSubordinates;
        }

        public List<Employee> SearchByPosition(string position)
        {
            var employees = new List<Employee>();
            foreach (var item in DefaultSearch())
                if (item.Position.ToLower().Equals(position.ToLower()))
                    employees.Add(item);

            return employees;
        }
    }
}