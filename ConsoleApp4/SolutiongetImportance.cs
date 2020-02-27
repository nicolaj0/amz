using System.Collections.Generic;

class SolutiongetImportance
{
    private List<Employee> _employees;

    public int getImportance(List<Employee> employees, int id)
    {
        _employees = employees;
        return helper(id);
    }

    internal class Employee
    {
        // It's the unique id of each node;
        // unique id of this employee
        public int id;

        // the importance value of this employee
        public int importance;

        // the id of direct subordinates
        public List<int> subordinates;
    };



    private int helper(in int id)
    {
        var i = id;
        var targetEmployee = _employees.Find(e => e.id == i);
        var importance = targetEmployee.importance;

        if (targetEmployee.subordinates?.Count > 0)
        {
            targetEmployee.subordinates.ForEach(s => { importance += helper(s); });
        }

        return importance;
    }
}