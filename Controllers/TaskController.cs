using apidotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apidotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(ITasksService taskService) : ControllerBase
{
    readonly ITasksService taskService = taskService;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(taskService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Models.Task task)
    {
        taskService.Save(task);
        return Ok();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(Guid id, [FromBody] Models.Task task)
    {
        taskService.Update(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        taskService.Delete(id);
        return Ok();
    }
}