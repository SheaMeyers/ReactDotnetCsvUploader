using System.Globalization;
using CsvHelper;
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

[ApiController]
[Route("[controller]")]
public class DownloadController : ControllerBase
{
    [HttpGet("Users")]
    public IActionResult DownloadUsers()
    {
        var users = new List<User>{
            new User { Email = "email1@email.com", FirstName = "First", LastName = "User"},
            new User { Email = "email@email.com", FirstName = "Second", LastName = "User"}
        };

        using var memoryStream = new MemoryStream();
        using var streamWriter = new StreamWriter(memoryStream);
        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(users);
        streamWriter.Flush();
        var result = memoryStream.ToArray();
        var resultMemoryStream = new MemoryStream(result);

        return new FileStreamResult(resultMemoryStream, "text/csv") { FileDownloadName = "exampleDownload.csv"};
    }
}
