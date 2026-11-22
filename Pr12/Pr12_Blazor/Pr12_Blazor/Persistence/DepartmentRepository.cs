namespace Pr12_Blazor.Persistence
{
    public static class DepartmentRepository
    {
        private static List<string> departments = new List<string>()
    {
        "HR",
        "Marketing",
        "IT",
        "Finance",
        "Sales"
    };

        public static List<string> GetAll() => departments;

    }
}
