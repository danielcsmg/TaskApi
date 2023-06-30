using System.ComponentModel.DataAnnotations;

namespace TaskApi.Data.Dtos;

public class ReadWorkActivityDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime ConclusionDate { get; set; }
    public double TotalTime { get; set; }
    public string Status { get; set; }
    public Guid WorkTaskId { get; set; }
}
