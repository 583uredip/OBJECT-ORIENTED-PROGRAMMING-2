using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginners_Create_an_ATM_Console_Application.APP
{
    class Entry
    {
        static void Main(string[] args)
        {
            while(true)
            {
                //UI.AppScreen.Welcome();
                //long Cardnum = UI.Validator.Convert<long>("Enter Your Card Number:");
                //Console.Write($"Your name is: {Cardnum} ");
                ATMApp aTMApp = new ATMApp();
                aTMApp.IniData();
                // aTMApp.CheckUsrCardNumAndPass();
                aTMApp.Run();
               
               // UI.Utility.PressEnterToContinue();
            }
        }
    }
}
