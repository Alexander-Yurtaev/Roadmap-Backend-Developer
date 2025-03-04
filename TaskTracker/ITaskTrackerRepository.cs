namespace TaskTracker;

public interface ITaskTrackerRepository
{
    List<TaskEntity> LoadAllTasks(TaskStatus? status = null);
    void SaveJsonData(List<TaskEntity> tasks);
}