namespace Expense_Control.API.Contract.User
{
    public class UserLoginResponseDTO
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
