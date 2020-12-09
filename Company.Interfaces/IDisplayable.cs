using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Interfaces
{
    public interface IDisplayable
    {
        List<IEmployee> DisplayEmployees(IComposite commander);
    }
}
