using Microsoft.EntityFrameworkCore;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Models;

namespace TaskApi.Data.Daos;

public class WorkTaskDao : IWorkTaskDao
{
    private WorkTaskContext _context;

    public WorkTaskDao(WorkTaskContext context)
    {
        _context = context;
    }

    public WorkTask AddWorkTask(WorkTask task)
    {
        _context.Add(task);
        _context.SaveChanges();
        return task;
    }

    public IList<WorkTaskCategory> GetWorkTasksByCategory(string category)
    {
        throw new NotImplementedException();
    }

    public IList<WorkTask> GetWorkTasks()
    {
        return GetActiveWorkTask()
            .ToList();
    }

    public WorkTask? GetWorkTaskById(string id)
    {
        return _context.WorkTasks
           .FirstOrDefault(wt => wt.IsDeleted == false && wt.Id.ToString() == id);
    }

    public void DeleteWorkTask(string id)
    {
        var deleteWorkTask = GetWorkTaskById(id);
        if (deleteWorkTask != null && !deleteWorkTask.IsDeleted)
        {
            deleteWorkTask.IsDeleted = true;
        }
        _context.SaveChanges();
    }

    public void UpdateWorkTask(string id, WorkTask workTask)
    {
        var workTaskToUpdate = GetWorkTaskById(id);

        if (workTaskToUpdate is not null)
        {
            workTaskToUpdate.Title = workTask.Title;
            workTaskToUpdate.Description = workTask.Description;
            workTaskToUpdate.InitDate = workTask.InitDate;
            workTaskToUpdate.Status = workTask.Status;

            _context.WorkTasks.Update(workTaskToUpdate);
            _context.SaveChanges();
        }
    }

    private IQueryable<WorkTask> GetActiveWorkTask()
    {
        return _context.WorkTasks
            .Include(wt => wt.Activities)
            .Where(wt => wt.IsDeleted == false);
    }
}
