using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesJC.Models;

public class Lanche
{
    public int LancheId { get; set; }

    [StringLength(80, MinimumLength = 10 ,ErrorMessage = "O {0} deve ter no mínimo {1} e no maximo {2}")]
    [Required(ErrorMessage = "Informe o nome do lanche")]
    public string Nome { get; set; }

    [StringLength(200, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no maximo {2}")]
    [Required(ErrorMessage = "Informe a descrição do lanche")]
    public string DescricaoCurta { get; set; }

    [StringLength(200, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no maximo {2}")]
    [Required(ErrorMessage = "Informe a descrição do lanche")]
    public string DescricaoDetalhada { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 a 999,99")]
    [Required(ErrorMessage = "Informe o preço do lanche")]
    public decimal Preco { get; set; }

    [StringLength(200, ErrorMessage = "O {0} deve ter no maximo {1}")]
    public string ImagemUrl { get; set; }

    [StringLength(200, ErrorMessage = "O {0} deve ter no maximo {1}")]
    public string ImagemThumbnailUrl { get; set; }

    public bool IsLanchePreferido { get; set; }
    public bool EmEstoque { get; set; }

    public int CategoriaId { get; set; }
    public virtual Categoria Categorias { get; set; }
}