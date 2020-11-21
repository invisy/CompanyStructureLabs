using System;
using System.Collections.Generic;
using TRPZ;

public class Company
{
    public Director Director { get; set; }

    public IDisplayable DisplayWorkers { get; set; }


    public List<Employee> Display()
    {
        return DisplayWorkers.DisplayEmployees(Director);
    }

    public void BuildStructure(string path)
    {
        throw new NotImplementedException();
    }

    public List<Employee> SearchByWage(double wage)
    {
        throw new NotImplementedException();
    }
    public List<ICommandable> SearchDirectSubordinates(ICommander superVisor)
    {
        return superVisor.DirectSubordinates;
    }

    public List<Employee> SearchByPosition(string position)
    {
        throw new NotImplementedException();
    }

}