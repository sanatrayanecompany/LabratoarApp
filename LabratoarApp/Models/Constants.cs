namespace PaymentStationApp
{
    public enum Pages
    {
        CardReaderPage,
        PinPadPage,
        SelectOperationPage,
        SelectPaymentOperationPage,
        InputPricePage,
        ConfirmPaymentPage,
        SelectVoucherOperatorPage,
        SelectVoucherPricePage,
        FinalPage,
        InputPaymentIdPage,
        InputBillRequestIdPage,
        InputMobileNO,
        SelectMTNPage,
        SelectMCIPage,
        SelectRitelPage
    }

    public enum PageTransitionType
    {
        Fade,
        Slide,
        SlideAndFade,
        Grow,
        GrowAndFade,
        Flip,
        FlipAndFade,
        Spin,
        SpinAndFade
    }
}
