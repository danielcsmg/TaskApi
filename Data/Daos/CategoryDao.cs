using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Data.Dtos;
using TaskApi.Models;

namespace TaskApi.Data.Daos;

public class CategoryDao : ICategoryDao
{
    private WorkTaskContext _context;
    private IMapper _mapper;

    public CategoryDao(WorkTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public Task Add(CreateCategoryDto categoryDto)
    {
        try
        {
            var category = _mapper.Map<Category>(categoryDto);
            _context.Add(category);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex);
            throw new DbUpdateException("Não foi possível cadastrar. A categoria pode já existir.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new Exception(ex.Message);
        }
    }

    public IList<ReadCategoryDto> Categories()
    {
        try
        {
            var categories = _context.Categories.ToList();
            var categoriesDto = new List<ReadCategoryDto>();

            foreach (var category in categories)
            {
                categoriesDto.Add(
                    _mapper.Map<ReadCategoryDto>(category));
            }
            return categoriesDto;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new Exception("Erro ocorrido.");
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task Remove(string id)
    {
        try
        {
            var category = _context.Categories
                .Where(c => c.Id.ToString() == id)
                .FirstOrDefault();

            _context.Remove(category);
            _context.SaveChanges();

            return Task.CompletedTask;  
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new Exception(ex.Message);
        }
    }
}