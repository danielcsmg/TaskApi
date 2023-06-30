using System.ComponentModel.DataAnnotations;
using TaskApi.Models;

namespace TaskApi.Data.Dtos;

public class CreateWorkTaskDto
{
    [Required(ErrorMessage = "O Título da Tarefa é obrigatório")]
    [MaxLength(150, ErrorMessage = "O tamanho do título não pode exceder 150 caracteres")]
    public string Title { get; set; }

    [MaxLength(600, ErrorMessage = "O tamanho da descrição não pode exceder 600 caracteres")]
    public string Description { get; set; }
    public DateTime InitDate { get; set; }
    public ICollection<CreateWorkActivityDto> WorkActivities { get; set; }
    public virtual IList<string>? TaskCategoriesTitle { get; set; }

    [MaxLength(50, ErrorMessage = "O tamanho do status não pode exceder 50 caracteres")]
    public string Status { get; set; }
}
