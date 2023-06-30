using System.ComponentModel.DataAnnotations;

namespace TaskApi.Data.Dtos;

public class UpdateWorkActivityDto
{
    [Required(ErrorMessage = "O Título da atividade é obrigatório")]
    [MaxLength(150, ErrorMessage = "O tamanho do título não pode exceder 150 caracteres")]
    public string Title { get; set; }

    [MaxLength(600, ErrorMessage = "O tamanho da descrição não pode exceder 600 caracteres")]
    public string Description { get; set; }

    [Required]
    public DateTime InitDate { get; set; }

    [Required]
    public DateTime ConclusionDate { get; set; }
    public double TotalTime { get; set; }

    [MaxLength(50, ErrorMessage = "O tamanho do status não pode exceder 50 caracteres")]
    public string Status { get; set; }
}
