using Core.Business;
using Stimulsoft.Report;
using System;
using System.Linq;

namespace PaymentStationApp
{
    public static partial class TransactionServices
    {
        public static void Payment(TransactionInfo transactionInfo)
        {
            var reqPay = new RequestPay()
            {
                amount = transactionInfo.InputPrice,
                localIP = AppGlobal.LocalIP,
                PAN = transactionInfo.Pan,
                PINBlock = transactionInfo.Pinblock,
                serial = AppGlobal.Serial,
                terminalID = AppGlobal.TerminalID,
                track2Ciphered = transactionInfo.Track2Card
            };

            var cardIssuerBank = AppGlobal.BankCardNumList
                .FirstOrDefault(w => w.CardNumber == reqPay.PAN.Substring(0, 6)).Name;
            var PanRecipt = $"{reqPay.PAN.Substring(0, 6)}××××××{reqPay.PAN.Substring(11, 4)}";

            var result = HttpHelper.Post("http://37.156.22.197:8080/api/PaymentSrv/PaymentRequest", reqPay);
            var report = new StiReport();
            string ReportName = string.Empty;
            if (result != null && result.Status != "TransactionFaild")
            {
                ReportName = "ReciptSuccess.mrt";
                var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}Recipts\\{ReportName}";
                report.Load(reportPath);

                report.Dictionary.Variables.Add("terminalID", reqPay.terminalID);
                report.Dictionary.Variables.Add("PAN", PanRecipt);
                report.Dictionary.Variables.Add("cardIssuerBank", cardIssuerBank);
                report.Dictionary.Variables.Add("PSPRefNo", result.RefNo ?? string.Empty);
                report.Dictionary.Variables.Add("systemRefNo", result.ClientRefNo ?? string.Empty);
                report.Dictionary.Variables.Add("transactionStatus", result.Message);
                report.Dictionary.Variables.Add("amount", reqPay.amount);
            }
            else
            {
                ReportName = "ReciptFailed.mrt";
                var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}Recipts\\{ReportName}";
                report.Load(reportPath);

                report.Dictionary.Variables.Add("terminalID", reqPay.terminalID);
                report.Dictionary.Variables.Add("PAN", PanRecipt);
                report.Dictionary.Variables.Add("cardIssuerBank", cardIssuerBank);
                report.Dictionary.Variables.Add("transactionStatus", result != null ? result.Message : "تراکنش ناموفق");
            }

            try
            {
                report.Print(false);
            }
            catch (Exception)
            {
                if (result != null)
                {
                    result.Message += $"{Environment.NewLine}در حال حاضر امکان چاپ رسید وجود ندارد.";

                }
            }
        }
    }
}
