using PSPHelper;
using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStationApp
{
    /// Interaction logic for CardReader.xaml
    public partial class CardReader : UserControl
    {
        private StringBuilder cardData = new StringBuilder();
        
        TransactionInfo TransactionInfo { get; set; }

        public CardReader(TransactionInfo transactionInfo)
        {
            InitializeComponent();
            TransactionInfo = transactionInfo;
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RichText.Focus();

            if (!InputLanguageManager.Current.CurrentInputLanguage.EnglishName.Contains("English"))
            {
                var original = System.Windows.Forms.InputLanguage.CurrentInputLanguage;
                var language = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo.GetCultureInfo("en-us"));
                if (System.Windows.Forms.InputLanguage.InstalledInputLanguages.IndexOf(language) >= 0)
                    System.Windows.Forms.InputLanguage.CurrentInputLanguage = language;
                else
                    System.Windows.Forms.InputLanguage.CurrentInputLanguage =
                        System.Windows.Forms.InputLanguage.DefaultInputLanguage;
            }
        }
        
        private void EndReadCard()
        {
            TransactionInfo.Track2Card = new Track2Card().CreateTrack2FanAva(cardData.ToString());
            TransactionInfo.Pan = cardData.ToString().Substring(1, 16);

            TransactionInfo.GoToPage(Pages.PinPadPage);
        }

        public string GetTrack2(string value)
        {
            try
            {
                cardData = new StringBuilder();
                bool findFirstChar = false;
                bool findLastChar = false;

                for (int i = 0; i < value.Length; i++)
                {
                    string currentChar = value[i].ToString();
                    if (!findLastChar)
                    {
                        if (currentChar == ";")
                        {
                            findFirstChar = true;
                        }

                        if (findFirstChar && (currentChar == "?"))
                        {
                            cardData.Append(currentChar);
                            findLastChar = true;
                            return cardData.ToString();
                        }

                        if (findFirstChar && !findLastChar)
                        {
                            cardData.Append(currentChar);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return string.Empty;
        }

        private void RichText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((RichTextBox) sender).Text();
                if (text == string.Empty)
                    return;
                string track2Val = GetTrack2(text);
                if (track2Val != string.Empty)
                {
                    EndReadCard();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
