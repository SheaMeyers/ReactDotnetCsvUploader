using Microsoft.AspNetCore.Mvc;
using CsvUploader.Converters;


namespace CsvUploader.Controllers;

[ApiController]
[Route("[controller]")]
public class UploaderController : ControllerBase
{
    [HttpPost("User")]
    public IActionResult UploadUser(IFormFile csvFile)
    {
        try
        {
            var users = FileToEntitiesConverter.GetEntities<User>(csvFile);

            foreach (var user in users) 
            {
                Console.WriteLine(user.Email);
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
            }
        }
        catch
        {
            return BadRequest();
        }

        return Ok();
    }
}
