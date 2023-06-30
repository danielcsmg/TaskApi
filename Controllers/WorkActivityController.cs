using Microsoft.AspNetCore.Mvc;
using TaskApi.Data.Daos;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Data.Dtos;

namespace TaskApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkActivityController : ControllerBase
{
    private IWorkActivityDao _workActivityDao;

    public WorkActivityController(IWorkActivityDao workActivityDao)
    {
        _workActivityDao = workActivityDao;
    }

    [HttpPost]
    public IActionResult CreateActivity([FromBody] CreateWorkActivityDto activityDto)
    {
        try
        {
            _workActivityDao.Add(activityDto);

            return Ok(activityDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAllActivities()
    {
        try
        {
            var workActivities = _workActivityDao.WorkActivities();

            return Ok(workActivities);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("activity/{id}")]
    public IActionResult GetActivityById([FromRoute] string id)
    {
        try
        {
            var workActivity = _workActivityDao.WorkActivity(id);

            return Ok(workActivity);
        }
        catch (NullReferenceException ex)
        {
            return Ok(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("activity/{id}")]
    public IActionResult UpdateActivityById([FromRoute] string id, [FromBody] UpdateWorkActivityDto activityDto)
    {
        try
        {
            var updateActivity = _workActivityDao.Update(id, activityDto);

            return Ok(updateActivity);
        }
        catch (NullReferenceException ex)
        {
            return Ok(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("activity/{id}")]
    public IActionResult DeleteActivityById([FromRoute] string id)
    {
        try
        {
            _workActivityDao.Remove(id);

            return NoContent();
        }
        catch (NullReferenceException ex)
        {
            return Ok(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
