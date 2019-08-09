using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp.View
{
    /// <summary>
    /// Interaction logic for SelectRitelVoucher.xaml
    /// </summary>
    public partial class SelectRitelVoucher : UserControl
    {
        private int price = 0;

        private TransactionInfo TransactionInfo { get; set; }

        public SelectRitelVoucher(TransactionInfo transactionInfo)
        {
            InitializeComponent();
            TransactionInfo = transactionInfo;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            NormalButton.Focus();
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
                    NormalButton_Click(sender, e);
                    break;
                case Key.F:
                    ImaginationButton_Click(sender, e);
                    break;
            }
        }

        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.ProfileId = 41; // عادی
            TransactionInfo.GoToPage(Pages.SelectVoucherPricePage);
        }

        private void ImaginationButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.ProfileId = 42; // شور انگیز
            TransactionInfo.GoToPage(Pages.SelectVoucherPricePage);
        }
    }
}
