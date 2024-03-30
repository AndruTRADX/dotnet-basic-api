using apidotnet.Models;
using apidotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apidotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    readonly ICategoryService categoryService = categoryService;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoryService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Category category)
    {
        categoryService.Save(category);
        return Ok();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(Guid id, [FromBody] Category category)
    {
        categoryService.Update(id, category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoryService.Delete(id);
        return Ok();
    }
}