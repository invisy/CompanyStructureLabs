using System.Collections.Generic;

namespace TRPZ.Interfaces
{
    public interface ICommander
    {
        List<ICommander> DirectSubordinates { get; set; }
        
        void AddSubordinate(ICommander subordinate);
    }
}