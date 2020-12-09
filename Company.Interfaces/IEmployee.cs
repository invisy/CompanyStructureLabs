using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Interfaces
{
    public interface IEmployee
    {
        string FullName { get; set; }
        string Position { get; set; }
        decimal Wage { get; set; }
    }
}
