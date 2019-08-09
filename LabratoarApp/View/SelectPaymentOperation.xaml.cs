using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp.View
{
    /// <summary>
    /// Interaction logic for SelectPaymentOperation.xaml
    /// </summary>
    public partial class SelectPaymentOperation : UserControl
    {
        TransactionInfo TransactionInfo { get; set; }

        public SelectPaymentOperation(TransactionInfo transactionInfo)
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
                    LabratoarButton_Click(sender, e);
                    break;
                case Key.B:
                    SonographyButton_Click(sender, e);
                    break;
                case Key.C:
                    CTscanButton_Click(sender, e);
                    break;
                case Key.D:
                    RadiologyButton_Click(sender, e);
                    break;
                default:
                    TransactionInfo.GoToPage(Pages.SelectOperationPage);
                    break;
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LabratoarButton.Focus();
        }

        private void LabratoarButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.PaymentRequest = new PaymentRequest() { UnitId = 2 };
            TransactionInfo.GoToPage(Pages.InputPricePage);
        }

        private void SonographyButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.PaymentRequest = new PaymentRequest(){UnitId = 4};
            TransactionInfo.GoToPage(Pages.InputPricePage);
        }

        private void CTscanButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.PaymentRequest = new PaymentRequest() { UnitId = 5 };
            TransactionInfo.GoToPage(Pages.InputPricePage);
        }

        private void RadiologyButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.PaymentRequest = new PaymentRequest() { UnitId = 3 };
            TransactionInfo.GoToPage(Pages.InputPricePage);
        }
    }
}
