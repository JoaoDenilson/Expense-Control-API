using Expense_Control.API.Contract.User;
using System.ComponentModel.DataAnnotations;

namespace Expense_Control.API.Domain.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo de email obrigatório")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo de senha obrigatório")]
        public string Password { get; set; } = string.Empty;

        [Required]
        public DateTime RegisterDate { get; set; }

        public DateTime? InactiveDate { get; set; }
    }
}
