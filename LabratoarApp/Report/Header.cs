using System.Collections.Generic;

namespace PaymentStationApp.Report
{
    /// <summary>
    /// سرستونهای گزارش برای تولید ستون های پویا
    /// </summary>
    public class Header
    {
        public ColumnsProperties ColumnsProperties;
        public string Name;

        public List<Header> Headers;
        //public dynamic data;
    }
}
