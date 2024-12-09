using System.ComponentModel.DataAnnotations;

namespace Expense_Control.API.Domain.Models
{
    public abstract class Title
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
        public long NatureLaunchId { get; set; }
        public NatureLaunch NatureLaunch { get; set; }
        [Required(ErrorMessage = "Campo de descrição é obrigatório")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo valor original é obrigatório")]
        public double OriginalValue { get; set; }        
        public string? Notes { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required(ErrorMessage = "Campo data de vencimento é obrigatório")]
        public DateTime DueDate { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public DateTime? InactiveDate { get; set; }
    }
}
