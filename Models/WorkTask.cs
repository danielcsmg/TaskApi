using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models;

public class WorkTask
{
    [Key]
    public Guid Id { get; internal set; } = Guid.NewGuid();

    [Required(ErrorMessage = "O Título da Tarefa é obrigatório")]
    [MaxLength(150, ErrorMessage = "O tamanho do título não pode exceder 150 caracteres")]
    public string Title { get; set; }

    [MaxLength(600, ErrorMessage = "O tamanho da descrição não pode exceder 600 caracteres")]
    public string Description { get; set; }
    public DateTime InitDate { get; set; }
    public virtual ICollection<WorkActivity>? Activities { get; set; }
    public ICollection<WorkTaskCategory>? WorkTaskCategories { get; set; }

    [MaxLength(50, ErrorMessage = "O tamanho do status não pode exceder 50 caracteres")]
    public string Status { get; set; }

    [Required]
    public bool IsDeleted { get; set; } = false;
}
