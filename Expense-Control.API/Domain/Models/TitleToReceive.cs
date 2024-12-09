using Expense_Control.API.Contract.User;
using System.ComponentModel.DataAnnotations;

namespace Expense_Control.API.Domain.Models
{
    public class TitleToReceive : Title
    {
        [Required(ErrorMessage = "Campo valor recebido é obrigatório")]
        public double AmountReceive { get; set; }
        public DateTime? ReceiveDate { get; set; }
    }
}

