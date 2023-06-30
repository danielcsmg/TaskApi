using System.ComponentModel.DataAnnotations;
using TaskApi.Models;

namespace TaskApi.Data.Dtos;

public class CreateWorkTaskCategoryDto
{
    [Required]
    public Guid WorkTaskId { get; set; }

    [Required]
    public int CategoryId { get; set; }
}
