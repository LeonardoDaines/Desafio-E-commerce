using System.ComponentModel.DataAnnotations;

namespace Desafio_E_commerce_Dashboard_Local.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Display(Name = "Data de Criação")]
        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;


        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Display(Name = "Data de entrega")]
        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; } = DateTime.UtcNow;


        [Required(ErrorMessage = "Favor insira um endereço valido"), MaxLength(120), MinLength(10)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }


        public virtual int? ProdutoID { get; set; }
        public virtual int? EquipeID { get; set; }
        public virtual Produto? Produto { get; set; }
        public virtual Equipe? Equipe { get; set; }

    }
}
