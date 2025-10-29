using System.ComponentModel.DataAnnotations;

namespace PrimerEjercicio.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required, StringLength(120)] public string FullName { get; set; } = "";
        [EmailAddress] public string? Email { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
