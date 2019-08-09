using Stimulsoft.Base.Drawing;
using System.Collections.Generic;
using System.Drawing;

namespace PaymentStationApp.Report
{
    /// <summary>
    /// خصوصیات ستون ها
    /// </summary>
    public class ColumnsProperties
    {
        public bool FormatNumeric { set; internal get; }
        public string Text { set; internal get; }
        public string FooterText { set; internal get; }
        public StiVertAlignment FooterTextVertAlignment { set; internal get; }
        public StiTextHorAlignment FooterTextHorAlignment { set; internal get; }
        public StiVertAlignment HeaderTextVertAlignment { set; internal get; }
        public StiTextHorAlignment HeaderTextHorAlignment { set; internal get; }
        public StiVertAlignment DataTextVertAlignment { set; internal get; }
        public StiTextHorAlignment DataTextHorAlignment { set; internal get; }
        public Font HeaderFont { set; internal get; }
        public Font FooterFont { set; internal get; }
        public Font DataFont { set; internal get; }
        public bool DataTripleSeparator { set; internal get; }
        public bool DataMultiLine { set; internal get; }
        public RectangleD FooterTextPosition { set; internal get; }
        public bool FooterBorder { set; internal get; }
        public StiSolidBrush ForeColor { set; internal get; }
        public double FooterAddToWidth { set; internal get; }
        public double FooterAddToPosition { set; internal get; }
        public double Width { set; internal get; }
        public bool RightToLeft { set; internal get; }
        public bool HeaderRightToLeft { set; internal get; }
        public bool FooterRightToLeft { set; internal get; }
        public StiTextOptions TextOptions { set; internal get; }
        public List<ColumnsProperties> SubColumns { get; set; }
        public ColumnsProperties GeneralProp { get; set; }
    }
}
