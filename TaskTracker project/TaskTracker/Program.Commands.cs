using TaskTracker;
using TaskStatus = TaskTracker.TaskStatus;

partial class Program
{
    public static int AddTask(string description, ITaskTrackerRepository repository)
    {
        List<TaskEntity> tasks = repository.LoadAllTasks();
        int nextId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
        tasks.Add(new TaskEntity(nextId, description));
        repository.SaveJsonData(tasks);
        return nextId;
    }

    public static void UpdateTask(int id, string description, ITaskTrackerRepository repository)
    {
        List<TaskEntity> tasks = repository.LoadAllTasks();
        TaskEntity? task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine($"Task was not found (ID: {id});");
            return;
        }

        task.Description = description;
        task.UpdateAt = DateTime.UtcNow;

        repository.SaveJsonData(tasks);
    }

    public static void DeleteTask(int id, ITaskTrackerRepository repository)
    {
        List<TaskEntity> tasks = repository.LoadAllTasks();
        TaskEntity? task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine($"Task was not found (ID: {id});");
            return;
        }

        tasks.Remove(task);

        repository.SaveJsonData(tasks);
    }

    public static void MarkInProgressTask(int id, ITaskTrackerRepository repository)
    {
        SetTaskStatus(id, TaskStatus.InProcess, repository);
    }

    public static void MarkDoneTask(int id, ITaskTrackerRepository repository)
    {
        SetTaskStatus(id, TaskStatus.Done, repository);
    }

    public static void SetTaskStatus(int id, TaskStatus status, ITaskTrackerRepository repository)
    {
        List<TaskEntity> tasks = repository.LoadAllTasks();
        TaskEntity? task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine($"Task was not found (ID: {id});");
            return;
        }

        task.Status = status;
        task.UpdateAt = DateTime.UtcNow;

        repository.SaveJsonData(tasks);
    }

    public static void ListTasks(TaskStatus? status, ITaskTrackerRepository repository)
    {
        Console.WriteLine(new string('-', 98));

        Console.WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,18} | {4,18} |",
            "Id", "Description", "Status", "CreateAt", "UpdateAt");

        Console.WriteLine(new string('-', 98));

        List <TaskEntity> tasks = repository.LoadAllTasks(status);

        if (tasks.Count == 0)
        {
            Console.WriteLine("| {0, 82} |", "Tasks are not found.");
            return;
        }

        foreach (TaskEntity entity in tasks)
        {
            Console.WriteLine("| {0,-3} | {1,-35} | {2,-8} | {3,18:dd/MM/yyyy hh:mm} | {4,18:dd/MM/yyyy hh:mm} |",
                entity.Id, entity.Description, entity.Status, entity.CreateAt, entity.UpdateAt);
        }

        Console.WriteLine(new string('-', 98));
    }
}