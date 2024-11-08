namespace Expense_Control.API.Contract.User
{
    public class UserRequestDTO : UserLoginRequestDTO
    {
        public string? name { get; set; }
        public DateTime? InactiveDate { get; set; }
    }
}
