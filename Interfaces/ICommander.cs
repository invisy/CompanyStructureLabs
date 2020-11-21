using System.Collections.Generic;

namespace TRPZ
{
    public interface ICommander
    { 
        List<ICommandable> DirectSubordinates { get; set; }  
        void AddSubordinate(ICommandable subordinate);
    }
}