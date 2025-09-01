using System.ComponentModel.DataAnnotations;

namespace WebApiPruebaTecnica.Models
{
    public class Book
    {
        [Required]
        [Key]  // si lo usas en EF Core; opcional en DTO
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Author { get; set; }

        public string? ISBN { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string? Summary { get; set; }
    }
}
