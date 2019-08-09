using PaymentStationApp.Models;

namespace PaymentStationApp
{
    public class PaymentRequest : Request
    {
        /// مبلغ
        public string Amount { get; set; }

        public int UnitId { get; set; }
    }
}

