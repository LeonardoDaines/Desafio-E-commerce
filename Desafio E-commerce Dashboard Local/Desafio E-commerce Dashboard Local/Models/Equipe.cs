using System.ComponentModel.DataAnnotations;

namespace Desafio_E_commerce_Dashboard_Local.Models
{
    public class Equipe
    {

        public int EquipeID { get; set; }

        [Required(ErrorMessage = "Por favor insira um nome")]
        [Display(Name = "Nome da equipe")]
        public string EquipeNome { get; set; }

        [Required(ErrorMessage = "Por favor insira uma descrição")]
        [MaxLength(1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor insira uma valor valido")]
        [MaxLength(7)]
        [MinLength(7)]
        [Display(Name = "Placa do veiculo")]
        public string PlacaVeiculo { get; set; }
        public virtual ICollection<Pedido>? Produto { get; set; }

    }
}
