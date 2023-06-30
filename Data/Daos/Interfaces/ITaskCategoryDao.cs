using TaskApi.Data.Dtos;
using TaskApi.Models;

namespace TaskApi.Data.Daos.Interfaces;

public interface ITaskCategoryDao : IDisposable
{
    IList<WorkTaskCategory> TaskCategory();
    Task Add(CreateWorkTaskCategoryDto wtCategoryDto);
    Task Delete(string categorId, string workTaskId);
}