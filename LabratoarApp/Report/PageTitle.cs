using Stimulsoft.Base.Drawing;
using Stimulsoft.Report.Components;
using System;
using System.Drawing;

namespace PaymentStationApp.Report
{
    public class PageTitle : ReportUIGenerator
    {
        public PageTitle()
            : base()
        {
            TopTitle = new StiText() { Enabled = false };
            Title = new StiText() { Enabled = false };
            BottomTitle = new StiText() { Enabled = false };
            Label1 = new StiText() { Enabled = false };
            Label2 = new StiText() { Enabled = false };
            Label3 = new StiText() { Enabled = false };
            Label4 = new StiText() { Enabled = false };
            Label5 = new StiText() { Enabled = false };
            Label6 = new StiText() { Enabled = false };
            Label7 = new StiText() { Enabled = false };
            Text1 = new StiText() { Enabled = false };
            Text2 = new StiText() { Enabled = false };
            Text3 = new StiText() { Enabled = false };
            Text4 = new StiText() { Enabled = false };
            Text5 = new StiText() { Enabled = false };
            Text6 = new StiText() { Enabled = false };
            Text7 = new StiText() { Enabled = false };

            BottomSpace = new StiText();
        }

        public StiText TopTitle { set; get; }
        public StiText Title { set; get; }

        public StiText BottomTitle { set; get; }
        public StiText Label1 { set; get; }
        public StiText Label2 { set; get; }
        public StiText Label3 { set; get; }
        public StiText Label4 { set; get; }
        public StiText Label5 { set; get; }
        public StiText Label6 { set; get; }
        public StiText Label7 { set; get; }
        public StiText Text1 { set; get; }
        public StiText Text2 { set; get; }
        public StiText Text3 { set; get; }
        public StiText Text4 { set; get; }
        public StiText Text5 { set; get; }
        public StiText Text6 { set; get; }
        public StiText Text7 { set; get; }
        public StiText BottomSpace { set; get; }
        public StiImage Image1 { set; get; }
        public StiImage Image2 { set; get; }

