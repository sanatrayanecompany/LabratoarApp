using Core.Business;
using Stimulsoft.Report;
using System;
using System.Linq;
using System.Threading;

namespace PaymentStationApp
{
    public static partial class TransactionServices
    {
        //private static string serverAddress = "http://37.156.22.197:8000";
        private static string serverAddress = "http://localhost:8080";
        private static int customerId = 1;
        private static string customerName ;
        private static string customerTell;


        public static void Payment(TransactionInfo transactionInfo)
        {
            var paymentRequest = new PaymentRequest()
            {
                CustomerId = customerId,
                Amount = transactionInfo.PaymentRequest.Amount,
                LocalIP = AppGlobal.LocalIP,
                PAN = transactionInfo.Pan,
                PINBlock = transactionInfo.Pinblock,
                Serial = AppGlobal.Serial,
                TerminalID = AppGlobal.TerminalID,
                Track2Ciphered = transactionInfo.Track2Card,
            };

            switch (transactionInfo.PaymentRequest.UnitId)
            {
                case 1:
                    customerName = "لوازم خانگی ملاحسینی";
                    customerTell = "8844255";
                    break;
                case 2:
                    customerName = "آزمایشگاه";
                    customerTell = "8844255";
                    break;
                case 3:
                    customerName = "سونوگرافی";
                    customerTell = "77554488";
                    break;
                case 4:
                    customerName = "سی تی اسکن";
                    customerTell = "44775511";
                    break;
                case 5:
                    customerName = "رادیولوژی";
                    customerTell = "88774445";
                    break;
            }

            var cardIssuerBank = AppGlobal.BankCardNumList
                .FirstOrDefault(w => w.Key == paymentRequest.PAN.Substring(0, 6)).Value;
            var PanRecipt = $"{paymentRequest.PAN.Substring(0, 6)}××××××{paymentRequest.PAN.Substring(12, 4)}";

            var result = HttpHelper.Post(serverAddress + "/api/TransactionService/PaymentRequest", paymentRequest,
                new CancellationToken());
            
            var report = new StiReport();
            string ReportName = string.Empty;

            if (result != null && result.Status != "TransactionFaild")
            {
                ReportName = "ReciptSuccess.mrt";
                var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}Recipts\\{ReportName}";
                report.Load(reportPath);


                report.Dictionary.Variables.Add("Transaction", "خرید");
                report.Dictionary.Variables.Add("customerName", customerName);
                report.Dictionary.Variables.Add("customerTell", customerTell);
                report.Dictionary.Variables.Add("terminalID", paymentRequest.TerminalID);
                report.Dictionary.Variables.Add("PAN", PanRecipt);
                report.Dictionary.Variables.Add("cardIssuerBank", cardIssuerBank);
                report.Dictionary.Variables.Add("PSPRefNo", result.RefNo ?? string.Empty);
                report.Dictionary.Variables.Add("systemRefNo", result.ClientRefNo ?? string.Empty);
                report.Dictionary.Variables.Add("transactionStatus", result.Message);
                report.Dictionary.Variables.Add("amount", paymentRequest.Amount);
            }
            else
            {
                ReportName = "ReciptFailed.mrt";
                var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}Recipts\\{ReportName}";
                report.Load(reportPath);

                report.Dictionary.Variables.Add("Transaction", "خرید");
                report.Dictionary.Variables.Add("customerName", customerName);
                report.Dictionary.Variables.Add("customerTell", customerTell);
                report.Dictionary.Variables.Add("terminalID", paymentRequest.TerminalID);
                report.Dictionary.Variables.Add("PAN", PanRecipt);
                report.Dictionary.Variables.Add("cardIssuerBank", cardIssuerBank);
                report.Dictionary.Variables.Add("transactionStatus", result != null ? result.Message : "تراکنش ناموفق");
            }

