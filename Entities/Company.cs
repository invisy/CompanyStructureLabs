using System;
using System.Collections.Generic;
using TRPZ;

public class Company
{
    public Director Director { get; set; }

    public IDisplayable DisplayWorkers { get; set; }
    private IDisplayable defaultSearch;

    public Company()
    {
        
    }
    public Company(IDisplayable displayWorkers)
    {
        DisplayWorkers = displayWorkers;
    }
    public List<Employee> Display()
    {
        return DisplayWorkers.DisplayEmployees(Director);
    }

    public static Company BuildStructure(string path)
    {
        return LoadSave.Load(path);
    }
    public void SaveStructure(string path,Company company)
    {
        LoadSave.Save(path,company);
    }

    public void AddWorker(string FullName, string Position, decimal Wage, ICommander commander)
    {
        Worker worker = new Worker() {
            FullName = FullName,
            Position = Position,
            Wage = Wage
        };
        commander.AddSubordinate(worker);
    }

    public List<Employee> SearchByWage(decimal wage)
    {
        List<Employee> employees = new List<Employee>();
        List<Employee> allEmployees = Display();
        foreach (var item in allEmployees)
        {
            if(item.Wage >= wage) employees.Add(item);
        }

        return employees;
    }
    public List<ICommandable> SearchDirectSubordinates(ICommander commander)
    {
        return commander.DirectSubordinates;
    }

    public List<Employee> SearchByPosition(string position)
    {
        List<Employee> employees = new List<Employee>();
        foreach (var item in Display())
        {
            if (item.Position.ToLower().Equals(position.ToLower())) employees.Add(item);
        }

        return employees;
    }

}