        public void SetImagePath1(string path)
        {
            Image1 = new StiImage();
            Image1.Name = "Image1";
            Image1.Stretch = true;
            Image1.Border = new StiBorder(StiBorderSides.None, Color.Black, 1, StiPenStyle.Solid);
            Image1.Brush = new StiSolidBrush(Color.Transparent);
            Image1.Guid = Guid.NewGuid().ToString();
            Image1.Interaction = null;

            if (path != null)
            {
                Bitmap bmp1 = new Bitmap(path);
                Image1.Image = StiImageConverter.StringToImage(StiImageConverter.ImageToString(bmp1));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="SpaceTop"></param>
        public void SetImage1(Bitmap bmp, double? Width = null, double? Height = null, double? TopMargin = null,
            double? LeftMargin = null)
        {
            Image1 = new StiImage();
            if (bmp != null)
            {
                Image1.Image = StiImageConverter.StringToImage(StiImageConverter.ImageToString(bmp));
                Image1.Name = "Image1";
                Image1.Stretch = true;
                Image1.Border = new StiBorder(StiBorderSides.None, Color.Black, 1, StiPenStyle.Solid);
                Image1.Brush = new StiSolidBrush(Color.Transparent);
                Image1.Guid = Guid.NewGuid().ToString();
                Image1.Interaction = null;
                if (Width != null && Height != null && TopMargin != null && LeftMargin != null)
                {
                    Image1.ClientRectangle = new RectangleD(
                        LeftMargin.CmToInch(), //محور افقی به سانتیمتر
                        TopMargin.CmToInch(), //محور عمودی 
                        Width.CmToInch(), //طول
                        Height.CmToInch()); //عرض
                }
            }
        }

        public void SetImagePath2(string path)
        {
            Image2 = new StiImage();
            Image2 = new StiImage();
            Image2.Name = "Image2";
            Image2.Stretch = true;
            Image2.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Image2.Brush = new StiSolidBrush(Color.Transparent);
            Image2.Guid = Guid.NewGuid().ToString();
            Image2.Interaction = null;
            if (path != null)
            {
                Bitmap bmp = new Bitmap(path);
                Image2.Image = StiImageConverter.StringToImage(StiImageConverter.ImageToString(bmp));
            }
        }

        public void SetTopTitle(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);

            TopTitle = new StiText();
            TopTitle.ClientRectangle = P.RectangleD; // new RectangleD(2.88, 0.86, 1.71, 0.23);
            TopTitle.AutoWidth = true;
            //TopTitle.DockStyle = StiDockStyle.Top;
            TopTitle.HorAlignment = P.TextHorAlignment;
            TopTitle.Name = "TopTitle";
            TopTitle.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            TopTitle.VertAlignment = P.TextVertAlignment;
            TopTitle.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid);
            TopTitle.Brush = new StiSolidBrush(Color.Transparent);
            TopTitle.Font = new Font("B Nazanin", 12F, FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            TopTitle.Guid = Guid.NewGuid().ToString();
            TopTitle.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            TopTitle.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush
                    (Color.Black);
            TopTitle.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            TopTitle.Enabled = true;
            TopTitle.VertAlignment = StiVertAlignment.Center;
            TopTitle.HorAlignment = StiTextHorAlignment.Center;
        }

        public void SetCenterTitle(StiProperties p, StiProperties generalProp = null)
        {
            p = Join2Prop(p, generalProp);

            //Title = new StiText(new RectangleD());
            Title.ClientRectangle = p.RectangleD; // new RectangleD(0, 0, 277.2, 21.82);
            Title.AutoWidth = true;
            //Title.DockStyle = StiDockStyle.Top;
            Title.HorAlignment = p.TextHorAlignment;
            Title.Name = "Title";
            Title.Text = p.FormatNumeric ? new TextFormat().FormatNumeric(p.Text) : p.Text;
            Title.VertAlignment = p.TextVertAlignment;
            Title.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            Title.Brush = new StiSolidBrush(Color.Transparent);
            Title.Font = p.Font != null
                ? p.Font
                : new Font("B Nazanin", 12F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Title.Guid = Guid.NewGuid().ToString();
            Title.Margins = p.Margins != null ? p.Margins : new StiMargins(0, 0, 0, 0);
            Title.TextBrush = p.ForeColor != null
                ? p.ForeColor
                : new StiSolidBrush(Color.Black);
            Title.TextOptions = p.TextOptions != null
                ? p.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Title.Enabled = true;
        }

        public void SetBottomTitle(StiProperties p, StiProperties generalProp = null)
        {
            p = Join2Prop(p, generalProp);

            //BottomTitle = new StiText();

            BottomTitle.ClientRectangle = p.RectangleD; // new RectangleD(2.88, 0.86, 1.71, 0.23);
            BottomTitle.AutoWidth = true;
            //BottomTitle.DockStyle = StiDockStyle.Top;
            BottomTitle.HorAlignment = p.TextHorAlignment;
            BottomTitle.Name = "BottomTitle";
            BottomTitle.Text = p.FormatNumeric ? new TextFormat().FormatNumeric(p.Text) : p.Text;
            BottomTitle.VertAlignment = p.TextVertAlignment;
            BottomTitle.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            BottomTitle.Brush = new StiSolidBrush(Color.Transparent);
            BottomTitle.Font = new Font("B Nazanin", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 178);
            BottomTitle.Guid = Guid.NewGuid().ToString();
            BottomTitle.Margins =
                p.Margins != null ? p.Margins : new StiMargins(0, 0, 0, 0);
            BottomTitle.TextBrush = p.ForeColor != null
                ? p.ForeColor
                : new StiSolidBrush
                    (Color.Black);
            BottomTitle.TextOptions = p.TextOptions != null
                ? p.TextOptions
                : new StiTextOptions(true, false,
                    false, 0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            BottomTitle.Enabled = true;
        }

        public void SetLabel1(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);

            Label1 = new StiText();
            Label1.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label1.HorAlignment = P.TextHorAlignment;
            Label1.Name = "Label1";
            Label1.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Label1.VertAlignment = P.TextVertAlignment;
            Label1.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid);
            Label1.Brush = new StiSolidBrush(Color.Transparent);
            Label1.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label1.Guid = Guid.NewGuid().ToString();
            Label1.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label1.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label1.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label1.Enabled = true;
        }

        public void SetLabel2(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);

            Label2 = new StiText();
            Label2.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label2.HorAlignment = P.TextHorAlignment;
            Label2.Name = "Label2";
            Label2.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Label2.VertAlignment = P.TextVertAlignment;
            Label2.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid);
            Label2.Brush = new StiSolidBrush(Color.Transparent);
            Label2.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label2.Guid = Guid.NewGuid().ToString();
            Label2.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label2.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label2.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label2.Enabled = true;
        }

