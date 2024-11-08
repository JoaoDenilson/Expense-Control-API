namespace Expense_Control.API.Contract.User
{
    public class UserResponseDTO : UserRequestDTO
    {
        public long Id { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
