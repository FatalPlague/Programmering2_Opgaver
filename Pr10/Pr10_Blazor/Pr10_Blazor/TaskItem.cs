namespace Pr10_Blazor
{
    public class TaskItem
    {
        public string Title { get; set; } = string.Empty;
        public bool Done { get; set; }
        public DateTime? Completed { get; set; }
    }
}
