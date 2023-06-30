using Microsoft.AspNetCore.Mvc;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Data.Daos;
using TaskApi.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace TaskApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private ICategoryDao _categoryDao; // Aqui temos o escopo do que devemos poder fazer na classe

    public CategoryController(ICategoryDao categoryDao) // Neste parâmetro,
                                                        // devemos explicitar o
                                                        // parâmetro que será usado.
                                                        // Porém, com a função .AddTransient()
                                                        // do IServiceCollection, podemos dar a
                                                        // responsabilidade de construção do
                                                        // parâmetro que está sendo usado
                                                        // à classe Program.cs
    {
        _categoryDao = categoryDao; // Aqui temos a construção de um objeto
    }

    [HttpPost]
    public IActionResult CreateWorkTask([FromBody] CreateCategoryDto categoryDto)
    {
        try
        {
            _categoryDao.Add(categoryDto); // Não tem relação com classes, mas com interfaces
            return Created("Criado com sucesso", categoryDto.Title);
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAllWorkTasks()
    {
        IList<ReadCategoryDto> categoryList = _categoryDao.Categories(); // Não tem relação com classes, mas com interfaces

        if (categoryList == null)
        {
            return NotFound();
        }

        return Ok(categoryList);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory([FromRoute] string id)
    {
        try
        {
            _categoryDao.Remove(id); // Não tem relação com classes, mas com interfaces
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
    }
}
