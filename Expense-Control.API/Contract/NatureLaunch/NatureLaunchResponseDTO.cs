namespace Expense_Control.API.Contract.NatureLaunch
{
    public class NatureLaunchResponseDTO : NatureLaunchRequestDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? InactiveDate { get; set; }
    }
}
