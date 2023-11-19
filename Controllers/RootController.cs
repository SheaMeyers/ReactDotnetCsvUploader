using Microsoft.AspNetCore.Mvc;

namespace CsvUploader.Controllers;

[Route("")]
public class RootController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return File("~/index.html", "text/html"); 
    }
}
