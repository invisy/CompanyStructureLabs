using Company.Interfaces;
using Company.Entities;
using Company.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyConsoleApp
{
    public class CompanyConsole
    {
        private ICompany company;
        private readonly CompanyObjectCreation companyObjectCreation;
        private const string menu = "\n\t1     - add worker" +
           "\n\t2     - save" +
           "\n\t3     - direct" +
           "\n\t4     - height" +
           "\n\t5     - wage" +
           "\n\t6     - position" +
           "\n\t7     - subordinates" +
           "\n\t0  - exit\n";

        public CompanyConsole(ICompany company, CompanyObjectCreation companyObjectCreation)
        {
            this.company = company;
            this.companyObjectCreation = companyObjectCreation;
        }

        public void Run()
        {
            Console.WriteLine("Enter a path to file");
            company = BuildCompany.BuildStructure(Console.ReadLine());
            Console.WriteLine("Success");

            int answer = -1;
            while (answer != 0)
            {
                Console.WriteLine("Enter action commands");
                Console.WriteLine(menu);

                answer = Answer();

                switch (answer)
                {
                    case 0:
                        return;
                    case 1:
                        Add();
                        continue;
                    case 2:
                        Save();
                        continue;
                    case 3:
                        Display();
                        continue;
                    case 4:
                        DisplayHeight();
                        continue;
                    case 5:
                        DisplayWage();
                        continue;
                    case 6:
                        DisplayPosition();
                        continue;
                    case 7:
                        DisplaySubordinates();
                        continue;
                }
            }
        }

        private int Answer()
        {
            string answer;
            int choice;

            do
            {
                answer = Console.ReadLine();
            }
            while (!int.TryParse(answer, out choice));

            return choice;
        }

        private void Display()
        {
            company.DisplayWorkers = new DirectOrder();
            foreach (var item in company.Display()) Console.WriteLine(item.FullName);
        }

        private void DisplayHeight()
        {
            company.DisplayWorkers = new OrderByPosition();
            foreach (var item in company.Display())
                Console.WriteLine(item.FullName + " " + item.Position + " " + item.Wage);
        }

        private void DisplayWage()
        {
            Console.WriteLine("Enter wage");
            var wage = Convert.ToDecimal(Console.ReadLine());
            var employees = company.SearchByWage(wage);
            foreach (var item in employees)
                Console.WriteLine(item.FullName + " " + item.Position + " " + item.Wage);
        }

        private void DisplayPosition()
        {
            Console.WriteLine("Enter position");
            var position = Console.ReadLine();
            foreach (var item in company.SearchByPosition(position))
                Console.WriteLine(item.FullName + " " + item.Wage);
        }

        private void DisplaySubordinates()
        {
            Console.WriteLine("Enter position");
            var position = Console.ReadLine();
            foreach (var item in company.SearchDirectSubordinates(
                company.SearchByPosition(position) as IComposite))
            {
                var newItem = item as Employee;
                Console.WriteLine(newItem.FullName + " " + newItem.Wage);
            }
        }

        private void Save()
        {
            Console.WriteLine("enter path");
            //company.SaveStructure(Console.ReadLine(),company);
            return;
        }

        private void Add()
        {
            var worker = companyObjectCreation.CreateWorker();
            var positionOfSupervisor = Console.ReadLine();
            //var supervisor = company.SearchByPosition(positionOfSupervisor);
            //company.AddWorker(supervisor, worker);
        }

    }
}
