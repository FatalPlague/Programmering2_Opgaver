using Pr12_Blazor.Models;

namespace Pr12_Blazor.Persistence
{
    public static class EmployeeRepository
    {
        private static List<Employee> employees = new List<Employee>
    {
        new Employee
        {
            EmployeeId = 1,
            FirstName = "Anna",
            LastName = "Jensen",
            Email = "anna.jensen@ucl.com",
            Department = "HR"
        },
        new Employee
        {
            EmployeeId = 2,
            FirstName = "Mark",
            LastName = "Christensen",
            Email = "mark.christensen@ucl.com",
            Department = "IT"
        },
        new Employee
        {
            EmployeeId = 3,
            FirstName = "Sofie",
            LastName = "Nielsen",
            Email = "sofie.nielsen@ucl.com",
            Department = "Finance"
        },
        new Employee
        {
            EmployeeId = 4,
            FirstName = "Thomas",
            LastName = "Møller",
            Email = "thomas.moller@ucl.com",
            Department = "Marketing"
        },
        new Employee
        {
            EmployeeId = 5,
            FirstName = "Line",
            LastName = "Poulsen",
            Email = "line.poulsen@ucl.com",
            Department = "Sales"
        },
        new Employee
        {
            EmployeeId = 6,
            FirstName = "Frederik",
            LastName = "Larsen",
            Email = "frederik.larsen@ucl.com",
            Department = "IT"
        },
        new Employee
        {
            EmployeeId = 7,
            FirstName = "Camilla",
            LastName = "Hansen",
            Email = "camilla.hansen@ucl.com",
            Department = "HR"
        },
        new Employee
        {
            EmployeeId = 8,
            FirstName = "Peter",
            LastName = "Mortensen",
            Email = "peter.mortensen@ucl.com",
            Department = "Finance"
        },
        new Employee
        {
            EmployeeId = 9,
            FirstName = "Isabella",
            LastName = "Holm",
            Email = "isabella.holm@ucl.com",
            Department = "Marketing"
        },
        new Employee
        {
            EmployeeId = 10,
            FirstName = "Jonas",
            LastName = "Andersen",
            Email = "jonas.andersen@ucl.com",
            Department = "Sales"
        }
    };

        public static List<Employee> GetAll() => employees;

        public static List<Employee> GetByDepartment(string departmentName)
        {
            return employees.Where(x => x.Department.Equals(departmentName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Employee> GetBySearchFilter(string searchFilter)
        {
            return employees.Where(x => x.FullName.Contains(searchFilter, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

    }
}
