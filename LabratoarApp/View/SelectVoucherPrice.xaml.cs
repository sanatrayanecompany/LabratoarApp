using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp.View
{
    /// Interaction logic for SelectVoucherPricePage.xaml
    public partial class SelectVoucherPrice : UserControl
    {
        private TransactionInfo TransactionInfo { get; set; }

        public SelectVoucherPrice(TransactionInfo transactionInfo)
        {
            InitializeComponent();
            TransactionInfo = transactionInfo;
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.Key)
            {
                case Key.A:
                    TransactionInfo.GoToPage(Pages.FinalPage);
                    break;
                case Key.B:
                    OneButton_Click(sender, e);
                    break;
                case Key.C:
                    TwoButton_Click(sender, e);
                    break;
                case Key.F:
                    FiveButton_Click(sender, e);
                    break;
                case Key.G:
                    TenButton_Click(sender, e);
                    break;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OneButton.Focus();
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            SelectVoucher(10000);
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            SelectVoucher(20000);
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectVoucher(50000);
        }

        private void TenButton_Click(object sender, RoutedEventArgs e)
        {
            SelectVoucher(100000);
        }

        private void SelectVoucher(int price)
        {
            TransactionInfo.TopupRequest.Amount = price.ToString();
            TransactionInfo.GoToPage(Pages.InputMobileNO);
        }
    }
}
