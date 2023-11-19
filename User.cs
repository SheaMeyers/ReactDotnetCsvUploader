using System.ComponentModel.DataAnnotations;

namespace ReactDotnetCsvUploader;

public class User
{
    [Key]
    public string? Email { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
}
