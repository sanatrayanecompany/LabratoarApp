using Stimulsoft.Base;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Base.Services;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Export;
using Stimulsoft.Report.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Drawing.Printing;

namespace PaymentStationApp.Report
{
    public class ReportUIGenerator : Stimulsoft.Report.StiReport
    {
        /// <summary>
        ///  کلاس اصلی گزارش که از سایر کلاس ها
        ///  در این کلاس آبجکت تعریف شده 
        /// </summary>
        public ReportUIGenerator(PaperKind paperSize, StiPageOrientation orientation, IList<object> data, bool borderReport = true)
        {
            //Page1 = new StiPage();
            //_PaperSize = PaperSize;//اندازه گزارش
            //_Orientation = Orientation;//نوع گزارش عمودی یا افقی

            Page = report.Pages[0];
            Page.ReportUnit = Stimulsoft.Report.Units.StiUnit.HundredthsOfInch;
            
            Page.Orientation = orientation;
            ReportData = new ReportData(data);
            ReportTitle = new PageTitle();
            ReportFooter = new ReportFooter();
            this.BorderReport = borderReport;

            //EvenStyle
            StyleEvenStyle = new StiStyle();
            StyleEvenStyle.Description = "";
            StyleEvenStyle.Name = "EvenStyle";

            StyleEvenStyle.Border = new StiBorder(
                StiBorderSides.None
                | StiBorderSides.Top
                | StiBorderSides.Right
                | StiBorderSides.Left
                | StiBorderSides.Bottom, Color.Black, 1,
                StiPenStyle.Solid);
            StyleEvenStyle.Brush = new StiSolidBrush(Color.Silver);
            StyleEvenStyle.Font = new Font("B Nazanin", 10F);
            StyleEvenStyle.Image = null;
            StyleEvenStyle.TextBrush = new StiSolidBrush(Color.Transparent);

            // 
            // StyleEvenStyle
            // 
            BorderStyle = new Stimulsoft.Report.StiStyle();
            BorderStyle.Description = "";
            BorderStyle.Name = "BorderStyle";
            BorderStyle.Border = new StiBorder(StiBorderSides.All, Color.Black, 1, StiPenStyle.Solid);
            BorderStyle.Brush = new StiSolidBrush(Color.Transparent);
            BorderStyle.Font = new Font("B Nazanin", 10F);
            BorderStyle.Image = null;
            BorderStyle.TextBrush = new StiSolidBrush(Color.Transparent);
            // 
            report.Styles.Clear();
            report.Styles.AddRange(new Stimulsoft.Report.StiBaseStyle[]
            {

                StyleEvenStyle,
                BorderStyle
            });


            // StyleTitleDataStyle
            // 
        }

        /// <summary>
        /// m از n
        /// </summary>
        /// <returns></returns>
        public string GetPageNumberNofM
        {
            get { return "{PageNumber}   از  {TotalPageCount}"; }
        }

        protected StiProperties Join2Prop(StiProperties getterProp, StiProperties sourceProp)
        {
            if (sourceProp != null && getterProp != null)
            {
                getterProp.Font = sourceProp.Font != null ? sourceProp.Font : getterProp.Font;
                getterProp.ForeColor = sourceProp.ForeColor != null ? sourceProp.ForeColor : getterProp.ForeColor;
                getterProp.FormatNumeric = sourceProp.FormatNumeric;
                getterProp.Margins = sourceProp.Margins != null ? sourceProp.Margins : getterProp.Margins;
                getterProp.RectangleD = sourceProp.RectangleD;
                getterProp.RightToLeft = sourceProp.RightToLeft;
                getterProp.Text = sourceProp.Text != null ? sourceProp.Text : getterProp.Text;
                getterProp.TextHorAlignment = sourceProp.TextHorAlignment;
                getterProp.TextOptions = sourceProp.TextOptions != null ? sourceProp.TextOptions : getterProp.TextOptions;
                getterProp.TextVertAlignment = sourceProp.TextVertAlignment;
                getterProp.Width = sourceProp.Width;
            }

            return getterProp;
        }

