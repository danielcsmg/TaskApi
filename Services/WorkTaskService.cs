using AutoMapper;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Data.Dtos;
using TaskApi.Models;

namespace TaskApi.Services;

public class WorkTaskService
{
    private IWorkTaskDao _workTaskDao;
    private IWorkActivityDao _workActivityDao;
    private IMapper _mapper;

    public WorkTaskService(IWorkTaskDao dao, IMapper mapper, IWorkActivityDao workActivityDao)
    {
        _workTaskDao = dao;
        _mapper = mapper;
        _workActivityDao = workActivityDao;
    }

    public void AddWorkTask(CreateWorkTaskDto createWorkTask)
    {
        var workTask = _mapper.Map<WorkTask>(createWorkTask);
        var workActivities = workTask.Activities;

        if (workTask is not null)
        {
            workTask.Activities = null;
            _workTaskDao.AddWorkTask(workTask);
        }

        if (workActivities is not null)
        {
            foreach (var activity in workActivities)
            {
                activity.WorkTaskId = workTask.Id;
            }
            _workActivityDao.AddWorkActivities(workActivities);
        }
    }

    public IList<ReadWorkTaskDto> GetWorkTasks()
    {
        var workTasks = _workTaskDao.GetWorkTasks();
        List<ReadWorkTaskDto> readWorkTasks = ReadWorkTask(workTasks);
        return readWorkTasks;
    }

    public ReadWorkTaskDto GetWorkTaskById(string id)
    {
        var workTask = _workTaskDao.GetWorkTaskById(id);
        return _mapper.Map<ReadWorkTaskDto>(workTask);
    }

    public void DeleteWorkTask(string id)
    {
        _workTaskDao.DeleteWorkTask(id);
    }

    private List<ReadWorkTaskDto> ReadWorkTask(IList<WorkTask> workTasks)
    {
        return _mapper.Map<List<ReadWorkTaskDto>>(workTasks);
    }

    public void UpdateWorkTask(string id, UpdateWorkTaskDto updateWorkTask)
    {
        var workTask = _mapper.Map<WorkTask>(updateWorkTask);
        _workTaskDao.UpdateWorkTask(id, workTask);
    }
}
