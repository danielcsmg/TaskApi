using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Data.Dtos;
using TaskApi.Models;

namespace TaskApi.Data.Daos;

public class WorkActivityDao : IWorkActivityDao
{
    private WorkTaskContext _context;
    private IMapper _mapper;

    public WorkActivityDao(WorkTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void AddWorkActivities(ICollection<WorkActivity> activities)
    {
        foreach (var activity in activities)
        {
            _context.Add(activity);
            _context.SaveChanges();
        }
        //var changes = _context.ChangeTracker.Entries();
        //foreach (var change in changes)
        //{
        //    Console.WriteLine("Mudanças" + change.Entity);
        //    Console.WriteLine(change);
        //}
    }
    public Task Add(CreateWorkActivityDto activityDto)
    {
        try
        {
            var activity = _mapper.Map<WorkActivity>(activityDto);
            _context.Add(activity);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            throw new ApplicationException("Não foi possível salvar a atividade.");
        }
    }

    public Task Remove(string id)
    {
        try
        {
            var workActivity = _context.WorkActivities
                .Where(a => a.Id.ToString() == id)
                .FirstOrDefault();

            if (workActivity == null)
            {
                throw new NullReferenceException("Atividade não encontrada!");
            }

            _context.Remove(workActivity);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
        catch (NullReferenceException ex)
        {
            throw new ApplicationException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public ReadWorkActivityDto Update(string id, UpdateWorkActivityDto activityDto)
    {
        try
        {
            var workActivity = _context.WorkActivities
                .Where(a => a.Id.ToString() == id)
                .FirstOrDefault();

            if (workActivity == null)
            {
                throw new NullReferenceException("Atividade não encontrada!");
            }

            _mapper.Map(activityDto, workActivity);
            _context.SaveChanges();

            return _mapper.Map<ReadWorkActivityDto>(workActivity);
        }
        catch (NullReferenceException ex)
        {
            throw new ApplicationException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public IList<ReadWorkActivityDto> WorkActivities()
    {
        var workActivities = _context.WorkActivities.ToList();
        var readTaskActivities = new List<ReadWorkActivityDto>();
        foreach (var activity in workActivities)
        {
            var readActivity = _mapper.Map<ReadWorkActivityDto>(activity);
            readTaskActivities.Add(readActivity);
        }

        return readTaskActivities;
    }

    public ReadWorkActivityDto WorkActivity(string id)
    {
        try
        {
            var workActivity = _context.WorkActivities
                .Where(a => a.Id.ToString().Equals(id))
                .ToList()
                .FirstOrDefault();
            var readTaskActivity = _mapper.Map<ReadWorkActivityDto>(workActivity);

            if (readTaskActivity == null)
            {
                throw new NullReferenceException("Não foi encontrado Atividade com esse ID.");
            }

            return readTaskActivity;
        }
        catch (NullReferenceException ex)
        {
            throw new NullReferenceException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
