using System.ComponentModel.DataAnnotations;

namespace PrimerEjercicio.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int MemberId { get; set; }
        public Member? Member { get; set; }

        [Display(Name = "Fecha de préstamo")]
        [DataType(DataType.Date)]
        public DateTime LoanDate { get; set; } = DateTime.Today;

        [Display(Name = "Fecha de devolución")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(14);

        [Display(Name = "Fecha de devolución real")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
    }
}

