using Beginners_Create_an_ATM_Console_Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Beginners_Create_an_ATM_Console_Application.UI
{
    public  class AppScreen
    {
        internal const string cur = "USD";
        internal static void Welcome()
        {
            Console.Clear();
            Console.Title = "My ATM App";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n-------------Welcome To My ATM App---------------------\n\n");
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("Note: Real ATM reads and validates a physical card.");
            Utility.PressEnterToContinue();
        }

        internal static UserAccount UserLoginForm()
        {
            UserAccount temUsrAcc = new UserAccount();
            temUsrAcc.CardNumber = UI.Validator.Convert<long>("Your Card Number:");
            temUsrAcc.Cardpin = Convert.ToInt32(UI.Utility.GetSecretInput("Enter Your Card Pin:"));
            return temUsrAcc;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("Checking card number and PIN...");
            Utility.PrintDot();


        }

        internal static void PrintLookScreen()
        {
            Console.Clear();
            Utility.PrintMsg("!!!Your Account Is Locked!!! Pleas Go to the next Branch...To unclock Your Account",true);
            Utility.PressEnterToContinue();
            Environment.Exit(1);
        }
        internal static void WelcomeCustomer(string fullName)
        {
            Console.WriteLine($"***Welcome Back***,{fullName}");
            Utility.PressEnterToContinue();

        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("-----My ATM App Menu-------");
            Console.WriteLine(":                            :");
            Console.WriteLine("1. Account Balance           :");
            Console.WriteLine("2.  Cash Deposit             :");
            Console.WriteLine("3.   Withdrawal              :");
            Console.WriteLine("4. Transfer                  :");
            Console.WriteLine("5. Transactions              :");
            Console.WriteLine("6. Logout                    :");
            Console.ReadKey();
        }

        internal static void LogOutProgress()
        {
            Console.WriteLine("----Thank You For Using My ATM App----");
            Utility.PrintDot();
            Console.Clear();
        }

        internal static int SelectAmount()
        {
            Console.WriteLine("");
            Console.WriteLine(":1.{0}500       5.{0}10,000",cur);
            Console.WriteLine(":2.{0}1000      6.{0}15,000", cur);
            Console.WriteLine(":3.{0}2000       7.{0}20,000", cur);
            Console.WriteLine(":4.{0}5000       8.{0}40,000", cur);
            Console.WriteLine(":0.Other");
            int selectedAmount =Validator.Convert<int>("Option:");
            switch (selectedAmount)
            {
                case 1:
                    return 500;
                    break;
                case 2:
                    return 1000;
                    break;
                case 3:
                    return 2000;
                    break;
                case 4:
                    return 5000;
                    break;
                case 5:
                    return 10000;
                    break;
                case 6:
                    return 15000;
                    break;
                case 7:
                    return 20000;
                    break;
                case 8:
                    return 40000;
                    break;
                case 0:
                    return 0;
                    break;
                default:
                    Utility.PrintMsg("***Invalid Input. Try Again***", false);
                    SelectAmount();
                    return -1;
                    break;
                       
            }
        }

        internal InternalTransfer InternalTransferForm()
        {
            var intra = new InternalTransfer();
            intra.RecBankAccNum = Validator.Convert<long>("Recipient's account number:");
            intra.TransferAmount = Validator.Convert<decimal>($"amount{cur}");
            intra.RecBankAccName = UI.Utility.GetUserInput("recipients's name:");
            return intra;
        }

    }
}
