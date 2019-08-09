using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaymentStationApp.View
{
    /// <summary>
    /// Interaction logic for SelectMCIVoucher.xaml
    /// </summary>
    public partial class SelectMCIVoucher : UserControl
    {
        private int price = 0;

        private TransactionInfo TransactionInfo { get; set; }

        public SelectMCIVoucher(TransactionInfo transactionInfo)
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
                case Key.C:
                    WemanButton_Click(sender, e);
                    break;
                case Key.D:
                    YoungButton_Click(sender, e);
                    break;
                case Key.F:
                    IdealButton_Click(sender, e);
                    break;
                case Key.G:
                    ImaginationButton_Click(sender, e);
                    break;
            }
        }

        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.ProfileId = 3; // عادی
            TransactionInfo.GoToPage(Pages.SelectVoucherPricePage);
        }

        private void WemanButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.ProfileId = 8; // بانوان
            TransactionInfo.GoToPage(Pages.SelectVoucherPricePage);
        }

        private void YoungButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.ProfileId = 6; // جوانان
            TransactionInfo.GoToPage(Pages.SelectVoucherPricePage);
        }

        private void IdealButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.ProfileId = 4; // دلخواه
            TransactionInfo.GoToPage(Pages.SelectVoucherPricePage);
        }

        private void ImaginationButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.TopupRequest.ProfileId = 5; // فوق العاده
            TransactionInfo.GoToPage(Pages.SelectVoucherPricePage);
        }
    }
}