            try
            {
                report.Print(false);
            }
            catch (Exception ex)
            {
                if (result != null)
                {
                    result.Message += $"{Environment.NewLine}در حال حاضر امکان چاپ رسید وجود ندارد.";
                }
            }
        }
        
        public static void Topup(TransactionInfo transactionInfo)
        {
            var topupMCRequest = new TopupRequest()
            {
                CustomerId = customerId,
                Amount = transactionInfo.TopupRequest.Amount,
                LocalIP = AppGlobal.LocalIP,
                PAN = transactionInfo.Pan,
                PINBlock = transactionInfo.Pinblock,
                Serial = AppGlobal.Serial,
                TerminalID = AppGlobal.TerminalID,
                Track2Ciphered = transactionInfo.Track2Card,
                ProfileId = transactionInfo.TopupRequest.ProfileId,
                Mobile = transactionInfo.TopupRequest.Mobile
            };

            var cardIssuerBank = AppGlobal.BankCardNumList
                .FirstOrDefault(w => w.Key == topupMCRequest.PAN.Substring(0, 6)).Value;
            var PanRecipt = $"{topupMCRequest.PAN.Substring(0, 6)}××××××{topupMCRequest.PAN.Substring(12, 4)}";

            var result = HttpHelper.Post(serverAddress + "/api/TransactionService/TopupRequest", topupMCRequest,
                new CancellationToken());

            var report = new StiReport();
            string ReportName = string.Empty;
            if (result != null && result.Status != "TransactionFaild")
            {
                ReportName = "ReciptSuccess.mrt";
                var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}Recipts\\{ReportName}";
                report.Load(reportPath);

                report.Dictionary.Variables.Add("Transaction", "خرید شارژ");
                report.Dictionary.Variables.Add("customerName", customerName);
                report.Dictionary.Variables.Add("customerTell", customerTell);
                report.Dictionary.Variables.Add("terminalID", topupMCRequest.TerminalID);
                report.Dictionary.Variables.Add("PAN", PanRecipt);
                report.Dictionary.Variables.Add("cardIssuerBank", cardIssuerBank);
                report.Dictionary.Variables.Add("PSPRefNo", result.RefNo ?? string.Empty);
                report.Dictionary.Variables.Add("systemRefNo", result.ClientRefNo ?? string.Empty);
                report.Dictionary.Variables.Add("transactionStatus", result.Message);
                report.Dictionary.Variables.Add("amount", topupMCRequest.Amount);
            }
            else
            {
                ReportName = "ReciptFailed.mrt";
                var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}Recipts\\{ReportName}";
                report.Load(reportPath);

                report.Dictionary.Variables.Add("Transaction", "خرید شارژ");
                report.Dictionary.Variables.Add("customerName", customerName);
                report.Dictionary.Variables.Add("customerTell", customerTell);
                report.Dictionary.Variables.Add("terminalID", topupMCRequest.TerminalID);
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

        public static void BillRequest(TransactionInfo transactionInfo)
        {
            var bill = new BillRequest()
            {
                CustomerId = customerId,
                BillId = transactionInfo.BillRequest.BillId,
                PaymentId = transactionInfo.BillRequest.PaymentId,
                LocalIP = AppGlobal.LocalIP,
                PAN = transactionInfo.Pan,
                PINBlock = transactionInfo.Pinblock,
                Serial = AppGlobal.Serial,
                TerminalID = AppGlobal.TerminalID,
                Track2Ciphered = transactionInfo.Track2Card,
                Amount = transactionInfo.BillRequest.Amount
            };

            var cardIssuerBank = AppGlobal.BankCardNumList
                .FirstOrDefault(w => w.Key == bill.PAN.Substring(0, 6)).Value;
            var PanRecipt = $"{bill.PAN.Substring(0, 6)}××××××{bill.PAN.Substring(12, 4)}";

            var result = HttpHelper.Post(serverAddress + "/api/TransactionService/BillRequest", bill,
                new CancellationToken());

            var report = new StiReport();
            string ReportName = string.Empty;
            if (result != null && result.Status != "TransactionFaild")
            {
                ReportName = "RecipetBill.mrt";
                var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}Recipts\\{ReportName}";
                report.Load(reportPath);
                
                report.Dictionary.Variables.Add("Transaction", "پرداخت قبض");
                report.Dictionary.Variables.Add("customerName", customerName);
                report.Dictionary.Variables.Add("customerTell", customerTell);
                report.Dictionary.Variables.Add("terminalID", bill.TerminalID);
                report.Dictionary.Variables.Add("PAN", PanRecipt);
                report.Dictionary.Variables.Add("cardIssuerBank", cardIssuerBank);
                report.Dictionary.Variables.Add("PSPRefNo", result.RefNo ?? string.Empty);
                report.Dictionary.Variables.Add("systemRefNo", result.ClientRefNo ?? string.Empty);
                report.Dictionary.Variables.Add("transactionStatus", result.Message);
                report.Dictionary.Variables.Add("paymentId", bill.PaymentId);
                report.Dictionary.Variables.Add("billId", bill.BillId);
                report.Dictionary.Variables.Add("amount", bill.Amount);
            }
            else
            {
                ReportName = "ReciptFailed.mrt";
                var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}Recipts\\{ReportName}";
                report.Load(reportPath);

                report.Dictionary.Variables.Add("Transaction", "پرداخت قبض");
                report.Dictionary.Variables.Add("customerName", customerName);
                report.Dictionary.Variables.Add("customerTell", customerTell);
                report.Dictionary.Variables.Add("terminalID", bill.TerminalID);
                report.Dictionary.Variables.Add("PAN", PanRecipt);
                report.Dictionary.Variables.Add("cardIssuerBank", cardIssuerBank);
                report.Dictionary.Variables.Add("transactionStatus", result != null ? result.Message : "تراکنش ناموفق");
            }

            try
            {
                report.Print(false);
            }
            catch (Exception ex)
            {
                if (result != null)
                {
                    result.Message += $"{Environment.NewLine}در حال حاضر امکان چاپ رسید وجود ندارد.";

                }
            }
        }
    }
}
