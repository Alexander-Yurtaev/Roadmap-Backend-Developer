namespace TaskTracker;

public class TaskEntity(int id, string description)
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;
    public TaskStatus Status { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
}

public enum TaskStatus
{
    Todo,
    InProcess,
    Done
}