var (command, arg1, arg2) = ParseArgs(args);

int id;

switch (command)
{
    case "add":
        ArgumentException.ThrowIfNullOrEmpty(arg1);

        AddTask(arg1);
        break;
    case "update":
        if (!int.TryParse(arg1, out id))
        {
            throw new ArgumentException(nameof(id));
        }

        ArgumentException.ThrowIfNullOrEmpty(arg2);

        UpdateTask(id, arg2);
        break;
    case "delete":
        if (!int.TryParse(arg1, out id))
        {
            throw new ArgumentException(nameof(id));
        }

        DeleteTask(id);
        break;
    //    case "mark-in-progress":
    //        MarkInProgressTask();
    //        break;
    //    case "mark-done":
    //        MarkDoneTask();
    //        break;
    case "list":
        ListTasks();
        break;
    default:
        Console.WriteLine("Unknown command.");
        break;
}