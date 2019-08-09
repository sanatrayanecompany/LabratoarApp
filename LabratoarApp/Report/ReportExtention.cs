using System;

namespace PaymentStationApp.Report
{
    public static class Extention
    {
        public static double CmToInch(this object Number)
        {
            return (double)Convert.ChangeType(Number, typeof(double)) / 2.54;
        }

        public static double InchToCm(this object Number)
        {
            return (double)Convert.ChangeType(Number, typeof(double)) * 2.54;
        }
    }
}
