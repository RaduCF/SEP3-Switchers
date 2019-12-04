using System.ComponentModel.DataAnnotations;

public class ExampleModel
{
    [Required]
    [StringLength(25, ErrorMessage = "Text is too long.")]
    public string Search { get; set; }
}