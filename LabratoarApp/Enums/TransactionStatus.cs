namespace PaymentStationApp.Enums
{
    public enum TransactionStatus
    {
        SuccessfulTransaction = 0,// تراکنش موفق
        TransactionFaild = 1,// تراکنش ناموفق
        LackOfEnoughAmount = 2,// عدم موجودی کافی
        InvalidPassword = 3// رمز نامعتبر است

    }
}
