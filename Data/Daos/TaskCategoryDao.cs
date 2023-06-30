using AutoMapper;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Data.Dtos;
using TaskApi.Models;

namespace TaskApi.Data.Daos;

public class TaskCategoryDao : ITaskCategoryDao
{
    private WorkTaskContext _context;
    private IMapper _mapper;

    public TaskCategoryDao(WorkTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task Add(CreateWorkTaskCategoryDto wtCategoryDto)
    {
        var wtCategory = _mapper.Map<WorkTaskCategory>(wtCategoryDto);

        if (wtCategory == null) {
            throw new NullReferenceException(nameof(wtCategory));
        }

        _context.Add(wtCategory);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Delete(string categorId, string workTaskId)
    {
        var workTaskDelete = _context.TasksCategories
            .Where(
            tc => tc.CategoryId.ToString() == categorId
            && tc.WorkTaskId.ToString() == workTaskId)
            .FirstOrDefault();

        if (workTaskDelete == null)
        {
            throw new NullReferenceException("Não foi encontrado Tarefa ou Categoria.");
        }

        _context.Remove(workTaskDelete);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IList<WorkTaskCategory> TaskCategory()
    {
        return _context.TasksCategories.ToList();
    }
}