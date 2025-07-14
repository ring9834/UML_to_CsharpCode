namespace UML_to_CsharpCode
{
    public class Department
    {
        // Aggregation: Department contains Employees, but Employees can exist independently
        // the lifecycle of the Employee is not controlled by the Department.
        // The Employee can be shared among multiple Departments.
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    public class Employee
    {
        public string Name { get; set; }
    }
}
