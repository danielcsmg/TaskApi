using System.ComponentModel.DataAnnotations;

namespace TaskApi.Data.Dtos;

public class DeleteWorkTaskDto
{
    public bool IsDeleted { get; set; } = true;
}
