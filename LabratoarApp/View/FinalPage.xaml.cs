using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PaymentStationApp.View
{
    /// Interaction logic for FinalPage.xaml
    public partial class FinalPage : UserControl
    {
        public FinalPage(TransactionInfo transactionInfo)
        {
            InitializeComponent();

            TransactionInfo = transactionInfo;
            LabelMessage.Content = string.Format("آیا می خواهید ادامه دهید؟");
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
            TransactionInfo.PaymentRequest = null;
            TransactionInfo.BillRequest = null;
            TransactionInfo.TopupRequest = null;

            TransactionInfo.Result = null;
            TransactionInfo.GoToPage(Pages.SelectOperationPage);
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.MainWin.ResetValues();
            TransactionInfo.GoToPage(Pages.CardReaderPage);
        }
    }
}
