namespace Expense_Control.API.Contract.NatureLaunch
{
    public class TitleToReceiveResponseDTO : TitleToReceiveRequestDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? InactiveDate { get; set; }
    }
}