        protected ColumnsProperties Join2ColumnProp(ColumnsProperties getterProp, ColumnsProperties sourceProp)
        {
            if (sourceProp != null && getterProp != null)
            {
                getterProp.FooterTextHorAlignment = sourceProp.FooterTextHorAlignment;
                getterProp.HeaderTextVertAlignment = sourceProp.HeaderTextVertAlignment;
                getterProp.HeaderTextHorAlignment = sourceProp.HeaderTextHorAlignment;
                //GetterProp.DataTextVertAlignment = SourceProp.DataTextVertAlignment != null ? SourceProp.DataTextVertAlignment : GetterProp.DataTextVertAlignment;
                //GetterProp.DataTextHorAlignment = SourceProp.DataTextHorAlignment != null ? SourceProp.DataTextHorAlignment : GetterProp.DataTextHorAlignment;
                getterProp.FooterTextVertAlignment = sourceProp.FooterTextVertAlignment;
                getterProp.FooterText = sourceProp.FooterText != null ? sourceProp.FooterText : getterProp.FooterText;
                getterProp.FormatNumeric = sourceProp.FormatNumeric;
                getterProp.HeaderFont = sourceProp.HeaderFont != null ? sourceProp.HeaderFont : getterProp.HeaderFont;
                getterProp.FooterFont = sourceProp.FooterFont != null ? sourceProp.FooterFont : getterProp.FooterFont;
                getterProp.DataFont = sourceProp.DataFont != null ? sourceProp.DataFont : getterProp.DataFont;
                getterProp.DataTripleSeparator = sourceProp.DataTripleSeparator;
                getterProp.DataMultiLine = sourceProp.DataMultiLine;
                getterProp.FooterTextPosition = sourceProp.FooterTextPosition.X != 0
                    ? sourceProp.FooterTextPosition
                    : getterProp.FooterTextPosition;
                //GetterProp.FooterBorder = SourceProp.FooterBorder != null ? SourceProp.FooterBorder : GetterProp.FooterBorder;
                getterProp.ForeColor = sourceProp.ForeColor != null ? sourceProp.ForeColor : getterProp.ForeColor;

                getterProp.FooterAddToWidth = sourceProp.FooterAddToWidth != 0
                    ? sourceProp.FooterAddToWidth
                    : getterProp.FooterAddToWidth;

                getterProp.FooterAddToPosition = sourceProp.FooterAddToPosition != 0
                    ? sourceProp.FooterAddToPosition
                    : getterProp.FooterAddToPosition;

                getterProp.Width = sourceProp.Width != 0
                    ? sourceProp.Width
                    : getterProp.Width;

                getterProp.RightToLeft = sourceProp.RightToLeft;
                getterProp.HeaderRightToLeft = sourceProp.HeaderRightToLeft;
                //GetterProp.FooterRightToLeft = SourceProp.FooterRightToLeft != null ? SourceProp.FooterRightToLeft : GetterProp.FooterRightToLeft;
                getterProp.TextOptions = sourceProp.TextOptions != null ? sourceProp.TextOptions : getterProp.TextOptions;
                getterProp.Text = sourceProp.Text != null ? sourceProp.Text : getterProp.Text;

                if (getterProp.SubColumns != null && getterProp.SubColumns.Count > 0)
                {
                    for (int i = 0; i < getterProp.SubColumns.Count; i++)
                    {
                        getterProp.SubColumns[i].FooterTextHorAlignment = sourceProp.SubColumns[i].SubColumns[i].FooterTextHorAlignment;
                        getterProp.SubColumns[i].HeaderTextVertAlignment = sourceProp.SubColumns[i].HeaderTextVertAlignment;
                        getterProp.SubColumns[i].HeaderTextHorAlignment = sourceProp.SubColumns[i].HeaderTextHorAlignment;
                        //GetterProp.SubColumns[i].DataTextVertAlignment = SourceProp.SubColumns[i].DataTextVertAlignment != null ? SourceProp.SubColumns[i].DataTextVertAlignment : GetterProp.SubColumns[i].DataTextVertAlignment;
                        //GetterProp.SubColumns[i].DataTextHorAlignment = SourceProp.SubColumns[i].DataTextHorAlignment != null ? SourceProp.SubColumns[i].DataTextHorAlignment : GetterProp.SubColumns[i].DataTextHorAlignment;
                        getterProp.SubColumns[i].FooterText = sourceProp.SubColumns[i].FooterText != null
                            ? sourceProp.SubColumns[i].FooterText
                            : getterProp.SubColumns[i].FooterText;
                        getterProp.SubColumns[i].FooterTextVertAlignment = sourceProp.SubColumns[i].FooterTextVertAlignment;
                        getterProp.SubColumns[i].FormatNumeric = sourceProp.SubColumns[i].FormatNumeric;
                        getterProp.SubColumns[i].HeaderFont = sourceProp.SubColumns[i].HeaderFont != null
                            ? sourceProp.SubColumns[i].HeaderFont
                            : getterProp.SubColumns[i].HeaderFont;
                        getterProp.SubColumns[i].FooterFont = sourceProp.SubColumns[i].FooterFont != null
                            ? sourceProp.SubColumns[i].FooterFont
                            : getterProp.SubColumns[i].FooterFont;
                        getterProp.SubColumns[i].DataFont = sourceProp.SubColumns[i].DataFont != null
                            ? sourceProp.SubColumns[i].DataFont
                            : getterProp.SubColumns[i].DataFont;
                        getterProp.SubColumns[i].DataTripleSeparator = sourceProp.SubColumns[i].DataTripleSeparator;
                        getterProp.SubColumns[i].DataMultiLine = sourceProp.SubColumns[i].DataMultiLine;
                        getterProp.SubColumns[i].FooterTextPosition = sourceProp.SubColumns[i].FooterTextPosition.X != 0
                            ? sourceProp.SubColumns[i].FooterTextPosition
                            : getterProp.SubColumns[i].FooterTextPosition;
                        //GetterProp.SubColumns[i].FooterBorder = SourceProp.SubColumns[i].FooterBorder != null ? SourceProp.SubColumns[i].FooterBorder : GetterProp.SubColumns[i].FooterBorder;
                        getterProp.SubColumns[i].ForeColor = sourceProp.SubColumns[i].ForeColor != null
                            ? sourceProp.SubColumns[i].ForeColor
                            : getterProp.SubColumns[i].ForeColor;
                        getterProp.SubColumns[i].FooterAddToWidth = sourceProp.SubColumns[i].FooterAddToWidth != 0
                            ? sourceProp.SubColumns[i].FooterAddToWidth
                            : getterProp.SubColumns[i].FooterAddToWidth;
                        getterProp.SubColumns[i].FooterAddToPosition = sourceProp.SubColumns[i].FooterAddToPosition != 0
                            ? sourceProp.SubColumns[i].FooterAddToPosition
                            : getterProp.SubColumns[i].FooterAddToPosition;
                        getterProp.SubColumns[i].Width = sourceProp.SubColumns[i].Width != 0
                            ? sourceProp.SubColumns[i].Width
                            : getterProp.SubColumns[i].Width;
                        getterProp.SubColumns[i].RightToLeft = sourceProp.SubColumns[i].RightToLeft;
                        getterProp.SubColumns[i].HeaderRightToLeft = sourceProp.SubColumns[i].HeaderRightToLeft;
                        //GetterProp.SubColumns[i].FooterRightToLeft = SourceProp.SubColumns[i].FooterRightToLeft != null ? SourceProp.SubColumns[i].FooterRightToLeft : GetterProp.SubColumns[i].FooterRightToLeft;
                        getterProp.SubColumns[i].TextOptions = sourceProp.SubColumns[i].TextOptions != null
                            ? sourceProp.SubColumns[i].TextOptions
                            : getterProp.SubColumns[i].TextOptions;
                        getterProp.SubColumns[i].Text = sourceProp.SubColumns[i].Text != null
                            ? sourceProp.SubColumns[i].Text
                            : getterProp.SubColumns[i].Text;
                    }
                }
            }

            return getterProp;
        }

