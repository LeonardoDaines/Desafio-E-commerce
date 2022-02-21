using System.ComponentModel.DataAnnotations;

namespace Desafio_E_commerce_Dashboard_Local.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }


        [Required(ErrorMessage = "Por favor insira um nome")]
        [MaxLength(30)]
        [Display(Name = "Nome do Produto")]
        public string ProdutoNome { get; set; }


        [Required(ErrorMessage = "Por favor insira uma descrição")]
        [MaxLength(1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor insira um valor valido")]
        [Range(0, 100000, ErrorMessage = "Por favor insira um valor valido")]
        public double valor { get; set; } = double.MinValue;

        public virtual ICollection<Pedido>? Pedido { get; set; }

    }
}
