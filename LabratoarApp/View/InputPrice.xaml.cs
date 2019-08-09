using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp
{
    /// Interaction logic for InputPrice.xaml
    public partial class InputPrice : UserControl
    {
        public InputPrice(TransactionInfo transactionInfo)
        {
            InitializeComponent();
            TransactionInfo = transactionInfo;
        }

        TransactionInfo TransactionInfo { get; set; }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int passLen = PriceBox.Text.Length;
            LabelMessage.Content = string.Empty;

            if (e.Key == Key.D && !string.IsNullOrEmpty(PriceBox.Text))
            {
                e.Handled = true;
                ConfirmButton_Click(sender, e);
            }
            else if (e.Key == Key.B && passLen > 0)
            {
                PriceBox.Text = PriceBox.Text.Substring(0, passLen - 1);
            }
            else if (e.Key == Key.A || e.Key == Key.H)
            {
                e.Handled = true;
                CancleButton_Click(sender, e);
            }

            //var key = TransactionInfo.Insertkey(e);
            //if (key != null)
            //{
            //    PriceBox.Text += key;
            //}
        }

        private void PriceBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TryCheckAmountValidation();
        }

        private void PriceBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PriceBox.Focus();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (TryCheckAmountValidation())
            {

                if (TransactionInfo.PaymentRequest != null)
                {
                    TransactionInfo.PaymentRequest.Amount = PriceBox.Text;
                    TransactionInfo.GoToPage(Pages.ConfirmPaymentPage);
                }
            }
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.GoToPage(Pages.FinalPage);
        }

        private bool TryCheckAmountValidation()
        {
            if (Int64.TryParse(PriceBox.Text, out Int64 price))
            {
                if (TransactionInfo.PaymentRequest != null && price > 500000000)
                {
                    LabelMessage.Content = "سقف خرید روزانه پانصد میلیون ریال می باشد.";
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
