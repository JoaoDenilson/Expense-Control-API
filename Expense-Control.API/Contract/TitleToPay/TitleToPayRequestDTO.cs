namespace Expense_Control.API.Contract.NatureLaunch
{
    public class TitleToPayRequestDTO
    {
        public long NatureLaunchId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public double OriginalValue { get; set; }
        public double AmountPaid { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
