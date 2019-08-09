using Stimulsoft.Base.Drawing;
using Stimulsoft.Report.Components;
using System.Drawing;

namespace PaymentStationApp.Report
{
    /// <summary>
    /// خصوصیات عمومی اجزا
    /// </summary>
    public class StiProperties
    {
        public string Text { set; internal get; }
        public StiVertAlignment TextVertAlignment { set; internal get; }
        public StiTextHorAlignment TextHorAlignment { set; internal get; }

        public RectangleD RectangleD
        {
            set { }
            internal get
            {
                return new RectangleD(marginLeft.CmToInch(),
                    marginTop.CmToInch(),
                    width.CmToInch(),
                    height.CmToInch());
            }
        }

        public Font Font { set; internal get; }
        public StiMargins Margins { set; internal get; }
        public StiSolidBrush ForeColor { set; internal get; }
        public double Width { set; internal get; }
        public StiTextOptions TextOptions { set; internal get; }
        public bool RightToLeft { set; internal get; }
        public bool FormatNumeric { set; get; }

        public double width { set; internal get; }
        public double height { set; internal get; }
        public double marginLeft { set; internal get; }
        public double marginTop { set; internal get; }

        public bool wordWrap
        {
            get { return wordWrap; }
            set
            {
                TextOptions = new StiTextOptions(false, false, true, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            }
        }

    }
}