        /// <summary>                                                                                                       
        /// شماره صفحه
        /// </summary>
        /// <returns></returns>
        public string GetPageNumber()
        {
            return "{PageNumber}";
        }

        public ReportUIGenerator()
        {
        }

        //private StiPageHeaderBand PageHeaderBand { get; set; }

        private StiPageHeaderBand PageHeaderBand;
        private StiDataBand _dataBand; //کلاس استیمول : نمایش داده های گزارش توسط این کلاس صورت می گیرد
        private StiReport report = new StiReport(); // کلاس اصلی استیمول ریپورت است 

        private StiHeaderBand HeaderBand { get; set; } //کلاس استیمول :عنوان ستون های گزارش که بالای دیتا قرار دارد 
        private StiPageFooterBand PageFooterBand { get; set; }
        private StiFooterBand FooterBand { get; set; }
        private StiFooterBand FooterBandBottom { get; set; }
        private StiText TextPageNumber { get; set; }
        private bool BorderReport { get; set; }
        private StiPage Page { get; set; } //صفحه پیش فرض که ما کل تنظیمات گزارش را روی این صفحه قرار می دهیم
        private StiStyle StyleEvenStyle { get; set; }
        private StiStyle BorderStyle { get; set; }

        public PaperKind PaperSize { set; private get; }
        public StiPageOrientation Orientation { set; private get; }
        public TextFormat TextFormat { get; set; } // برای فرمت جعبه متن ها از این کلاس استفاده میشود برای سادگی ما در قسمت یوآی فرمت را ست کرده ایم
        public HeaderColumns ReportHeader { get; set; } //قسمت ابتدایی گزارش ، برای نمونه عنوان گزارش در این کلاس ست می شود 
        public ReportFooter ReportFooter { get; set; } //قسمت انتهایی گزارش جمع ستون ها در این قسمت ست می شود
        public PageTitle ReportTitle { get; set; } // عنوان هایی که فقط در صفحه اول نمایش داده می شوند در این کلاس ست می شوند
        public ReportData ReportData { get; set; } // لیست آبجکت از یو آی به این کلاس پاس داده میشود 
        public Stimulsoft.Report.Print.StiPrinterSettings ReportPrinterSettings { get; set; }

        private List<StiComponent> AddStiComponentCollection(List<StiComponent> lstComponent)
        {
            List<StiComponent> TitleBand = new List<StiComponent>();
            lstComponent.ForEach(x =>
            {
                if (x != null && x.IsEnabled)
                    TitleBand.Add(x);
            });
            return TitleBand;
        }

        private void CreateHeaders(ref List<Header> listHeaders, List<ColumnsProperties> lstCP, List<string> headerNames, int counter)
        {
            listHeaders = listHeaders == null ? new List<Header>() : listHeaders;

            foreach (var prop in lstCP)
            {
                Header header = new Header();

                header.ColumnsProperties = prop;

                if (prop.SubColumns != null && prop.SubColumns.Count() != 0)
                {
                    header.Name = null;
                    //headers.data = null;
                    CreateHeaders(ref header.Headers, prop.SubColumns, headerNames, counter);
                    counter += prop.SubColumns.Count();
                }
                else
                {
                    header.Name = headerNames[counter];
                    //headers.data = data[Counter];
                    header.Headers = null;
                    ++counter;
                }

                listHeaders.Add(header);
            }
        }

        public string SumFieldFormatNumeric(string fieldName)
        {
            return "{Format(\"{0:N0}\", Sum(data." + fieldName + "))}";
        }

