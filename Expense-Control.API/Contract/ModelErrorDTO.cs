namespace Expense_Control.API.Contract
{
    public class ModelErrorDTO
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
