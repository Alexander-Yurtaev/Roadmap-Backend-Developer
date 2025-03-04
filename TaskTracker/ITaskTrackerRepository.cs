namespace TaskTracker;

public interface ITaskTrackerRepository
{
    List<TaskEntity> LoadAllTasks();
    void SaveJsonData(List<TaskEntity> tasks);
}