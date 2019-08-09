using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaymentStationApp
{
    public class AppBootstrap
    {
        public TransactionInfo tranInfo { get; set; }

        public AppBootstrap()
        {
            MainWindow mainWin = new MainWindow();
            
            mainWin.ShowDialog();
        }
            //tranInfo = new TransactionInfo() { CurrentPage = Pages.SelectOperationPage };

            ////if (!PCIEPP.connect())
            ////{
            ////    // MessageBox.Show("Can not connect to EPP Device!");
            ////    //new error form
            ////    //return;
            ////}



            //List<Creator> creators = new List<Creator>();

            //creators.Add(new CreatorSelectOperation());
            ////creators.Add(new CreatorFrmCardReader());
            ////creators.Add(new CreatorFrmPinPad());
            ////creators.Add(new CreatorInputPrice());


            //// Iterate over creators and create products

            ////while (true)
            ////{
            //UserControl currentPage = creators[(int)tranInfo.CurrentPage].FactoryMethod(tranInfo);
         
            //}

            //foreach (Creator creator in creators)
            //{
            //    BaseWin forms = creator.FactoryMethod();

            //    //BaseWin.GetType().Name
            //}

        

        //public 
    }
}
