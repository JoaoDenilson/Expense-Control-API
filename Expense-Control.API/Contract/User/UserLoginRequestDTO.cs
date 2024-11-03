namespace Expense_Control.API.Contract.User
{
    public class UserLoginRequestDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
