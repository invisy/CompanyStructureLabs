using Company.Entities;
using Company.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyConsoleApp
{
    public class CompanyObjectCreation
    {
        public IEmployee CreateWorker()
        {
            Console.WriteLine("Enter Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Position");
            var position = Console.ReadLine();
            Console.WriteLine("Enter wage");
            var wage = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter supervisor's position");

            IEmployee worker = new Manager(name, position, wage);
            return worker;
        }
    }
}
