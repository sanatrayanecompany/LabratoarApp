using PaymentStationApp.Enums;
using System;
using System.Collections.Generic;

namespace PaymentStationApp
{
    public class AppGlobal
    {
        public static string PinBlock { get; set; }
        public static string Pan { get; set; }
        public static string Track2Card { get; set; }

        public static string Serial
        {
            get { return "139710221001"; }
        }

        public static string STAN
        {
            get { return "100000"; }
        }

        public static string MerchantID
        {
            get { return "71003046"; }
            //get { return "71098358"; }
        }

        public static string TerminalID
        {
            get { return "71002561"; }
            //get { return "71104976"; }
        }

        public static string Date
        {
            get { return DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0'); }
        }

        public static string Time
        {
            get
            {
                return DateTime.Now.Hour.ToString() +
                       DateTime.Now.Minute.ToString() +
                       DateTime.Now.Second.ToString();
            }
        }

        public static string LocalIP
        {
            get { return "172.20.10.2"; }
        }

        public static AuthInfo AuthInfo
        {
            get { return new AuthInfo() {Username = "I_FANAVA", Password = "1343"}; }
        }

        public static Dictionary<string, string> BankCardNumList
        {
            get => _bankCardNumList;
            set => _bankCardNumList = value;
        }

        private static Dictionary<string, string> _bankCardNumList = new Dictionary<string, string>()
        {
           {"621986","بانک سامان"},
           {"207177","بانک توسعه صادرات ایران"},
           {"502229","بانک پاسارگاد"},
           {"502806","بانک شهر"},
           {"502908","بانک توسعه تعاون"},
           {"502910","بانک کارآفرین"},
           {"502938","بانک دی"},
           {"505416","بانک گردشگری"},
           {"505785","بانک ایران زمین"},
           {"505801","موسسه اعتباری کوثر"},
           {"589210","بانک سپه"},
           {"589463","بانک رفاه کارگران"},
           {"603769","بانک صادرات ایران"},
           {"603770","بانک کشاورزی"},
           {"603799","بانک ملی ایران"},
           {"606373","بانک قرض الحسنه مهر ایران"},
           {"610433","بانک ملت"},
           {"622106","بانک پارسیان"},
           {"627353","بانک تجارت"},
           {"627381","بانک انصار"},
           {"627412","بانک اقتصاد نوین"},
           {"627488","بانک کارآفرین"},
           {"627648","بانک توسعه صادرات ایران"},
           {"627760","پست بانک ایران"},
           {"627884","بانک پارسیان"},
           {"627961","بانک صنعت و معدن"},
           {"628023","بانک مسکن"},
           {"628157","موسسه اعتباری توسعه"},
           {"636214","بانک تات"},
           {"636795","بانک مرکزی"},
           {"636949","بانک حکمت ایرانیان"},
           {"639194","بانک پارسیان"},
           {"639217","بانک کشاورزی"},
           {"639346","بانک سینا"},
           {"639347","بانک پاسارگاد"},
           {"639370","بانک مهر اقتصاد"},
           {"639599","بانک قوامین"},
           {"639607","بانک سرمایه"},
           {"991975","بانک ملت"}
        };

        public static Dictionary<string, VoucherOperator> MobilePrefixNo
        {
            get => _mobilePrefixNo;
            set => _mobilePrefixNo = value;
        }

        private static Dictionary<string, VoucherOperator> _mobilePrefixNo = new Dictionary<string, VoucherOperator>()
        {
            {"0910", VoucherOperator.MCI},
            {"0911", VoucherOperator.MCI},
            {"0913", VoucherOperator.MCI},
            {"0914", VoucherOperator.MCI},
            {"0915", VoucherOperator.MCI},
            {"0916", VoucherOperator.MCI},
            {"0917", VoucherOperator.MCI},
            {"0918", VoucherOperator.MCI},
            {"0919", VoucherOperator.MCI},
            {"0990", VoucherOperator.MCI},
            {"0991", VoucherOperator.MCI},
            {"0992", VoucherOperator.MCI},

            {"0920", VoucherOperator.Ritel},
            {"0921", VoucherOperator.Ritel},
            {"0922", VoucherOperator.Ritel},

            {"0930", VoucherOperator.MTN},
            {"0933", VoucherOperator.MTN},
            {"0935", VoucherOperator.MTN},
            {"0936", VoucherOperator.MTN},
            {"0937", VoucherOperator.MTN},
            {"0938", VoucherOperator.MTN},
            {"0939", VoucherOperator.MTN},
            {"0901", VoucherOperator.MTN},
            {"0902", VoucherOperator.MTN},
            {"0903", VoucherOperator.MTN},
            {"0904", VoucherOperator.MTN},
            {"0905", VoucherOperator.MTN},
            {"0941", VoucherOperator.MTN},
        };
    }
}
