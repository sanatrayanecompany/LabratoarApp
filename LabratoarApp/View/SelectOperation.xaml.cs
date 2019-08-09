using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp
{
    /// Interaction logic for SelectOperation.xaml
    public partial class SelectOperation : UserControl
    {
        TransactionInfo TransactionInfo { get; set; }

        public SelectOperation(TransactionInfo transactionInfo)
        {
            InitializeComponent();
            TransactionInfo = transactionInfo;
        }

        TransactionInfo _tranInfo { get; set; }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.Key)
            {
                case Key.A:
                    PaymentButton_Click(sender, e);
                    break;
                case Key.B:
                    TopupButton_Click(sender, e);
                    break;
                case Key.C:
                    BillRequestButton_Click(sender, e);
                    break;
                default:
                    TransactionInfo.GoToPage(Pages.SelectOperationPage);
                    break;
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PaymentButton.Focus();
        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.GoToPage(Pages.SelectPaymentOperationPage);
        }

       
        private void TopupButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest = new TopupRequest();
            TransactionInfo.GoToPage(Pages.SelectVoucherOperatorPage);
        }

        private void BillRequestButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.BillRequest = new BillRequest();
            TransactionInfo.GoToPage(Pages.InputPaymentIdPage);
        }
    }
}
