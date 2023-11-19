using System.ComponentModel.DataAnnotations;

namespace CsvUploader;

public class User
{
    [Key]
    public string? Email { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
}
