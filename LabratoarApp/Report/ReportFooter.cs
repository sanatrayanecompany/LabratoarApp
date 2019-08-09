using Stimulsoft.Base.Drawing;
using Stimulsoft.Report.Components;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PaymentStationApp.Report
{
    /// <summary>
    /// رکورد انتهایی گزارش که جمع ستون ها توضیحات گزارش و... در این قسمت قرار دارد 
    /// </summary>
    public class ReportFooter
    {
        public ReportFooter(List<StiProperties> Properties)
        {
            FooterProps = Properties;
        }

        public ReportFooter()
        {

        }

        public List<StiProperties> FooterProps { get; set; }

        public StiText LabelBottom1 { set; get; }
        public StiText LabelBottom2 { set; get; }
        public StiText LabelBottom3 { set; get; }

        public void SetLabelBottom1(StiProperties P, string Text, StiProperties generalProp = null)
        {
            LabelBottom1 = new StiText();
            LabelBottom1.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            LabelBottom1.HorAlignment = P.TextHorAlignment;
            LabelBottom1.Name = "LabelBottom1";
            LabelBottom1.Text = Text != null ? Text : LabelBottom1.Text.Value;
            LabelBottom1.VertAlignment = P.TextVertAlignment;
            LabelBottom1.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            LabelBottom1.Brush = new StiSolidBrush(Color.Transparent);
            LabelBottom1.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            LabelBottom1.Guid = Guid.NewGuid().ToString();
            LabelBottom1.Margins =
                P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            LabelBottom1.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            LabelBottom1.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            LabelBottom1.Enabled = true;
        }

        public void SetLabelBottom2(StiProperties P, string Text, StiProperties generalProp = null)
        {
            LabelBottom2 = new StiText();
            LabelBottom2.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            LabelBottom2.HorAlignment = P.TextHorAlignment;
            LabelBottom2.Name = "LabelBottom2";
            LabelBottom2.Text = Text != null ? Text : LabelBottom2.Text.Value;
            LabelBottom2.VertAlignment = P.TextVertAlignment;
            LabelBottom2.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            LabelBottom2.Brush = new StiSolidBrush(Color.Transparent);
            LabelBottom2.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            LabelBottom2.Guid = Guid.NewGuid().ToString();
            LabelBottom2.Margins =
                P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            LabelBottom2.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            LabelBottom2.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            LabelBottom2.Enabled = true;
        }

        public void SetLabelBottom3(StiProperties P, string Text, StiProperties generalProp = null)
        {
            LabelBottom3 = new StiText();
            LabelBottom3.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            LabelBottom3.HorAlignment = P.TextHorAlignment;
            LabelBottom3.Name = "LabelBottom3";
            LabelBottom3.Text = Text != null ? Text : LabelBottom3.Text.Value;
            LabelBottom3.VertAlignment = P.TextVertAlignment;
            LabelBottom3.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            LabelBottom3.Brush = new StiSolidBrush(Color.Transparent);
            LabelBottom3.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            LabelBottom3.Guid = Guid.NewGuid().ToString();
            LabelBottom3.Margins =
                P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            LabelBottom3.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            LabelBottom3.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            LabelBottom3.Enabled = true;
        }
    }
}
