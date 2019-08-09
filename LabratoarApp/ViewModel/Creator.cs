using System.Windows.Controls;
using PaymentStationApp.View;

namespace PaymentStationApp
{
    public abstract class Creator
    {
        public abstract UserControl FactoryMethod(TransactionInfo transactionInfo);
    }

    public class CreatorSelectOperation : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new SelectOperation(transactionInfo);
        }
    }

    public class CreatorSelectPaymentOperation : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new SelectPaymentOperation(transactionInfo);
        }
    }

    public class CreatorCardReader : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new CardReader(transactionInfo);
        }
    }

    public class CreatorPinPad : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new PinPad(transactionInfo);
        }
    }

    public class CreatorInputPrice : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new InputPrice(transactionInfo);
        }
    }


    public class CreatorConfirmPayment : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new ConfirmPayment(transactionInfo);
        }
    }
    
    public class CreatorSelectVoucherOperator : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new SelectVoucherOperator(transactionInfo);
        }
    }

    public class CreatorSeletVoucherPrice : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new SelectVoucherPrice(transactionInfo);
        }
    }

    public class CreatorFinalPage : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new FinalPage(transactionInfo);
        }
    }

    public class CreatorInputPaymentId : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new InputPaymentId(transactionInfo);
        }
    }

    public class CreatorInputBillRequestId : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new InputBillRequestId(transactionInfo);
        }
    }

    public class CreatorInputMobileNO : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new InputMobileNO(transactionInfo);
        }
    }

    public class CreatorSelectVoucherPrice : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new SelectVoucherPrice(transactionInfo);
        }
    }

    public class CreatorSelectMTNVoucher : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new SelectMTNVoucher(transactionInfo);
        }
    }

    public class CreatorSelectMCIVoucher : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new SelectMCIVoucher(transactionInfo);
        }
    }

    public class CreatorSelectRitelVoucher : Creator
    {
        public override UserControl FactoryMethod(TransactionInfo transactionInfo)
        {
            return new SelectRitelVoucher(transactionInfo);
        }
    }
}
