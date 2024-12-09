using Expense_Control.API.Contract.User;
using System.ComponentModel.DataAnnotations;

namespace Expense_Control.API.Domain.Models
{
    public class TitleToPay : Title
    {
        [Required(ErrorMessage = "Campo valor pago é obrigatório")]
        public double AmountPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
