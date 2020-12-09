using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Interfaces
{
    public interface IComposite
    {
        List<IEmployee> DirectSubordinates { get; set; }

        void AddSubordinate(IEmployee subordinate);
    }
}
