using apidotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apidotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    // The injector will be the interface, not the service
    IHelloWorldService helloWorldService;

    // We receive the dependency within the constructor
    public HelloWorldController(IHelloWorldService helloWorldService)
    {
        this.helloWorldService = helloWorldService;
    }

    // And lastly, we return the value of the method
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}