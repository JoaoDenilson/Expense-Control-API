namespace Expense_Control.API.Contract.Title
{
    public abstract class TitleDTO
    {
        public long NatureLaunchId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public double OriginalValue { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReferenceDate { get; set; }
    }
}
