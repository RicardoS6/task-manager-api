using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DTOs;

public class UpdateTaskDto
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}