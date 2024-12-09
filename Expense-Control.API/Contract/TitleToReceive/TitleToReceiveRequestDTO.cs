using Expense_Control.API.Contract.Title;

namespace Expense_Control.API.Contract.NatureLaunch
{
    public class TitleToReceiveRequestDTO : TitleDTO
    {
        public double AmountReceive { get; set; }
        public DateTime? ReceiveDate { get; set; }
    }
}
