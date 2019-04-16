namespace Chinook.Domain.Responses
{
    public class InvoiceLineResponse
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public InvoiceResponse Invoice { get; set; }
        public TrackResponse Track { get; set; }
    }
}