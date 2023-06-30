using Microsoft.AspNetCore.Mvc;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Data.Daos;
using TaskApi.Data.Dtos;
using TaskApi.Models;

namespace TaskApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskCategoryController : ControllerBase
{
    private ITaskCategoryDao _wtCategoryDao;

    public TaskCategoryController(ITaskCategoryDao taskCategory)
    {
        _wtCategoryDao = taskCategory;
    }

    [HttpPost]
    public IActionResult CreateWorkTaskCategory([FromBody] CreateWorkTaskCategoryDto wtCategoryDto)
    {
        try
        {
            _wtCategoryDao.Add(wtCategoryDto);
            return Created("Criado com sucesso", wtCategoryDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAllWtCategories()
    {
        IList<WorkTaskCategory> categoryList = _wtCategoryDao.TaskCategory();

        if (categoryList == null)
        {
            return NotFound();
        }

        return Ok(categoryList);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory([FromRoute] string workTaskId, [FromRoute] string categoryId)
    {
        /*
        try
        {
            _workTaskCategoryDao.Remove(workTaskId, categoryId);
            return NoContent();
        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return BadRequest();
        }
        */
        throw new NotImplementedException();
    }
}
