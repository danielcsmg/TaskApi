using System.ComponentModel.DataAnnotations;

namespace TaskApi.Data.Dtos;

public class CreateCategoryDto
{
    [Required]
    [MaxLength(30, ErrorMessage = "O tamanho da categoria deve ser entre 3 e 30 caracteres.")]
    [MinLength(3, ErrorMessage = "O tamanho da categoria deve ser entre 3 e 30 caracteres.")]
    public string Title { get; set; }
}
