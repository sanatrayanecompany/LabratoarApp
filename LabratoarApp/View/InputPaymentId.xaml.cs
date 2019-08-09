using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp.View
{
    /// <summary>
    /// Interaction logic for InputPaymentIdPage.xaml
    /// </summary>
    public partial class InputPaymentId : UserControl
    {
        public InputPaymentId(TransactionInfo transactionInfo)
        {
            InitializeComponent();
            TransactionInfo = transactionInfo;
        }

        TransactionInfo TransactionInfo { get; set; }
        private int _paymentIdLen;
        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _paymentIdLen = PaymentIdBox.Text.Length;

            if (e.Key == Key.D && !string.IsNullOrEmpty(PaymentIdBox.Text))
            {
                e.Handled = true;
                ConfirmButton_Click(sender, e);
            }
            else if (e.Key == Key.B && _paymentIdLen > 0)
            {
                PaymentIdBox.Text = PaymentIdBox.Text.Substring(0, _paymentIdLen - 1);
            }
            else if (e.Key == Key.A || e.Key == Key.H)
            {
                CancleButton_Click(sender, e);
            }

            //var key = TransactionInfo.Insertkey(e);
            //if (key != null)
            //{
            //    PaymentIdBox.Text += key;
            //}
        }

        private void PaymentIdBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PaymentIdBox.Focus();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (_paymentIdLen > 6 && _paymentIdLen <= 13)
            {
                TransactionInfo.BillRequest.PaymentId = PaymentIdBox.Text;
                TransactionInfo.GoToPage(Pages.InputBillRequestIdPage);
            }
            else
            {
                LabelMessage.Content = "شناسه پرداخت وارد شده صحیح نمی باشد";
                PaymentIdBox.Focus();
            }
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.GoToPage(Pages.FinalPage);
        }
    }
}
