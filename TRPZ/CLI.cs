using System;
using TRPZ.Entities;
using TRPZ.Interfaces;
using TRPZ.Other;

namespace TRPZ
{
    public class CLI
    {
        private ICompany _company;
        private readonly ILoadSave _loader;
        public CLI(ILoadSave loader)
        {
            _loader = loader;
        }

        public void Main()
        {
            DisplayLoadDialog();
            PrintHelp();
            while (true)
            { 
               Console.WriteLine("\nEnter action commands");
               string command = Console.ReadLine();
               switch (command)
               {
                   case "add":
                       AddEmployeeDialog();
                       break;
                   case "direct":
                       DirectDialog();
                       break;
                   case "height":
                       HeightDialog();
                       break;
                   case "wage":
                       WageDialog();
                       break;
                   case "position":
                       PositionDialog();
                       break;
                   case "subordinates":
                       SubordinatesDialog();
                       break;
                   case "save":
                       DisplaySaveDialog();
                       break;
                   case "exit":
                       return;
                   default:
                       PrintHelp();
                       break;
               }
            }
        }

        private void PrintHelp()
        {
            Console.WriteLine("\nadd            - add worker" +
                              "\nsave           - save" +
                              "\ndirect         - direct" +
                              "\nheight         - height" +
                              "\nwage           - wage" +
                              "\nposition       - position" +
                              "\nsubordinates   - subordinates" +
                              "\nsave           - subordinates");
        }
        
        private void AddEmployeeDialog()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Position");
            string position = Console.ReadLine();
            Console.WriteLine("Enter wage");
            decimal wage = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter supervisor's position");
            string positionOfSupervisor = Console.ReadLine();
            var supervisor = _company.SearchByPosition(positionOfSupervisor)[0] as ICommander;
            var worker = new Worker(name,position,wage);
            supervisor.AddSubordinate(worker);
        }

        private void DirectDialog()
        {
            _company.DisplayWorkers = new DirectOrder();
            foreach (var item in _company.Display())
            {
                Console.WriteLine(item.FullName);
            }
        }

        private void HeightDialog()
        {
            _company.DisplayWorkers = new OrderByPosition();
            foreach (var item in _company.Display())
            {
                Console.WriteLine(item.FullName + " " + item.Position + " " + item.Wage);
            }
        }

        private void WageDialog()
        {
            Console.WriteLine("Enter wage");
            decimal wage = Convert.ToDecimal(Console.ReadLine());
            var employees = _company.SearchByWage(wage);
            foreach (var item in employees )
            {
                Console.WriteLine(item.FullName + " " + item.Position + " " + item.Wage);
            }
        }

        private void PositionDialog()
        {
            Console.WriteLine("Enter position");
            string position = Console.ReadLine();
            foreach (var item in _company.SearchByPosition(position))
            {
                Console.WriteLine(item.FullName + " " + item.Wage);
            }
        }
        
        private void SubordinatesDialog()
        {
            Console.WriteLine("Enter position");
            string position = Console.ReadLine();
            foreach (var item in _company.SearchDirectSubordinates((_company.SearchByPosition(position) as ICommander)))
            {
                var newItem = item as Employee;
                Console.WriteLine(newItem.FullName + " " + newItem.Wage);
            }
        }
        
        private void DisplayLoadDialog()
        {
            Console.WriteLine("Enter a path to file");
            _company = _loader.Load(Console.ReadLine());
            Console.WriteLine("Success");
        }
        private void DisplaySaveDialog()
        {
            Console.WriteLine("enter path");
            _loader.Save(Console.ReadLine(), _company);
        }
    }
}