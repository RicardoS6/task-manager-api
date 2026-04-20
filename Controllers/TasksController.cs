using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;
using TaskManagerAPI.DTOs;
using System.Security.Claims;

namespace TaskManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
   
    private readonly AppDbContext _context;

    
    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public IActionResult GetTasks()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var tasks = _context.Tasks
            .Where(t => t.UserId == userId)
            .Select(t => new TaskResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted,
                Description = t.Description,
                Status = t.Status,
                DueDate = t.DueDate
            })
            .ToList(); 

        return Ok(tasks);
    }
       

    [HttpPost]
    public IActionResult CreateTask(CreateTaskDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = dto.Status,
            DueDate = dto.DueDate ?? DateTime.UtcNow,
            UserId = userId,
            IsCompleted = false
        };

        _context.Tasks.Add(task);
        _context.SaveChanges();

        return Ok(task);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, UpdateTaskDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound();

        if (task.UserId != userId)
            return Forbid();

        task.Title = dto.Title;
        task.IsCompleted = dto.IsCompleted;

        _context.SaveChanges();

        return Ok(task);
    }

    [HttpDelete("{id}")]
public IActionResult DeleteTask(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

           if (task == null)
        return NotFound();

    
           if (task.UserId != userId)
        return Forbid();

          _context.Tasks.Remove(task);
          _context.SaveChanges();

        return Ok("Deleted");
    }

}