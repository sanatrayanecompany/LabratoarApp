using PSPHelper;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PaymentStationApp
{
    /// Interaction logic for PinPad.xaml
    public partial class PinPad : UserControl
    {
        TransactionInfo TransactionInfo { get; set; }

        public PinPad(TransactionInfo transactionInfo)
        {
            InitializeComponent();
            TransactionInfo = transactionInfo;
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int passLen = PasswordBox.Password.Length;

            if (e.Key == Key.D && passLen == 4)
            {
                e.Handled = true;
                ConfirmButton_Click(sender, e);
            }
            else if (e.Key == Key.B && passLen > 0)
            {
                PasswordBox.Password = PasswordBox.Password.Substring(0, passLen - 1);
            }
            else if(e.Key == Key.A || e.Key == Key.H)
            {
                e.Handled = true;
                CancleButton_Click(sender, e);
            }

            //var key = TransactionInfo.Insertkey(e);
            //if (key != null)
            //{
            //    PasswordBox.Password += key;
            //}
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PasswordBox.Focus();
        }
        
        private void PasswordBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var pinblock = new PinBlock();
            byte[] pinBlockbytes = pinblock.CalculatePINBlock(TransactionInfo.Pan, 16, PasswordBox.Password, 4);

            string resultPibblock = pinblock.EncryptDESIpg(pinBlockbytes);

            TransactionInfo.Pinblock = resultPibblock;

            TransactionInfo.GoToPage(Pages.SelectOperationPage);
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionInfo.GoToPage(Pages.CardReaderPage);
        }
    }
}
