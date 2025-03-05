using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesJC.Models;
public class Pedido
{
    public int PedidoId { get; set; }

    [Required(ErrorMessage = "Informe o nome")]
    [StringLength(50)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o sobrenome")]
    [StringLength(50)]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = "Informe o seu endereço")]
    [StringLength(100)]
    public string Endereco1 { get; set; }

    [StringLength(100)]
    public string Endereco2 { get; set; }

    [Required(ErrorMessage = "Informe o seu CEP")]
    [StringLength(10, MinimumLength = 8)]
    public string Cep { get; set; }

    [StringLength(10)]
    public string Estado { get; set; }

    [StringLength(50)]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "Informe o seu telefone")]
    [StringLength(25)]
    [DataType(DataType.PhoneNumber)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Informe o email")]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$", 
        ErrorMessage = "O e-mail não possui um formato correto!")]
    public string Email { get; set; }

    [ScaffoldColumn(false)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal PedidoTotal { get; set; }

    [ScaffoldColumn(false)]
    public int TotalItensPedido { get; set; }

    [DataType(DataType.Text)]
    [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
    public DateTime PedidoEnviado { get; set; }

    [DataType(DataType.Text)]
    [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
    public DateTime? PedidoEntregueEm { get; set; }
    public List<PedidoDetalhe> PedidoItens { get; set; }
}