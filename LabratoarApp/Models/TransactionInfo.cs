namespace PaymentStationApp
{
    public class TransactionInfo
    {
        public Pages CurrentPage { get; set; }

        public string Track2Card { get; set; }

        public string Pan { get; set; }

        public string Pinblock { get; set; }

        public bool Confirm { get; set; }

        public MainWindow MainWin { get; set; }

        public ServiceResult Result { get; set; }

        public PaymentRequest PaymentRequest { get; set; }

        public BillRequest BillRequest { get; set; }

        public TopupRequest TopupRequest { get; set; }

        //public char? Insertkey(KeyEventArgs e)
        //{
        //    switch (e.Key)
        //    {
        //        case Key.NumPad0:
        //        {
        //            return '0';
        //        }

        //        case Key.NumPad1:
        //        {
        //            return '1';
        //        }

        //        case Key.NumPad2:
        //        {
        //            return '2';
        //        }

        //        case Key.NumPad3:
        //        {
        //            return '3';
        //        }

        //        case Key.NumPad4:
        //        {
        //            return '4';
        //        }

        //        case Key.NumPad5:
        //        {
        //            return '5';
        //        }

        //        case Key.NumPad6:
        //        {
        //            return '6';
        //        }

        //        case Key.NumPad7:
        //        {
        //            return '7';
        //        }

        //        case Key.NumPad8:
        //        {
        //            return '8';
        //        }

        //        case Key.NumPad9:
        //        {
        //            return '9';
        //        }
        //    }
        //    return null;
        //}

        public void GoToPage(Pages page)
        {
            CurrentPage = page;
            MainWin.SetPage();
        }
    }
}
