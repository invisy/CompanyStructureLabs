using Company.Interfaces;
using Company.Entities;
using System;

namespace CompanyConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            ICompany company = new Company.Entities.Company();
            var companyObjectCreation = new CompanyObjectCreation();
            var companyConsole = new CompanyConsole(company, companyObjectCreation);

            companyConsole.Run();
        }
    }
}
