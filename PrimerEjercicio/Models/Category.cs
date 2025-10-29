using System.ComponentModel.DataAnnotations;

namespace PrimerEjercicio.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(80)] public string Name { get; set; } = "";
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
