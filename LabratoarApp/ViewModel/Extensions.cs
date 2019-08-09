using System.Windows.Controls;
using System.Windows.Documents;

namespace PaymentStationApp
{
    public static class Extensions
    {
        public static string Text(this RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }
    }
}
