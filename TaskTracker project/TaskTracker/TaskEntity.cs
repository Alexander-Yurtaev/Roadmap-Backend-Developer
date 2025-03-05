namespace TaskTracker;

public class TaskEntity(int id, string description)
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;
    public TaskStatus Status { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
}

public enum TaskStatus
{
    Todo,
    InProcess,
    Done
}