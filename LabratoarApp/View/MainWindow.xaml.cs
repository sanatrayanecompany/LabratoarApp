﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace PaymentStationApp
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // LicenceKey for cracking Stimulsoft
            Stimulsoft.Base.StiLicense.Key =
                "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";

            InitializeComponent();
            InitializePages();
            
            Timer = new DispatcherTimer();
            Timer.Tick += timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);

            PageTrans.TransitionType = (WpfPageTransitions.PageTransitionType) Enum.Parse(
                typeof(PageTransitionType),
                PageTransitionType.SlideAndFade.ToString(),
                true);
        }
        
        public DispatcherTimer Timer { get; set; }
        public TransactionInfo TransactionInfo { get; set; }
        private List<Creator> creators = new List<Creator>();

        void timer_Tick(object sender, EventArgs e)
        {
            var time = Convert.ToInt16(TimerLabel.Content) - 1;
            ClockBox.Stroke = new SolidColorBrush(Colors.DodgerBlue);

            if (time < 7 && time % 2 == 1)
            {
                ClockBox.Stroke = new SolidColorBrush(Colors.DarkRed);
            }

            if (time < 0)
            {
                TransactionInfo.CurrentPage = Pages.CardReaderPage;
                TransactionInfo.MainWin.SetPage();
                Timer.Stop();
            }

            TimerLabel.Content = time;
        }

        public List<Creator> Creators
        {
            get => creators;
            set => creators = value;
        }

        public void InitializePages()
        {
            Creators.Add(new CreatorCardReader());
            Creators.Add(new CreatorPinPad());
            Creators.Add(new CreatorSelectOperation());
            Creators.Add(new CreatorSelectPaymentOperation());
            Creators.Add(new CreatorInputPrice());
            Creators.Add(new CreatorConfirmPayment());
            Creators.Add(new CreatorSelectVoucherOperator());
            Creators.Add(new CreatorSeletVoucherPrice());
            Creators.Add(new CreatorFinalPage());
            Creators.Add(new CreatorInputPaymentId());
            Creators.Add(new CreatorInputBillRequestId());
            Creators.Add(new CreatorInputMobileNO());
            Creators.Add(new CreatorSelectMTNVoucher());
            Creators.Add(new CreatorSelectMCIVoucher());
            Creators.Add(new CreatorSelectRitelVoucher());

            ClockBox.Visibility = Visibility.Hidden;
            TimerLabel.Visibility = Visibility.Hidden;

            TransactionInfo = new TransactionInfo();
            var request = new Request();
            TransactionInfo.MainWin = this;

            var currentPage = Creators[(int) TransactionInfo.CurrentPage].FactoryMethod(TransactionInfo);
            PageTrans.ShowPage(currentPage);
        }

        public void SetPage()
        {
            if (TransactionInfo.CurrentPage == Pages.CardReaderPage)
            {
                ClockBox.Visibility = Visibility.Hidden;
                TimerLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                TimerLabel.Content = "30";
                Timer.Start();
                ClockBox.Visibility = Visibility.Visible;
                TimerLabel.Visibility = Visibility.Visible;
            }

            var currentPage = Creators[(int) TransactionInfo.CurrentPage].FactoryMethod(TransactionInfo);
            PageTrans.ShowPage(currentPage);
        }

        public void ResetValues()
        {
            TransactionInfo.Pan = null;
            TransactionInfo.Pinblock = null;
            TransactionInfo.Result = null;
            TransactionInfo.Track2Card = null;
            TransactionInfo.PaymentRequest = null;
            TransactionInfo.BillRequest = null;
            TransactionInfo.TopupRequest = null;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void PageTrans_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
