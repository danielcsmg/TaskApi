using System.ComponentModel.DataAnnotations;
using TaskApi.Models;

namespace TaskApi.Data.Dtos;

public class ReadWorkTaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime InitDate { get; set; }
    public IList<ReadWorkActivityDto> ReadActivitiesDto { get; set; }
    public IList<Category> Categories { get; set; }
    public string Status { get; set; }
}
