using System.ComponentModel.DataAnnotations;

namespace PraticaCICD.Api.Data.Entities
{
    public class Roupa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Required]
        [MaxLength(5)]
        public string Tamanho { get; set; }

        [Required]
        public decimal Preco { get; set; }
    }
}
