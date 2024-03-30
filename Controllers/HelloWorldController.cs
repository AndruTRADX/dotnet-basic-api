using apidotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apidotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController(IHelloWorldService helloWorldService, TasksContext dbContext) : ControllerBase
{
    // The injector will be the interface, not the service
    readonly IHelloWorldService helloWorldService = helloWorldService;
    readonly TasksContext dbContext = dbContext;

    // And lastly, we return the value of the method
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet()]
    [Route("/ensure-created")]
    public IActionResult CreateDatabase()
    {
        return Ok(dbContext.Database.EnsureCreated());
    }
}