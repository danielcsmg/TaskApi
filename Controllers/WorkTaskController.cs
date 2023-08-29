using Microsoft.AspNetCore.Mvc;
using TaskApi.Data.Dtos;
using TaskApi.Services;

namespace TaskApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkTaskController : ControllerBase
{
    private WorkTaskService _workTaskService;

    public WorkTaskController(WorkTaskService workTaskService)
    {
        _workTaskService = workTaskService;
    }

    [HttpGet]
    public IActionResult GetWorkTasks()
    {
        var workTaskList = _workTaskService.GetWorkTasks();

        return Ok(workTaskList);
    }

    [HttpPost]
    public IActionResult PostWorkTask([FromBody] CreateWorkTaskDto taskDto)
    {
        _workTaskService.AddWorkTask(taskDto); // Handler
        return Created("Tarefa criada com sucesso", taskDto.Title);
    }

    [HttpGet("{id}")]
    public IActionResult GetWorkTaskById([FromRoute] string id)
    {
        var workTask = _workTaskService.GetWorkTaskById(id);
        return Ok(workTask);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWorkTask([FromRoute] string id)
    {
        _workTaskService.DeleteWorkTask(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateWorkTask([FromRoute] string id, [FromBody] UpdateWorkTaskDto taskDto)
    {
        _workTaskService.UpdateWorkTask(id, taskDto);
        return NoContent();
    }
}
