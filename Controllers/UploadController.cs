using Microsoft.AspNetCore.Mvc;
using ReactDotnetCsvUploader.Converters;


namespace ReactDotnetCsvUploader.Controllers;

[ApiController]
[Route("[controller]")]
public class UploadController : ControllerBase
{
    [HttpPost("User")]
    public IActionResult UploadUser(IFormFile csvFile)
    {
        try
        {
            var users = FileToEntitiesConverter.GetEntities<User>(csvFile);

            foreach (var user in users) 
            {
                Console.WriteLine("----- User ----");
                Console.WriteLine(user.Email);
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }

        return Ok();
    }
}
