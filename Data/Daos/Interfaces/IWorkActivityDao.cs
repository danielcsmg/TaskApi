using TaskApi.Data.Dtos;
using TaskApi.Models;

namespace TaskApi.Data.Daos.Interfaces;

public interface IWorkActivityDao
{
    Task Add(CreateWorkActivityDto activityDto);
    IList<ReadWorkActivityDto> WorkActivities();
    ReadWorkActivityDto WorkActivity(string id);
    ReadWorkActivityDto Update(string id, UpdateWorkActivityDto activityDto);
    void AddWorkActivities(ICollection<WorkActivity> activities);
    Task Remove(string id);
}
