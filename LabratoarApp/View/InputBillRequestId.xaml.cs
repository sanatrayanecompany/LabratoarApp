using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp.View
{
    /// <summary>
    /// Interaction logic for InputBillRequestIdPage.xaml
    /// </summary>
    public partial class InputBillRequestId : UserControl
    {
        public InputBillRequestId(TransactionInfo transactionInfo)
        {
            TransactionInfo = transactionInfo;
            InitializeComponent();
        }

        TransactionInfo TransactionInfo { get; set; }
        private int _billIdLen;

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _billIdLen = BillIdBox.Text.Length;

            if (e.Key == Key.D && !string.IsNullOrEmpty(BillIdBox.Text))
            {
                e.Handled = true;
                ConfirmButton_Click(sender, e);
            }
            else if (e.Key == Key.B && _billIdLen > 0)
            {
                BillIdBox.Text = BillIdBox.Text.Substring(0, _billIdLen - 1);
            }
            else if (e.Key == Key.A || e.Key == Key.H)
            {
                CancleButton_Click(sender, e);
            }

            //var key = TransactionInfo.Insertkey(e);
            //if (key != null)
            //{
            //    BillIdBox.Text += key;
            //}
        }

        private void BillIdBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BillIdBox.Focus();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (_billIdLen > 6 && _billIdLen <= 13)
            {
                TransactionInfo.BillRequest.BillId = BillIdBox.Text;
                TransactionInfo.GoToPage(Pages.ConfirmPaymentPage);
            }
            else
            {
                LabelMessage.Content = "شناسه قبض وارد شده صحیح نمی باشد";
                BillIdBox.Focus();
            }
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.GoToPage(Pages.FinalPage);
        }
    }
}
