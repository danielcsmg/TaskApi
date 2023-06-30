using TaskApi.Models;

namespace TaskApi.Data.Daos.Interfaces;

public interface IWorkTaskDao
{
    WorkTask AddWorkTask(WorkTask task);
    IList<WorkTask> GetWorkTasks();
    WorkTask? GetWorkTaskById(string id);
    void DeleteWorkTask(string id);
    void UpdateWorkTask(string id, WorkTask workTask);
}
