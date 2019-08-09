namespace PaymentStationApp.Report
{
    /// <summary>
    /// فرمت اجزاء
    /// </summary>
    public class TextFormat
    {
        public string FormatNumeric(object value)
        {
            return "{Format(\"{0:N0}\"," + value.ToString().Replace(" { ", "").Replace(" } ", "") + ")}";
        }
    }
}
