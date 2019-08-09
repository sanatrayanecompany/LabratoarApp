using System;

namespace PaymentStationApp
{
    public class Request
    {
        /// شماره IP دستگاه
        public Int64 CustomerId { get; set; }

        /// شماره IP دستگاه
        public string LocalIP { get; set; }

        /// سریال ترمینال
        public string Serial { get; set; }

        /// کد ترمینال
        public string TerminalID { get; set; }

        /// شماره کارت )فقط اعداد کارت بدون خط تیره و فاصله(
        public string PAN { get; set; }

        /// پین رمز شده
        public string PINBlock { get; set; }

        /// track2 کارت
        public string Track2Ciphered { get; set; }

        /// موبایل
        public static string Mobile { private set; get; }
    }
}

