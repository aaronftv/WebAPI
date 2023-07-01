using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    ICategoryService categoryService;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService service)
    {
        _logger = logger;
        categoryService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoryService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria category)
    {
        categoryService.Add(category);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria category)
    {
        categoryService.Update(id, category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _logger.LogInformation("----------------------------- id: " + id);
        categoryService.Delete(id);
        return Ok();
    }
}