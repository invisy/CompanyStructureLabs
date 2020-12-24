using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TRPZ.Interfaces;
using TRPZ.Other;

namespace TRPZ.Entities
{
    public class Company : ICompany
    {
        [DataMember]
        public Director Director { get; set; }

        public IDisplayable DisplayWorkers { get; set; }

        public Company()
        {
            DisplayWorkers = new DirectOrder();
        }

        public List<Employee> Display()
        {
            return DisplayWorkers.DisplayEmployees(Director);
        }

        public List<Employee> SearchByWage(decimal wage)
        {
            List<Employee> employees = new List<Employee>();
            List<Employee> allEmployees = Display();
            foreach (var item in allEmployees)
            {
                if (item.Wage >= wage) employees.Add(item);
            }

            return employees;
        }

        public List<Employee> SearchDirectSubordinates(ICommander commander)
        {
            return commander.DirectSubordinates;
        }

        public List<Employee> SearchByPosition(string position)
        {
            List<Employee> employees = new List<Employee>();
            foreach (var item in Display())
            {
                if (item.Position.ToLower().Equals(position.ToLower())) employees.Add(item);
            }

            return employees;
        }

    }
}