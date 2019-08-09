using PaymentStationApp.Enums;

namespace PaymentStationApp
{
    public class TopupRequest : Request
    {
        // مبلغ
        public string Amount { get; set; }

        // موبایل
        public string Mobile { get; set; }

        // طرح
        public int ProfileId { get; set; }

        //اپراتور
        public VoucherOperator VoucherOperator { get; set; }
    }
}

