namespace Chinook.Domain.ViewModels
{
    public class InvoiceLineViewModel
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public InvoiceViewModel Invoice { get; set; }
        public TrackViewModel Track { get; set; }
    }
}