        public void SetLabel3(StiProperties P, StiProperties generalProp = null)
        {

            P = Join2Prop(P, generalProp);

            Label3 = new StiText();
            Label3.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label3.HorAlignment = P.TextHorAlignment;
            Label3.Name = "Label3";
            Label3.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Label3.VertAlignment = P.TextVertAlignment;
            Label3.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid);
            Label3.Brush = new StiSolidBrush(Color.Transparent);
            Label3.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label3.Guid = Guid.NewGuid().ToString();
            Label3.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label3.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label3.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label3.Enabled = true;
        }

        public void SetLabel4(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);

            Label4 = new StiText();
            Label4.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label4.HorAlignment = P.TextHorAlignment;
            Label4.Name = "Label4";
            Label4.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Label4.VertAlignment = P.TextVertAlignment;
            Label4.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid);
            Label4.Brush = new StiSolidBrush(Color.Transparent);
            Label4.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label4.Guid = Guid.NewGuid().ToString();
            Label4.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label4.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label4.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label4.Enabled = true;
        }

        public void SetLabel5(StiProperties P, StiProperties generalProp = null)
        {

            P = Join2Prop(P, generalProp);

            Label5 = new StiText();
            Label5.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label5.HorAlignment = P.TextHorAlignment;
            Label5.Name = "Label5";
            Label5.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Label5.VertAlignment = P.TextVertAlignment;
            Label5.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid
            );
            Label5.Brush = new StiSolidBrush(Color.Transparent);
            Label5.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label5.Guid = Guid.NewGuid().ToString();
            Label5.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label5.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label5.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label5.Enabled = true;
        }

        public void SetLabel6(StiProperties P, StiProperties generalProp = null)
        {

            P = Join2Prop(P, generalProp);

            Label6 = new StiText();
            Label6.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label6.HorAlignment = P.TextHorAlignment;
            Label6.Name = "Label6";
            Label6.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Label6.VertAlignment = P.TextVertAlignment;
            Label6.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid
            );
            Label6.Brush = new StiSolidBrush(Color.Transparent);
            Label6.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label6.Guid = Guid.NewGuid().ToString();
            Label6.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label6.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label6.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label6.Enabled = true;
        }

        public void SetLabel7(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Label7 = new StiText();
            Label7.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label7.HorAlignment = P.TextHorAlignment;
            Label7.Name = "Label7";
            Label7.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Label7.VertAlignment = P.TextVertAlignment;
            Label7.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid);
            Label7.Brush = new StiSolidBrush(Color.Transparent);
            Label7.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label7.Guid = Guid.NewGuid().ToString();
            Label7.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label7.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label7.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label7.Enabled = true;
        }

        public void SetText1(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text1 = new StiText();
            Text1.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text1.HorAlignment = P.TextHorAlignment;
            Text1.Name = "Text1";
            Text1.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Text1.VertAlignment = P.TextVertAlignment;
            Text1.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Text1.Brush = new StiSolidBrush(Color.Transparent);
            Text1.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text1.Guid = Guid.NewGuid().ToString();
            Text1.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text1.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text1.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text1.Enabled = true;
        }

        public void SetText2(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text2 = new StiText();
            Text2.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text2.HorAlignment = P.TextHorAlignment;
            Text2.Name = "Text2";
            Text2.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Text2.VertAlignment = P.TextVertAlignment;
            Text2.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            Text2.Brush = new StiSolidBrush(Color.Transparent);
            Text2.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text2.Guid = Guid.NewGuid().ToString();
            Text2.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text2.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text2.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);

            Text2.Enabled = true;
        }

        public void SetText3(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text3 = new StiText();
            Text3.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text3.HorAlignment = P.TextHorAlignment;
            Text3.Name = "Text3";
            Text3.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Text3.VertAlignment = P.TextVertAlignment;
            Text3.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            Text3.Brush = new StiSolidBrush(Color.Transparent);
            Text3.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text3.Guid = Guid.NewGuid().ToString();
            Text3.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text3.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text3.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text3.Enabled = true;
        }

        public void SetText4(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text4 = new StiText();
            Text4.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text4.HorAlignment = P.TextHorAlignment;
            Text4.Name = "Text4";
            Text4.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Text4.VertAlignment = P.TextVertAlignment;
            Text4.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            Text4.Brush = new StiSolidBrush(Color.Transparent);
            Text4.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text4.Guid = Guid.NewGuid().ToString();
            Text4.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text4.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text4.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text4.Enabled = true;
        }

        public void SetText5(StiProperties P, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text5 = new StiText();
            Text5.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text5.HorAlignment = P.TextHorAlignment;
            Text5.Name = "Text5";
            Text5.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Text5.VertAlignment = P.TextVertAlignment;
            Text5.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            Text5.Brush = new StiSolidBrush(Color.Transparent);
            Text5.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text5.Guid = Guid.NewGuid().ToString();
            Text5.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text5.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text5.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text5.Enabled = true;
        }

        public void SetText6(StiProperties P, StiProperties generalProp = null)
        {

            P = Join2Prop(P, generalProp);

            Text6 = new StiText();
            Text6.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text6.HorAlignment = P.TextHorAlignment;
            Text6.Name = "Text6";
            Text6.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Text6.VertAlignment = P.TextVertAlignment;
            Text6.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            Text6.Brush = new StiSolidBrush(Color.Transparent);
            Text6.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text6.Guid = Guid.NewGuid().ToString();
            Text6.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text6.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text6.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text6.Enabled = true;
        }

        public void SetText7(StiProperties P, StiProperties generalProp = null)
        {

            P = Join2Prop(P, generalProp);

            Text7 = new StiText();
            Text7.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text7.HorAlignment = P.TextHorAlignment;
            Text7.Name = "Text7";
            Text7.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            Text7.VertAlignment = P.TextVertAlignment;
            Text7.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            Text7.Brush = new StiSolidBrush(Color.Transparent);
            Text7.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text7.Guid = Guid.NewGuid().ToString();
            Text7.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text7.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text7.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text7.Enabled = true;
        }

        public void SetBottomSpace()
        {
            BottomSpace = new StiText(new RectangleD(160.88.CmToInch(), 31.CmToInch(), 27.43.CmToInch(), 5.08.CmToInch()));
            BottomSpace = new StiText();
            BottomSpace.Name = "BottomSpace";
            BottomSpace.Text = @"    ";
            BottomSpace.Guid = Guid.NewGuid().ToString();
            BottomSpace.Enabled = true;
            BottomSpace.DockStyle = StiDockStyle.Bottom;
        }

        public void SetBottomSpace(StiProperties P, StiProperties generalProp = null)
        {

            P = Join2Prop(P, generalProp);

            BottomSpace = new StiText();
            BottomSpace.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            BottomSpace.HorAlignment = P.TextHorAlignment;
            BottomSpace.Name = "BottomSpace";
            BottomSpace.Text = P.FormatNumeric ? new TextFormat().FormatNumeric(P.Text) : P.Text;
            BottomSpace.VertAlignment = P.TextVertAlignment;
            BottomSpace.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid
            );
            BottomSpace.Brush = new StiSolidBrush(Color.Transparent);
            BottomSpace.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            BottomSpace.Guid = Guid.NewGuid().ToString();
            BottomSpace.Margins =
                P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            BottomSpace.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush
                    (Color.Black);
            BottomSpace.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false,
                    false, 0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            BottomSpace.Enabled = true;
        }

        public void SetTopTitle(StiProperties P, string Text, StiProperties generalProp = null)
        {

            P = Join2Prop(P, generalProp);

            TopTitle = new StiText();
            TopTitle.ClientRectangle = P.RectangleD; // new RectangleD(2.88, 0.86, 1.71, 0.23);
            TopTitle.AutoWidth = true;
            TopTitle.DockStyle = StiDockStyle.Top;
            TopTitle.HorAlignment = P.TextHorAlignment;
            TopTitle.Name = "TopTitle";
            TopTitle.Text = Text;
            TopTitle.VertAlignment = P.TextVertAlignment;
            TopTitle.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid
            );
            TopTitle.Brush = new StiSolidBrush(Color.Transparent);
            TopTitle.Font = new Font("B Nazanin", 9.75F, FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            TopTitle.Guid = Guid.NewGuid().ToString();
            TopTitle.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            TopTitle.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush
                    (Color.Black);
            TopTitle.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            TopTitle.Enabled = true;
        }

        public void SetTitle(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            //Title = new StiText(new RectangleD());
            Title.ClientRectangle = P.RectangleD; // new RectangleD(0, 0, 277.2, 21.82);
            Title.AutoWidth = true;
            //Title.DockStyle = StiDockStyle.Top;
            Title.HorAlignment = P.TextHorAlignment;
            Title.Name = "Title";
            Title.Text = Text;
            Title.VertAlignment = P.TextVertAlignment;
            Title.Border = new StiBorder(StiBorderSides.None, Color.Black,
                1, StiPenStyle.Solid);
            Title.Brush = new StiSolidBrush(Color.Transparent);
            Title.Font = P.Font != null
                ? P.Font
                : new Font("B Titr", 15.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Title.Guid = Guid.NewGuid().ToString();
            Title.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Title.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Title.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Title.Enabled = true;
        }

        public void SetBottomTitle(StiProperties p, string Text, StiProperties generalProp = null)
        {
            p = Join2Prop(p, generalProp);
            BottomTitle = new StiText();
            BottomTitle.ClientRectangle = p.RectangleD; // new RectangleD(2.88, 0.86, 1.71, 0.23);
            BottomTitle.AutoWidth = true;
            BottomTitle.DockStyle = StiDockStyle.Top;
            BottomTitle.HorAlignment = p.TextHorAlignment;
            BottomTitle.Name = "BottomTitle";
            BottomTitle.Text = Text;
            BottomTitle.VertAlignment = p.TextVertAlignment;
            BottomTitle.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid
            );
            BottomTitle.Brush = new StiSolidBrush(Color.Transparent);
            BottomTitle.Font = new Font("B Nazanin", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 178);
            BottomTitle.Guid = Guid.NewGuid().ToString();
            BottomTitle.Margins =
                p.Margins != null ? p.Margins : new StiMargins(0, 0, 0, 0);
            BottomTitle.TextBrush = p.ForeColor != null
                ? p.ForeColor
                : new StiSolidBrush
                    (Color.Black);
            BottomTitle.TextOptions = p.TextOptions != null
                ? p.TextOptions
                : new StiTextOptions(true, false,
                    false, 0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            BottomTitle.Enabled = true;
        }

        public void SetLabel1(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Label1 = new StiText();
            Label1.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label1.HorAlignment = P.TextHorAlignment;
            Label1.Name = "Label1";
            Label1.Text = Text;
            Label1.VertAlignment = P.TextVertAlignment;
            Label1.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid
            );
            Label1.Brush = new StiSolidBrush(Color.Transparent);
            Label1.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label1.Guid = Guid.NewGuid().ToString();
            Label1.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label1.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label1.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label1.Enabled = true;
        }

        public void SetLabel2(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Label2 = new StiText();
            Label2.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label2.HorAlignment = P.TextHorAlignment;
            Label2.Name = "Label2";
            Label2.Text = Text;
            Label2.VertAlignment = P.TextVertAlignment;
            Label2.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid
            );
            Label2.Brush = new StiSolidBrush(Color.Transparent);
            Label2.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label2.Guid = Guid.NewGuid().ToString();
            Label2.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label2.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label2.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label2.Enabled = true;
        }

        public void SetLabel3(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Label3 = new StiText();
            Label3.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label3.HorAlignment = P.TextHorAlignment;
            Label3.Name = "Label3";
            Label3.Text = Text;
            Label3.VertAlignment = P.TextVertAlignment;
            Label3.Border = new StiBorder(StiBorderSides.None,
                Color.Black, 1, StiPenStyle.Solid);
            Label3.Brush = new StiSolidBrush(Color.Transparent);
            Label3.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label3.Guid = Guid.NewGuid().ToString();
            Label3.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label3.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label3.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false,
                    0F, System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label3.Enabled = true;
        }

        public void SetLabel4(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);

            Label4 = new StiText();
            Label4.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label4.HorAlignment = P.TextHorAlignment;
            Label4.Name = "Label4";
            Label4.Text = Text;
            Label4.VertAlignment = P.TextVertAlignment;
            Label4.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Label4.Brush = new StiSolidBrush(Color.Transparent);
            Label4.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label4.Guid = Guid.NewGuid().ToString();
            Label4.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label4.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label4.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label4.Enabled = true;
        }

        public void SetLabel5(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Label5 = new StiText();
            Label5.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label5.HorAlignment = P.TextHorAlignment;
            Label5.Name = "Label5";
            Label5.Text = Text;
            Label5.VertAlignment = P.TextVertAlignment;
            Label5.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Label5.Brush = new StiSolidBrush(Color.Transparent);
            Label5.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label5.Guid = Guid.NewGuid().ToString();
            Label5.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label5.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label5.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label5.Enabled = true;
        }

        public void SetLabel6(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Label6 = new StiText();
            Label6.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label6.HorAlignment = P.TextHorAlignment;
            Label6.Name = "Label6";
            Label6.Text = Text;
            Label6.VertAlignment = P.TextVertAlignment;
            Label6.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Label6.Brush = new StiSolidBrush(Color.Transparent);
            Label6.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label6.Guid = Guid.NewGuid().ToString();
            Label6.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label6.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label6.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label6.Enabled = true;
        }

        public void SetLabel7(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);

            Label7 = new StiText();
            Label7.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Label7.HorAlignment = P.TextHorAlignment;
            Label7.Name = "Label7";
            Label7.Text = Text;
            Label7.VertAlignment = P.TextVertAlignment;
            Label7.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Label7.Brush = new StiSolidBrush(Color.Transparent);
            Label7.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Label7.Guid = Guid.NewGuid().ToString();
            Label7.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Label7.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Label7.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Label7.Enabled = true;
        }

        public void SetText1(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text1 = new StiText();
            Text1.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text1.HorAlignment = P.TextHorAlignment;
            Text1.Name = "Text1";
            Text1.Text = Text;
            Text1.VertAlignment = P.TextVertAlignment;
            Text1.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Text1.Brush = new StiSolidBrush(Color.Transparent);
            Text1.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text1.Guid = Guid.NewGuid().ToString();
            Text1.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text1.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text1.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text1.Enabled = true;
        }

        public void SetText2(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text2 = new StiText();
            Text2.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text2.HorAlignment = P.TextHorAlignment;
            Text2.Name = "Text2";
            Text2.Text = Text;
            Text2.VertAlignment = P.TextVertAlignment;
            Text2.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Text2.Brush = new StiSolidBrush(Color.Transparent);
            Text2.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text2.Guid = Guid.NewGuid().ToString();
            Text2.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text2.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text2.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text2.Enabled = true;
        }

        public void SetText3(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text3 = new StiText();
            Text3.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text3.HorAlignment = P.TextHorAlignment;
            Text3.Name = "Text3";
            Text3.Text = Text;
            Text3.VertAlignment = P.TextVertAlignment;
            Text3.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Text3.Brush = new StiSolidBrush(Color.Transparent);
            Text3.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text3.Guid = Guid.NewGuid().ToString();
            Text3.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text3.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text3.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text3.Enabled = true;
        }

        public void SetText4(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text4 = new StiText();
            Text4.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text4.HorAlignment = P.TextHorAlignment;
            Text4.Name = "Text4";
            Text4.Text = Text;
            Text4.VertAlignment = P.TextVertAlignment;
            Text4.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Text4.Brush = new StiSolidBrush(Color.Transparent);
            Text4.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text4.Guid = Guid.NewGuid().ToString();
            Text4.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text4.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text4.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text4.Enabled = true;
        }

        public void SetText5(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text5 = new StiText();
            Text5.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text5.HorAlignment = P.TextHorAlignment;
            Text5.Name = "Text5";
            Text5.Text = Text;
            Text5.VertAlignment = P.TextVertAlignment;
            Text5.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Text5.Brush = new StiSolidBrush(Color.Transparent);
            Text5.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text5.Guid = Guid.NewGuid().ToString();
            Text5.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text5.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text5.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text5.Enabled = true;
        }

        public void SetText6(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text6 = new StiText();
            Text6.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text6.HorAlignment = P.TextHorAlignment;
            Text6.Name = "Text6";
            Text6.Text = Text;
            Text6.VertAlignment = P.TextVertAlignment;
            Text6.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Text6.Brush = new StiSolidBrush(Color.Transparent);
            Text6.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text6.Guid = Guid.NewGuid().ToString();
            Text6.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text6.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text6.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text6.Enabled = true;
        }

        public void SetText7(StiProperties P, string Text, StiProperties generalProp = null)
        {
            P = Join2Prop(P, generalProp);
            Text7 = new StiText();
            Text7.ClientRectangle = P.RectangleD; //new RectangleD(144.94, 0.9, 17.02, 5.08)
            Text7.HorAlignment = P.TextHorAlignment;
            Text7.Name = "Text7";
            Text7.Text = Text;
            Text7.VertAlignment = P.TextVertAlignment;
            Text7.Border = new StiBorder(StiBorderSides.None, Color.Black, 1,
                StiPenStyle.Solid);
            Text7.Brush = new StiSolidBrush(Color.Transparent);
            Text7.Font = P.Font != null
                ? P.Font
                : new Font("B Nazanin", 9.75F, FontStyle.Bold,
                    GraphicsUnit.Point, 178);
            Text7.Guid = Guid.NewGuid().ToString();
            Text7.Margins = P.Margins != null ? P.Margins : new StiMargins(0, 0, 0, 0);
            Text7.TextBrush = P.ForeColor != null
                ? P.ForeColor
                : new StiSolidBrush(Color.Black);
            Text7.TextOptions = P.TextOptions != null
                ? P.TextOptions
                : new StiTextOptions(true, false, false, 0F,
                    System.Drawing.Text.HotkeyPrefix.None, StringTrimming.None);
            Text7.Enabled = true;
        }
    }
}
