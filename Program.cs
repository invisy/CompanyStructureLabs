using System;
using TRPZ.Entities;
using TRPZ.Interfaces;
using TRPZ.Other;

namespace TRPZ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Dictionary string key of command and object of command
            //no relation  graph db 
            // App.Config default search strategy (only for search methods private usage,not display)
            Console.WriteLine("Enter a path to file");
            var company = Company.BuildStructure(Console.ReadLine());
            Console.WriteLine("Success");
            Console.WriteLine("Enter action commands");
            //  D:/Study/TRPZ/Company.txt
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "add")
                {
                    Console.WriteLine("Enter Name");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter Position");
                    var position = Console.ReadLine();
                    Console.WriteLine("Enter wage");
                    var wage = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter supervisor's position");
                    var positionOfSupervisor = Console.ReadLine();
                    var supervisor = company.SearchByPosition(positionOfSupervisor);
                    company.AddWorker(name, position, wage, supervisor[0] as ICommander);
                }

                if (command == "direct")
                {
                    company.DisplayWorkers = new DirectOrder();
                    foreach (var item in company.Display()) Console.WriteLine(item.FullName);
                }

                if (command == "height")
                {
                    company.DisplayWorkers = new OrderByPosition();
                    foreach (var item in company.Display())
                        Console.WriteLine(item.FullName + " " + item.Position + " " + item.Wage);
                }

                if (command == "wage")
                {
                    Console.WriteLine("Enter wage");
                    var wage = Convert.ToDecimal(Console.ReadLine());
                    var employees = company.SearchByWage(wage);
                    foreach (var item in employees)
                        Console.WriteLine(item.FullName + " " + item.Position + " " + item.Wage);
                }

                if (command == "position")
                {
                    Console.WriteLine("Enter position");
                    var position = Console.ReadLine();
                    foreach (var item in company.SearchByPosition(position))
                        Console.WriteLine(item.FullName + " " + item.Wage);
                }

                if (command == "subordinates")
                {
                    Console.WriteLine("Enter position");
                    var position = Console.ReadLine();
                    foreach (var item in company.SearchDirectSubordinates(
                        company.SearchByPosition(position) as ICommander))
                    {
                        var newItem = item as Employee;
                        Console.WriteLine(newItem.FullName + " " + newItem.Wage);
                    }
                }

                if (command == "save")
                {
                    Console.WriteLine("enter path");
                    //company.SaveStructure(Console.ReadLine(),company);
                    break;
                }
            }
        }
    }
}