namespace PaymentStationApp
{
    public class BillRequest : Request
    {
        // شناسه قبض
        public string BillId { get; set; }
     
        // شناسه پرداخت
        public string PaymentId { get; set; }

        // مبلغ قابل پرداخت
        public string Amount { get; set; }
    }
}

