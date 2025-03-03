using Newtonsoft.Json;
using TaskTracker;

public partial class Program
{
    private static string GetFilePath()
    {
        var fileName = "task_tracker.json";
        return Path.Combine(Environment.CurrentDirectory, fileName);
    }

    private static List<TaskEntity> LoadAllTasks()
    {
        string filePath = GetFilePath();
        if (!File.Exists(filePath))
        {
            SaveJsonData(new List<TaskEntity>());
        }

        var jsonData = File.ReadAllText(filePath);
        List<TaskEntity> tasks = JsonConvert.DeserializeObject<List<TaskEntity>>(jsonData) ?? [];

        return tasks;
    }

    private static void SaveJsonData(List<TaskEntity> tasks)
    {
        string filePath = GetFilePath();
        string jsonData = JsonConvert.SerializeObject(tasks);

        using var file = File.CreateText(filePath);
        file.Write(jsonData);
    }
}