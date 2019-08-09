using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PaymentStationApp.Enums;

namespace PaymentStationApp.View
{
    /// Interaction logic for SelectVoucherOperatorPage.xaml
    public partial class SelectVoucherOperator : UserControl
    {
        TransactionInfo TransactionInfo { get; set; }

        public SelectVoucherOperator(TransactionInfo transactionInfo)
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
                    MTNButton_Click(sender, e);
                    break;
                case Key.B:
                    MCIButton_Click(sender, e);
                    break;
                case Key.E:
                    RitelButton_Click(sender, e);
                    break;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MTNButton.Focus();
        }

        private void MTNButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.VoucherOperator = VoucherOperator.MTN;
            TransactionInfo.GoToPage(Pages.SelectMTNPage);
        }

        private void MCIButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.VoucherOperator = VoucherOperator.MCI;
            TransactionInfo.GoToPage(Pages.SelectMCIPage);
        }

        private void RitelButton_Click(object sender, RoutedEventArgs e)
        {

            TransactionInfo.TopupRequest.VoucherOperator = VoucherOperator.Ritel;
            TransactionInfo.GoToPage(Pages.SelectRitelPage);
        }
    }
}