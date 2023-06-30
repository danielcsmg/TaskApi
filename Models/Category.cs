using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "O tamanho da categoria deve ser entre 3 e 30 caracteres.")]
    [MaxLength(30, ErrorMessage = "O tamanho da categoria deve ser entre 3 e 30 caracteres.")]
    public string Title { get; set; }
    public ICollection<WorkTaskCategory>? WorkTaskCategories { get; set; }
}