        public void CreateReport()
        {

            PageHeaderBand = new StiPageHeaderBand();
            PageHeaderBand.Height = 3.CmToInch();
            PageHeaderBand.Name = "TitleBand";
            if (BorderReport)
            {
                PageHeaderBand.ComponentStyle = report.Styles[1].Name;
            }

            Page.Components.Add(PageHeaderBand);

            //System.Windows.Forms.MessageBox.Show("top : " + page.Margins.Top.InchToCm().ToString() + "   left : " + page.Left.InchToCm().ToString());
            //System.Windows.Forms.MessageBox.Show("H : " + page.Height.InchToCm().ToString() + "   left : " + page.Left.InchToCm().ToString());

            PageHeaderBand.Report.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            PageHeaderBand.Report.Unit = Stimulsoft.Report.Units.StiUnit.Inches;

            var Collection = AddStiComponentCollection(new List<StiComponent>()
            {
                ReportTitle.TopTitle,
                ReportTitle.Title,
                ReportTitle.Image1,
                ReportTitle.Image2,
                ReportTitle.BottomTitle,
                ReportTitle.Label1,
                ReportTitle.Label2,
                ReportTitle.Label3,
                ReportTitle.Label4,
                ReportTitle.Label5,
                ReportTitle.Label6,
                ReportTitle.Label7,
                ReportTitle.Text1,
                ReportTitle.Text2,
                ReportTitle.Text3,
                ReportTitle.Text4,
                ReportTitle.Text5,
                ReportTitle.Text6,
                ReportTitle.Text7
            });

            PageHeaderBand.Components.AddRange(Collection.ToArray());

            List<string> LstHeaderName;
            //رفلکشن روی دیتا از نوع آبجکت برای بدست آوردن نام سر ستون ها

            if (ReportData.Data != null)
            {
                object obj = ReportData.Data[0];
                Type mytype = obj.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(mytype.GetProperties());

                if (ReportData.FieldsName == null)
                {
                    LstHeaderName = props.Select(p => p.Name).ToList();

                }
                else
                {
                    LstHeaderName = ReportData.FieldsName;
                }

                List<Header> ListHeaderDetails = new List<Header>();
                int CounterColumns = ReportHeader.PropertiesColumns.Count();

                for (int j = 0; j < ReportHeader.PropertiesColumns.Count; j++)
                {
                    var currentProp = ReportHeader.PropertiesColumns[j];
                    // reportHeader.PropertiesColumns[j] = Join2ColumnProp(currentProp, currentProp.GeneralProp);
                    CounterColumns += currentProp.SubColumns != null ? currentProp.SubColumns.Count - 1 : 0;
                }

                CreateHeaders(ref ListHeaderDetails, ReportHeader.PropertiesColumns, LstHeaderName, 0);

                // Validatation

                if (ReportData.Data.Count == 0)
                {
                    throw new Exception("هیچ رکوردی برای نمایش وجود ندارد.", new Exception("توجه", new Exception("w")));
                }

                if (CounterColumns != LstHeaderName.Count)
                {
                    string messageText = "تعداد فیلد های هدر گزارش با تعداد فیلد های دیتای گزارش مساوی نمی باشد.<br /> به ازای هر هدر باید فیلد دیتای متناظر با آن وجود داشته باشد.";
                    throw new Exception(messageText, new Exception("توجه", new Exception("w")));
                }


                bool ExistSubColumns = false;

                //توضیحات در قسمت تعریف متد داده شده است


                ExistSubColumns = ListHeaderDetails.Exists(x => x.Headers != null);

                // Add data to datastore

                report.RegData("data", ReportData.Data);

                // Fill dictionary

                report.Dictionary.Synchronize();
                report.Dictionary.DataSources[0].Name = "data";
                report.Dictionary.DataSources[0].Alias = "data";

                // Create HeaderBand

                HeaderBand = new StiHeaderBand();
                //headerBand.Height = 0.4.CmToInch();
                HeaderBand.Name = "HeaderBand";
                HeaderBand.ClientRectangle =
                    new RectangleD(0, 4.CmToInch(), 19.03.CmToInch(), 0.8.CmToInch());
                Page.Components.Add(HeaderBand);

                // Create Databand

                _dataBand = new StiDataBand();
                _dataBand.DataSourceName = "data";
                _dataBand.Height = 0.5;
                _dataBand.Name = "DataBand";
                Page.Components.Add(_dataBand);

                //Create texts
                double pos = 0;

                double columnWidth = StiAlignValue.AlignToMinGrid(Page.Width / ReportData.Data.Count, 0.1, true);

                //var GetProperties = data[0].GetType().GetProperties();
                //foreach (var prop in LstHeaderName)
                //{

                // Create Dynamic Columns
                double SumWidth = ReportHeader.PropertiesColumns.Sum(x => x.Width);
                double UnitDiv = SumWidth / (Page.Width * 2.54);
                ReportHeader.PropertiesColumns.Reverse();

                if (ExistSubColumns)
                {
                    HeaderBand.Height *= 2;
                }
                else
                {
                    HeaderBand.Height *= 1.3;
                }

                int i = 1;


                FooterBand = new StiFooterBand();
                FooterBand.Name = "FooterBand";

                Double MaxHeight = 0;
                FooterBand.Height = 0.71.CmToInch();
                Page.Components.Add(FooterBand);

                FooterBandBottom = new StiFooterBand();
                FooterBandBottom.Name = "footerBandBottom";

                FooterBandBottom.Height = 2.CmToInch();

                FooterBandBottom.Components.AddRange(AddStiComponentCollection(new List<StiComponent>()
                    {ReportFooter.LabelBottom1, ReportFooter.LabelBottom2, ReportFooter.LabelBottom3}).ToArray());
                Page.Components.Add(FooterBandBottom);

                // 
                // PageFooterBand
                //
                PageFooterBand = new StiPageFooterBand();
                PageFooterBand.ClientRectangle = new RectangleD(0.CmToInch(), 269.58.CmToInch(),
                    190.2.CmToInch(), 7.62.CmToInch());
                PageFooterBand.Name = "PageFooterBand";
                PageFooterBand.Border = new StiBorder(StiBorderSides.None,
                    Color.Black, 1, StiPenStyle.Solid);
                PageFooterBand.Brush = new StiSolidBrush(Color.Yellow);

                ListHeaderDetails.Reverse();

                int IndexFieldName = 0;
                if (ReportData.FieldsName != null)
                {
                    IndexFieldName = ReportData.FieldsName.Count() - 1;
                }

                int ColumnIndex = 1;

                double WidthCoulmns = 0;
                ListHeaderDetails.ForEach(
                    prop =>
                    {
                        var _Width = prop.ColumnsProperties.Width;
                        var _Datafont = prop.ColumnsProperties.DataFont;
                        var _ForeColor = prop.ColumnsProperties.ForeColor;
                        var _RightToLeft = prop.ColumnsProperties.RightToLeft;
                        var _HeaderRightToLeft = prop.ColumnsProperties.HeaderRightToLeft;
                        var _FooterRightToLeft = prop.ColumnsProperties.FooterRightToLeft;
                        var _TextOption = prop.ColumnsProperties.TextOptions;
                        var _Headerfont = prop.ColumnsProperties.HeaderFont;
                        var _HeaderVerAlignment = prop.ColumnsProperties.HeaderTextVertAlignment;
                        var _HeaderHorAlignment = prop.ColumnsProperties.HeaderTextHorAlignment;
                        var _DataVerAlignment = prop.ColumnsProperties.DataTextVertAlignment;
                        var _DataHorAlignment = prop.ColumnsProperties.DataTextHorAlignment;
                        var _DataTripleSeparator = prop.ColumnsProperties.DataTripleSeparator;
                        double ColumnWidth = _Width / UnitDiv;
                        WidthCoulmns += ColumnWidth;
                        if (prop == ListHeaderDetails.LastOrDefault())
                        {
                            double diff = WidthCoulmns - (Page.Width * 2.54);
                            if (diff != 0)
                            {
                                ColumnWidth += diff;
                            }
                        }

                        // TextFooter تکست فوتر برای هر ستون می باشد که برای نمایش جمع ستون ها استفاده می شود

                        StiText footerText = new StiText();
                        footerText.Text.Value = prop.ColumnsProperties.FooterText; //"Count - {Count()}";
                        footerText.HorAlignment = prop.ColumnsProperties.FooterTextHorAlignment;
                        footerText.VertAlignment = prop.ColumnsProperties.FooterTextVertAlignment;
                        footerText.Name = "FooterText" + prop.Name + (i++).ToString();
                        FooterBand.Brush = new StiSolidBrush(Color.FromArgb(243, 243, 243));
                        footerText.Font = prop.ColumnsProperties.FooterFont != null
                            ? prop.ColumnsProperties.FooterFont
                            : new Font("B Nazanin", 12F, FontStyle.Bold,
                                GraphicsUnit.Point, 178);
                        footerText.TextOptions.RightToLeft = prop.ColumnsProperties.RightToLeft;
                        string footerValue = string.Empty;

                        if (prop.ColumnsProperties.FooterBorder)
                        {
                            footerText.Border = new StiBorder(
                                StiBorderSides.All, Color.Black, 1,
                                StiPenStyle.Solid);
                            footerValue = " ";
                        }

                        FooterBand.Border = new StiBorder(
                            StiBorderSides.All
                            , Color.Black, 1, StiPenStyle.Solid);
                        footerValue += footerText.Text.Value ?? string.Empty;
                        footerText.Text.Value = footerValue;

                        if (footerText.Text.Value != string.Empty)
                        {
                            FooterBand.Components.Add(footerText);
                        }

                        StiText headerText = new StiText();
                        bool IsSubColumn;
                        IsSubColumn = prop.Headers == null ? false : true;
                        bool IsExistPosition = false;
                        double X = 0;
                        double Y = 0;
                        if (!prop.ColumnsProperties.FooterTextPosition.Location.IsEmpty)
                        {
                            IsExistPosition = true;
                            X = prop.ColumnsProperties.FooterTextPosition.Location.X;
                            Y = prop.ColumnsProperties.FooterTextPosition.Location.Y;
                        }

                        double AddToWidth = prop.ColumnsProperties.FooterAddToWidth;
                        double AddToPosition = prop.ColumnsProperties.FooterAddToPosition;
                        if (ListHeaderDetails.Last() == prop) //Last Prop
                        {
                            headerText.ClientRectangle = new RectangleD(pos.CmToInch(),
                                ExistSubColumns ? 0.0 /*5*/ : 0, ColumnWidth.CmToInch() /*+ 0.0025*/,
                                IsSubColumn || !ExistSubColumns ? HeaderBand.Height / 2 : HeaderBand.Height); // 
                            footerText.ClientRectangle =
                                new RectangleD((IsExistPosition ? pos.CmToInch() + X : pos.CmToInch()) + AddToPosition,
                                    IsExistPosition ? Y : 0, (ColumnWidth + AddToWidth).CmToInch(), FooterBand.Height);
                        }
                        else
                        {
                            headerText.ClientRectangle = new RectangleD(
                                pos.CmToInch() + AddToPosition, ExistSubColumns ? 0 : 0,
                                ColumnWidth.CmToInch() /*+ 0.005*/,
                                IsSubColumn || !ExistSubColumns ? HeaderBand.Height / 2 : HeaderBand.Height); //
                            footerText.ClientRectangle =
                                new RectangleD(IsExistPosition ? pos.CmToInch() + X : pos.CmToInch(),
                                    IsExistPosition ? Y : 0, (ColumnWidth + AddToWidth).CmToInch(), FooterBand.Height);
                        }

                        headerText.Text.Value = prop.ColumnsProperties.Text;
                        headerText.VertAlignment = _HeaderVerAlignment;
                        headerText.HorAlignment = _HeaderHorAlignment;
                        headerText.Brush = _ForeColor != null ? _ForeColor : new StiSolidBrush(Color.Beige);
                        headerText.Font = _Headerfont != null ? _Headerfont : new Font("B Nazanin", 13, FontStyle.Bold);

                        headerText.TextOptions.RightToLeft = _HeaderRightToLeft;
                        footerText.TextOptions.RightToLeft = _FooterRightToLeft;
                        headerText.TextOptions = _TextOption != null ? _TextOption : headerText.TextOptions;
                        headerText.CanGrow = true;
                        headerText.Name = "HeaderText" + headerText.Name + (i++).ToString();
                        if (prop == ListHeaderDetails.FirstOrDefault())
                        {
                            headerText.Border = new StiBorder(
                                StiBorderSides.None
                                | StiBorderSides.Top
                                | StiBorderSides.Left
                                | StiBorderSides.Right
                                | StiBorderSides.Bottom
                                , Color.Black, 1, StiPenStyle.Solid);
                        }
                        else
                        {
                            headerText.Border = new StiBorder(
                                StiBorderSides.None
                                | StiBorderSides.Top
                                | StiBorderSides.Left
                                | StiBorderSides.Bottom
                                , Color.Black, 1, StiPenStyle.Solid);
                        }

                        headerText.WordWrap = true;
                        headerText.CanGrow = true;
                        headerText.GrowToHeight = true;
                        HeaderBand.Components.Add(headerText);


                        if (prop.Headers == null)
                        {
                            // اگر زیر ستون نداشت

                            //Create text on Data Band
                            StiText dataText = new StiText();
                            StiCondition conditionCouples = new StiCondition();
                            conditionCouples.BackColor = Color.FromArgb(215, 215, 215);
                            conditionCouples.TextColor = Color.Black;
                            conditionCouples.Expression = "(Line & 1) == 0";
                            conditionCouples.Item = StiFilterItem.Expression;
                            conditionCouples.Font = _Datafont != null ? _Datafont : dataText.Font;
                            dataText.Conditions.Add(conditionCouples);
                            StiCondition conditionOdd = new StiCondition();
                            conditionOdd.BackColor = Color.White;
                            conditionOdd.TextColor = Color.Black;
                            conditionOdd.Expression = "(Line & 1) == 1";
                            conditionOdd.Item = StiFilterItem.Expression;
                            conditionOdd.Font = _Datafont != null ? _Datafont : dataText.Font;
                            dataText.Conditions.Add(conditionOdd);
                            if (ListHeaderDetails.Last() == prop) //Last Prop
                            {
                                dataText.ClientRectangle = new RectangleD(pos.CmToInch(),
                                    ExistSubColumns ? 0 : 0, ColumnWidth.CmToInch(), HeaderBand.Height / 2);
                            }
                            else
                            {
                                dataText.ClientRectangle = new RectangleD(pos.CmToInch(),
                                    ExistSubColumns ? 0 : 0, ColumnWidth.CmToInch(), HeaderBand.Height / 2);
                            }

                            if (ReportData.FieldsName != null)
                            {
                                if (prop.ColumnsProperties.FormatNumeric)
                                    dataText.Text.Value =
                                        new TextFormat().FormatNumeric(
                                            " " + " { data." + ReportData.FieldsName[IndexFieldName] + " } ");
                                else
                                    dataText.Text.Value =
                                        " " + " { data." + ReportData.FieldsName[IndexFieldName] + " } " + " ";

                                --IndexFieldName;
                            }
                            else if (prop.ColumnsProperties.FormatNumeric)
                                dataText.Text.Value = new TextFormat().FormatNumeric(
                                    " " + " { data." +
                                    Stimulsoft.Report.CodeDom.StiCodeDomSerializator.ReplaceSymbols(prop.Name) + " } ");
                            else
                                dataText.Text.Value =
                                    " " + " { data." +
                                    Stimulsoft.Report.CodeDom.StiCodeDomSerializator.ReplaceSymbols(prop.Name) + " } ";


                            dataText.Name = "DataText" + headerText.Name + (i++).ToString();
                            if (prop == ListHeaderDetails.FirstOrDefault())
                            {
                                dataText.Border = new StiBorder(
                                    StiBorderSides.None
                                    | StiBorderSides.Top
                                    | StiBorderSides.Left
                                    | StiBorderSides.Bottom
                                    , Color.Black, 1, StiPenStyle.Solid);
                            }
                            else
                            {

                                dataText.Border = new StiBorder(
                                    StiBorderSides.None
                                    | StiBorderSides.Top
                                    | StiBorderSides.Left
                                    | StiBorderSides.Bottom
                                    , Color.Black, 1, StiPenStyle.Solid);

                            }

                            ColumnIndex++;
                            dataText.TextOptions.RightToLeft = _RightToLeft;
                            _dataBand.EvenStyle = report.Styles[0].Name;
                            dataText.TextOptions = _TextOption != null ? _TextOption : dataText.TextOptions;
                            dataText.HorAlignment = _DataHorAlignment;
                            dataText.VertAlignment = _DataVerAlignment;
                            dataText.Font = _Datafont != null ? _Datafont : dataText.Font;
                            dataText.CanGrow = true;
                            dataText.WordWrap = true;
                            _dataBand.CanShrink = true;
                            dataText.GrowToHeight = true;

                            pos = pos + ColumnWidth;

                            dataText.WordWrap = true;
                            MaxHeight = dataText.Height > MaxHeight ? dataText.Height : MaxHeight;
                            _dataBand.Components.Add(dataText);
                        }
                        else
                        {
                            // اگر زیر ستون داشت

                            double _TotalWidth = prop.Headers.Sum(x => x.ColumnsProperties.Width);
                            int c = 1;
                            prop.Headers.Reverse();

                            foreach (var SubProp in prop.Headers)
                            {
                                StiText SubHeaderText = new StiText();

                                var _SubWidth = SubProp.ColumnsProperties.Width;
                                var _SubDatafont = SubProp.ColumnsProperties.DataFont;
                                var _SubForeColor = SubProp.ColumnsProperties.ForeColor;
                                var _SubRightToLeft = SubProp.ColumnsProperties.RightToLeft;
                                var _SubTextOption = SubProp.ColumnsProperties.TextOptions;
                                var _SubHeaderfont = SubProp.ColumnsProperties.HeaderFont;
                                var _SubHeaderVerAlignment = SubProp.ColumnsProperties.HeaderTextVertAlignment;
                                var _SubHeaderHorAlignment = SubProp.ColumnsProperties.HeaderTextHorAlignment;
                                var _SubDataVerAlignment = SubProp.ColumnsProperties.DataTextVertAlignment;
                                var _SubDataHorAlignment = SubProp.ColumnsProperties.DataTextHorAlignment;
                                double SubColumnWidth = (_SubWidth * ColumnWidth) / _TotalWidth;

                                footerText = new StiText();
                                footerText.Text.Value = SubProp.ColumnsProperties.FooterText; //"Count - {Count()}";
                                footerText.HorAlignment = SubProp.ColumnsProperties.FooterTextHorAlignment;
                                footerText.VertAlignment = SubProp.ColumnsProperties.FooterTextVertAlignment;
                                footerText.Name = "FooterText" + SubProp.Name + (i++).ToString();
                                FooterBand.Brush = new StiSolidBrush(Color.FromArgb(243, 243, 243));
                                footerText.Font = SubProp.ColumnsProperties.FooterFont != null
                                    ? SubProp.ColumnsProperties.FooterFont
                                    : new Font("B Nazanin", 12F, FontStyle.Bold,
                                        GraphicsUnit.Point, 178);
                                footerText.TextOptions.RightToLeft = SubProp.ColumnsProperties.RightToLeft;
                                footerValue = string.Empty;

                                if (SubProp.ColumnsProperties.FooterBorder)
                                {
                                    footerText.Border = new StiBorder(
                                        StiBorderSides.All, Color.Black, 1,
                                        StiPenStyle.Solid);
                                    footerValue = " ";
                                }

                                FooterBand.Border = new StiBorder(
                                    StiBorderSides.All
                                    , Color.Black, 1, StiPenStyle.Solid);
                                footerValue += footerText.Text.Value ?? string.Empty;
                                footerText.Text.Value = footerValue;

                                if (footerText.Text.Value != string.Empty)
                                {
                                    FooterBand.Components.Add(footerText);
                                }

                                IsSubColumn = SubProp.Headers == null ? false : true;
                                IsExistPosition = false;
                                X = 0;
                                Y = 0;
                                if (!SubProp.ColumnsProperties.FooterTextPosition.Location.IsEmpty)
                                {
                                    IsExistPosition = true;
                                    X = SubProp.ColumnsProperties.FooterTextPosition.Location.X;
                                    Y = SubProp.ColumnsProperties.FooterTextPosition.Location.Y;
                                }

                                AddToWidth = SubProp.ColumnsProperties.FooterAddToWidth;
                                AddToPosition = SubProp.ColumnsProperties.FooterAddToPosition;

                                IsSubColumn = SubProp.Headers == null ? false : true;

                                if (prop.Headers.Last() == SubProp) //Last Prop
                                {
                                    //SubHeaderText.ClientRectangle = new RectangleD(pos.CmToInch(), 0.25 + 0.05, SubColumnWidth, 0.24);
                                    SubHeaderText.ClientRectangle = new RectangleD(pos.CmToInch(),
                                        HeaderBand.Height / 2, SubColumnWidth.CmToInch(), HeaderBand.Height / 2);
                                    if (footerText.Text != string.Empty)
                                    {
                                        footerText.ClientRectangle = new RectangleD(
                                            (IsExistPosition ? pos.CmToInch() + X : pos.CmToInch()) + AddToPosition,
                                            IsExistPosition ? Y : 0, (SubColumnWidth + AddToWidth).CmToInch(), 0.28);
                                    }
                                }
                                else
                                {
                                    SubHeaderText.ClientRectangle =
                                        new RectangleD(pos.CmToInch(), HeaderBand.Height / 2,
                                            SubColumnWidth.CmToInch(), HeaderBand.Height / 2);
                                    if (footerText.Text != string.Empty)
                                    {
                                        footerText.ClientRectangle = new RectangleD(
                                            (IsExistPosition ? pos.CmToInch() + X : pos.CmToInch()) + AddToPosition,
                                            IsExistPosition ? Y : 0, (SubColumnWidth + AddToWidth).CmToInch(), 0.28);
                                    }
                                }
                                //SubHeaderText.ClientRectangle = new RectangleD(pos.CmToInch(), 0.25 + 0.05, SubColumnWidth + 0.005, 0.24);

                                SubHeaderText.Text.Value = SubProp.ColumnsProperties.Text;
                                SubHeaderText.VertAlignment = _SubHeaderVerAlignment;
                                SubHeaderText.HorAlignment = _SubHeaderHorAlignment;
                                SubHeaderText.Brush = _SubForeColor != null ? _SubForeColor : new StiSolidBrush(Color.Beige);
                                SubHeaderText.Font = _SubDatafont != null ? _SubDatafont : new Font("B Nazanin", 13, FontStyle.Bold);
                                SubHeaderText.TextOptions.RightToLeft = _SubRightToLeft;
                                SubHeaderText.TextOptions = _SubTextOption != null ? _SubTextOption : SubHeaderText.TextOptions;
                                SubHeaderText.CanGrow = false;
                                SubHeaderText.Name = "SubHeaderText" + SubProp.Name + (c++).ToString();
                                SubHeaderText.Border = new StiBorder(
                                    StiBorderSides.None
                                    | StiBorderSides.Top
                                    | StiBorderSides.Left
                                    | StiBorderSides.Right
                                    | StiBorderSides.Bottom, Color.Black, 1, StiPenStyle.Solid);
                                HeaderBand.Components.Add(SubHeaderText);

                                if (SubProp.Headers == null) //اگر زیر ستون نداشت
                                {
                                    //Create text on Data 
                                    StiText SubDataText = new StiText();
                                    StiCondition conditionCouples = new StiCondition();
                                    conditionCouples.BackColor = Color.FromArgb(215, 215, 215);
                                    conditionCouples.TextColor = Color.Black;
                                    conditionCouples.Expression = "(Line & 1) == 0";
                                    conditionCouples.Item = StiFilterItem.Expression;
                                    conditionCouples.Font = _SubDatafont != null ? _SubDatafont : SubDataText.Font;
                                    SubDataText.Conditions.Add(conditionCouples);
                                    StiCondition conditionOdd = new StiCondition();
                                    conditionOdd.BackColor = Color.White;
                                    conditionOdd.TextColor = Color.Black;
                                    conditionOdd.Expression = "(Line & 1) == 1";
                                    conditionOdd.Item = StiFilterItem.Expression;
                                    conditionOdd.Font = _SubDatafont != null ? _SubDatafont : SubDataText.Font;
                                    SubDataText.Conditions.Add(conditionOdd);
                                    if (prop.Headers.Last() == SubProp) //Last Prop
                                        SubDataText.ClientRectangle =
                                            new RectangleD(pos.CmToInch(), 0 /*-0.05*/,
                                                SubColumnWidth.CmToInch() + 0.0025, 0.24);
                                    else
                                        SubDataText.ClientRectangle =
                                            new RectangleD(pos.CmToInch(), 0 /*-0.05*/,
                                                SubColumnWidth.CmToInch(), 0.24);
                                    SubDataText.CanGrow = true;
                                    SubDataText.WordWrap = true;
                                    SubDataText.GrowToHeight = true;

                                    if (ReportData.FieldsName != null)
                                    {
                                        if (SubProp.ColumnsProperties.FormatNumeric)
                                            SubDataText.Text.Value = " " + new TextFormat().FormatNumeric("data." + ReportData.FieldsName[IndexFieldName]) + " ";
                                        else
                                            SubDataText.Text.Value = " " + " { data." + ReportData.FieldsName[IndexFieldName] + " } " + " ";
                                        --IndexFieldName;
                                    }
                                    else
                                    {
                                        if (SubProp.ColumnsProperties.FormatNumeric)
                                            SubDataText.Text.Value =
                                                " " + new TextFormat().FormatNumeric(
                                                    "data." + Stimulsoft.Report.CodeDom.StiCodeDomSerializator
                                                        .ReplaceSymbols(SubProp.Name)) + " ";
                                        else
                                            SubDataText.Text.Value =
                                                " { data." +
                                                Stimulsoft.Report.CodeDom.StiCodeDomSerializator.ReplaceSymbols(
                                                    SubProp.Name) + " } " + " ";
                                    }

                                    SubDataText.Border = new StiBorder(
                                        StiBorderSides.All, Color.Black, 1,
                                        StiPenStyle.Solid);
                                    ColumnIndex++;
                                    SubDataText.Name = "SubDataText" + SubHeaderText.Name + (c++).ToString();
                                    SubDataText.TextOptions.RightToLeft = _SubRightToLeft;
                                    _dataBand.EvenStyle = report.Styles[0].Name;
                                    SubDataText.TextOptions =
                                        _SubTextOption != null ? _SubTextOption : SubDataText.TextOptions;
                                    SubDataText.HorAlignment = _SubDataHorAlignment;
                                    SubDataText.VertAlignment = _SubDataVerAlignment;
                                    SubDataText.Font = _SubDatafont != null ? _SubDatafont : SubDataText.Font;
                                    pos = pos + SubColumnWidth;
                                    _dataBand.Components.Add(SubDataText);
                                    MaxHeight = SubDataText.Height > MaxHeight ? SubDataText.Height : MaxHeight;

                                }
                            }
                        }
                    });

                HeaderBand.Border = new StiBorder(
                    StiBorderSides
                        .None
                    | StiBorderSides.Top
                    | StiBorderSides.Right
                    | StiBorderSides.Left
                    | StiBorderSides.Bottom, Color.Black, 1,
                    StiPenStyle.Solid);

                _dataBand.Border = new StiBorder(
                    StiBorderSides.None
                    | StiBorderSides.Top
                    | StiBorderSides.Right
                    | StiBorderSides.Left
                    | StiBorderSides.Bottom, Color.Black, 1,
                    StiPenStyle.Solid);
            }

            ////Create text on footer
            //StiText footerText1 = new StiText(new RectangleD(0, 0, page.Width, 0.5));
            //footerText1.Text.Value = "Count - {Count()}";
            //footerText1.HorAlignment = StiTextHorAlignment.Right;
            //footerText1.Operator = "FooterText";

            //Stimulsoft.BalanceResult.StiOptions.Configuration.DirectoryLocalization = TestStiReport2010.Properties.Resources.fa;

            //Stimulsoft.BalanceResult.StiOptions.Configuration.DirectoryLocalization = string.Format(@"{0}Localization\fa.xml", AppDomain.CurrentDomain.BaseDirectory);//Dpk.Welfare.Loan.Common.Properties.Resources.fa;

            StiOptions.Configuration.Localization = "fa.xml";
            Stimulsoft.Base.Localization.StiLocalization.CultureName = "fa";
            StiOptions.Viewer.RightToLeft = StiRightToLeftType.Yes;

            StiPreviewConfigService config = StiConfig.Services.GetService(typeof(StiPreviewConfigService)) as StiPreviewConfigService;
            config.OpenEnabled = false;
            config.SaveDocumentFileEnabled = false;
            config.SendEMailEnabled = false;
            config.PageNewEnabled = false;
            config.ToolEditorEnabled = false;
            config.PageDeleteEnabled = false;
            config.PageDesignEnabled = false;
            config.PageSizeEnabled = false;
            config.ToolEditorEnabled = false;
            config.ToolSelectEnabled = false;
            config.ZoomEnabled = false;
            config.PageViewModeEnabled = false;
            foreach (StiService service in StiConfig.Services.GetServices(typeof(StiExportService)))
            {
                if (!(service is StiPdfExportService) && !(service is StiExcel2007ExportService))
                {
                    service.ServiceEnabled = false;
                }
            }

            report.Unit = Stimulsoft.Report.Units.StiUnit.Inches;
            report.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            Page.ReportUnit = Stimulsoft.Report.Units.StiUnit.Inches;
            if (HeaderBand != null)
            {
                HeaderBand.Report.Unit = Stimulsoft.Report.Units.StiUnit.Inches;
                HeaderBand.Report.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;

            }

            if (FooterBand != null)
            {
                FooterBand.Report.Unit = Stimulsoft.Report.Units.StiUnit.Inches;
                FooterBand.Report.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            }

            PageHeaderBand.Report.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;

            //Render without progress bar
            report.Render(false);

            //if (!String.IsNullOrEmpty(SaveAs))
            //{
            //    switch (SaveAsFormat)
            //    {
            //        case FileFormats.FORMATS.HTML:
            //            reportCtrl.ExportDocument(StiExportFormat.Html, SaveAs);
            //            break;
            //        case FileFormats.FORMATS.TEXT:
            //            reportCtrl.ExportDocument(StiExportFormat.Text, SaveAs);
            //            break;
            //        case FileFormats.FORMATS.PDF:
            //            reportCtrl.ExportDocument(StiExportFormat.Pdf, SaveAs);
            //            break;
            //        case FileFormats.FORMATS.WORD:
            //            reportCtrl.ExportDocument(StiExportFormat.Word2007, SaveAs);
            //            break;
            //        case FileFormats.FORMATS.EXCEL:
            //            reportCtrl.ExportDocument(StiExportFormat.Excel, SaveAs);
            //            break;
            //        default:
            //            throw new Exception("File Format not supported");
            //    }
            //}

            report.Show();
        }
    }
}