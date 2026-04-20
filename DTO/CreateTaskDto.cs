using System.ComponentModel.DataAnnotations;

public class CreateTaskDto
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Status { get; set; } = "ToDo";

    public DateTime? DueDate { get; set; }
}