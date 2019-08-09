using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PaymentStationApp.Enums;

namespace PaymentStationApp
{
    /// Interaction logic for ConfirmPayment.xaml
    public partial class ConfirmPayment : UserControl
    {
        public ConfirmPayment(TransactionInfo transactionInfo)
        {
            InitializeComponent();
            
            TransactionInfo = transactionInfo;
            string price = null;
            string titleMessage = string.Empty;
         
            if (TransactionInfo.PaymentRequest != null)
            {
                titleMessage = "خرید";
                price = transactionInfo.PaymentRequest.Amount;
            }


            if (transactionInfo.BillRequest != null)
            {
                titleMessage = string.Format("پرداخت قبض به شناسه پرداخت{0} و شناسه قبض{1}" , transactionInfo.BillRequest.PaymentId, transactionInfo.BillRequest.BillId);
                var strLenght = transactionInfo.BillRequest.PaymentId.Length;
                price = transactionInfo.BillRequest.Amount = transactionInfo.BillRequest.PaymentId.Substring(0, strLenght - 5)+"000";
            }

            if (transactionInfo.TopupRequest != null)
            {
                titleMessage = string.Format("شارژ {0}  ریالی {1} طرح {2}", transactionInfo.TopupRequest.Amount, GetOperatorName(transactionInfo.TopupRequest.VoucherOperator), GetOperatorName(transactionInfo.TopupRequest.ProfileId));
                price = transactionInfo.TopupRequest.Amount;
            }

            if (double.TryParse(price, out double result))
            {
                TitleLabel.Content = titleMessage;
                MessageLabel.Content = string.Format("آیا واریز مبلغ {0} ریال را تایید می کنید؟", price);
            }
            else
            {
                MessageLabel.Content = string.Format("تراکنش ناموفق", price);
                MessageLabel.Content = price;
            }
        }

        private string GetOperatorName(VoucherOperator voucherOperator)
        {
            switch (voucherOperator)
            {
                case VoucherOperator.MTN:
                    return "ایرانسل";
                case VoucherOperator.MCI:
                    return "همراه اول";
                case VoucherOperator.Ritel:
                    return "رایتل";
            }

            return null;
        }

        private string GetOperatorName(int ProfileId)
        {
            switch (ProfileId)
            {
                case 3:
                    return "مستقیم";
                case 4:
                    return "دلخواه";
                case 5:
                    return "فوق العاده";
                case 6:
                    return "جوانان";
                case 8:
                    return "بانوان";
                case 19:
                    return "شگفت انگیز";
                case 20:
                    return "عادی";
                case 41:
                    return "عادی و دلخواه";
                case 42:
                    return "شور انگیز";
            }

            return null;
        }

        TransactionInfo TransactionInfo { get; set; }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D || e.Key == Key.Enter)
            {
                ConfirmButton_Click(sender, e);
            }
            else if (e.Key == Key.A || e.Key == Key.H)
            {
                CancleButton_Click(sender, e);
            }
            e.Handled = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ConfirmButton.Focus();
        }
        
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (TransactionInfo.PaymentRequest != null)
            {
                TransactionServices.Payment(TransactionInfo);

            }
            else if (TransactionInfo.BillRequest != null)
            {
                TransactionServices.BillRequest(TransactionInfo);
            }
            else if (TransactionInfo.TopupRequest != null)
            {
                TransactionServices.Topup(TransactionInfo);
            }
            TransactionInfo.GoToPage(Pages.FinalPage);
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.GoToPage(Pages.FinalPage);
        }
    }
}
