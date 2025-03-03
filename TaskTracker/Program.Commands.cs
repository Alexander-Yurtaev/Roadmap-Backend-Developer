using TaskTracker;

partial class Program
{
    private static (string command, string, string) ParseArgs(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException(nameof(args));
        }

        string command = args[0];
        string arg1 = string.Empty;
        string arg2 = string.Empty;

        if (args.Length > 1)
        {
            arg1 = args[1];
        }

        if (args.Length > 2)
        {
            arg2 = args[2];
        }

        return (command, arg1, arg2);
    }

    private static void AddTask(string description)
    {
        List<TaskEntity> tasks = LoadAllTasks();
        int nextId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
        tasks.Add(new TaskEntity(nextId, description));
        SaveJsonData(tasks);
    }

    private static void UpdateTask(int id, string description)
    {
        List<TaskEntity> tasks = LoadAllTasks();
        TaskEntity? task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine($"Task was not found (ID: {id});");
            return;
        }

        task.Description = description;
        task.UpdateAt = DateTime.Now;

        SaveJsonData(tasks);
    }

    private static void DeleteTask(int id)
    {
        List<TaskEntity> tasks = LoadAllTasks();
        TaskEntity? task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine($"Task was not found (ID: {id});");
            return;
        }

        tasks.Remove(task);

        SaveJsonData(tasks);
    }

    private static void MarkInProgressTask()
    {

    }

    private static void MarkDoneTask()
    {

    }

    private static void ListTasks()
    {
        List<TaskEntity> tasks = LoadAllTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Tasks are not found.");
            return;
        }

        // Output tasks.
    }
}