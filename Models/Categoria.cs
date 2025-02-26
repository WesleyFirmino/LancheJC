using System.ComponentModel.DataAnnotations;

namespace LanchesJC.Models;

public class Categoria
{
    public int CategoriaId { get; set; }

    [StringLength(100, ErrorMessage = "O tamanho maximo é 100 caracteres")]
    [Required(ErrorMessage = "Informe o nome da categoria")]
    public string? Nome { get; set; }

    [StringLength(200, MinimumLength = 5, ErrorMessage = "O tamanho maximo é 200 caracteres")]
    [Required(ErrorMessage = "Informe a descrição")]
    public string? Descricao { get; set; }

    public List<Lanche>? Lanches { get; set; }
}