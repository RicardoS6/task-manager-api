namespace TaskManagerAPI.Models;

public class TaskItem
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } 
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = "ToDo";
    public DateTime DueDate { get; set; }
}