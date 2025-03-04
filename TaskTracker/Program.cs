using TaskTracker;
using TaskStatus = TaskTracker.TaskStatus;

var repository = new TaskTrackerRepository();

var (command, arg1, arg2) = ParseArgs(args);

int id;

switch (command)
{
    case "add":
        ArgumentException.ThrowIfNullOrEmpty(arg1);

        AddTask(arg1, repository);
        break;
    case "update":
        if (!int.TryParse(arg1, out id))
        {
            throw new ArgumentException(nameof(id));
        }

        ArgumentException.ThrowIfNullOrEmpty(arg2);

        UpdateTask(id, arg2, repository);
        break;
    case "delete":
        if (!int.TryParse(arg1, out id))
        {
            throw new ArgumentException(nameof(id));
        }

        DeleteTask(id, repository);
        break;
    case "mark-in-progress":
        if (!int.TryParse(arg1, out id))
        {
            throw new ArgumentException(nameof(id));
        }

        MarkInProgressTask(id, repository);
        break;
    case "mark-done":
        if (!int.TryParse(arg1, out id))
        {
            throw new ArgumentException(nameof(id));
        }

        MarkDoneTask(id, repository);
        break;
    case "list":
        TaskStatus? status = null;
        if (!string.IsNullOrEmpty(arg1))
        {
            status = Enum.Parse<TaskStatus>(ToUpperFirstLetter(arg1));
        }

        ListTasks(status, repository);
        break;
    default:
        Console.WriteLine("Unknown command.");
        break;
}