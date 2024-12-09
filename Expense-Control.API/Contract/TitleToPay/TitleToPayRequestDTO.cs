using Expense_Control.API.Contract.Title;

namespace Expense_Control.API.Contract.NatureLaunch
{
    public class TitleToPayRequestDTO : TitleDTO
    {
        public double AmountPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
