using System.Collections.Generic;

namespace PaymentStationApp.Report
{
    /// <summary>
    /// دیتای گزارش
    /// </summary>
    public class ReportData
    {
        public IList<object> Data { get; set; }

        public List<string> FieldsName { get; set; }

        public ReportData(IList<object> data)
        {
            Data = data;
        }

        public ReportData(IList<object> data, List<string> fieldsName)
        {
            Data = data;
            FieldsName = fieldsName;
        }
    }
}
