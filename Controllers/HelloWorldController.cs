using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;
    IHelloWorldService helloWorldService;

    TareasContext dbcontext;

    public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorld, TareasContext db)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet(Name = "GetHelloWorld")]
    public IActionResult Get()
    {
        _logger.LogInformation("Saying hellowwwww!");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
}