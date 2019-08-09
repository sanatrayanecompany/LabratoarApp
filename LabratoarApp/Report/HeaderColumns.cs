using System;
using System.Collections.Generic;

namespace PaymentStationApp.Report
{

    /// <summary>
    /// سر ستون های گزارش
    /// </summary>
    public class HeaderColumns
    {
        public HeaderColumns(List<ColumnsProperties> PropertiesColumn)
        {
            PropertiesColumns = PropertiesColumn;
            //PropertiesColumn.Reverse();
        }

        public List<ColumnsProperties> PropertiesColumns { get; set; }
    }
}
