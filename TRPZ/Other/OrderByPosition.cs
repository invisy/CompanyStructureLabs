using System.Collections.Generic;

namespace TRPZ
{
    public class OrderByPosition : IDisplayable
    {
        List<Employee> employees = new List<Employee>();

        public List<Employee> DisplayEmployees(ICommander commander)
        {
            employees.Add(commander as Employee);
            foreach (ICommandable item in commander.DirectSubordinates)
            {
                if (!(item is ICommander)) employees.Add(item as Employee);
            }

            foreach (ICommandable item in commander.DirectSubordinates)
            {
                if (item is ICommander) DisplayEmployees(item as ICommander);
            }

            return employees;
        }
    }
}