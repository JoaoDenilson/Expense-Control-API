using Expense_Control.API.Contract.User;
using System.ComponentModel.DataAnnotations;

namespace Expense_Control.API.Domain.Models
{
    public class NatureLaunch
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Campo de descrição é obrigatório")]
        public string Description { get; set; } = string.Empty;
        public string? Notes { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public DateTime? InactiveDate { get; set; }
    }
}
