using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp.View
{
    /// <summary>
    /// Interaction logic for InputMobileNO.xaml
    /// </summary>
    public partial class InputMobileNO : UserControl
    {
        public TransactionInfo TransactionInfo { get; set; }

        private int MobileNOLen;

        public InputMobileNO(TransactionInfo transactionInfo)
        {
            TransactionInfo = transactionInfo;
            InitializeComponent();
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MobileNOLen = MobileBox.Text.Length;
            LabelMessage.Content = string.Empty;

            if (e.Key == Key.D && !string.IsNullOrEmpty(MobileBox.Text))
            {
                e.Handled = true;
                ConfirmButton_Click(sender, e);
            }
            else if (e.Key == Key.B && MobileNOLen > 0)
            {
                MobileBox.Text = MobileBox.Text.Substring(0, MobileNOLen - 1);
            }
            else if (e.Key == Key.A || e.Key == Key.H)
            {
                e.Handled = true;
                CancleButton_Click(sender, e);
            }

            //var key = TransactionInfo.Insertkey(e);
            //if (key != null)
            //{
            //    MobileBox.Text += key;
            //}
        }

        private void MobileBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MobileBox.Focus();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (MobileBox.Text.Length == 11 && TryCheckMobileNOBoxValidation(MobileBox.Text))
            {
                TransactionInfo.TopupRequest.Mobile = MobileBox.Text;

                TransactionInfo.GoToPage(Pages.ConfirmPaymentPage);
            }
            else 
            {
                LabelMessage.Content = "شماره موبایل وارد شده صحیح نمی باشد";
                MobileBox.Focus();
            }
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.GoToPage(Pages.FinalPage);
        }

        private void MobileBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LabelMessage.Content = string.Empty;
            TryCheckMobileNOBoxValidation(MobileBox.Text);
        }

       private bool TryCheckMobileNOBoxValidation(string destPAN)
        {
            if (AppGlobal.MobilePrefixNo.Keys.All(k =>
                k.Substring(0, destPAN.Length > 4 ? 4 : destPAN.Length) !=
                destPAN.Substring(0, destPAN.Length > 4 ? 4 : destPAN.Length)))
            {
                LabelMessage.Content = "شماره موبایل وارد شده صحیح نمی باشد";
                return false;
            }

            return true;
        }
    }
}
