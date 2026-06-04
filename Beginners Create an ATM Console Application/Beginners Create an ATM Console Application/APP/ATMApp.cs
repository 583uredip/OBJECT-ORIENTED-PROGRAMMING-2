using Beginners_Create_an_ATM_Console_Application.Domain.Entities;
using Beginners_Create_an_ATM_Console_Application.Domain.Enums;
using Beginners_Create_an_ATM_Console_Application.Domain.Interfaces;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beginners_Create_an_ATM_Console_Application
{
    public class ATMApp: IUserLogin,UserAccAction,ITrasaction
    {
        private List<UserAccount> userAccountsList;
        private UserAccount selectAcc;
        private List<Transaction> _listOfTransactions;
        private const decimal minimumKeptAmount = 500;
        private readonly UI.AppScreen screen;
        public ATMApp()
        {
            screen = new UI.AppScreen();
        }
        public void Run()
        {
            UI.AppScreen.Welcome();
            CheckUsrCardNumAndPass();
            UI.AppScreen.WelcomeCustomer(selectAcc.FullName);
            while(true)
            {
                UI.AppScreen.DisplayAppMenu();
                ProcessMenuoption();
            }
        }

        public void IniData()
        {
            userAccountsList = new List<UserAccount>
            {
                new UserAccount{Id=1,FullName="Rabati Kumar Biswas",AccNum=123456,CardNumber=1212,Cardpin=126126,AccBal=50000.00m,IsLocked=false},
                new UserAccount{Id=2,FullName="Basonti Rani Bhowmick",AccNum=654321,CardNumber=3131,Cardpin=123456,AccBal=60000.00m,IsLocked=false},
                new UserAccount{Id=3,FullName="Redip Biswas",AccNum=56561,CardNumber=1000,Cardpin=120000,AccBal=70000.00m,IsLocked=false},
                new UserAccount{Id=4,FullName="Rahul Biswas",AccNum=13212,CardNumber=2000,Cardpin=130000,AccBal=80000.00m,IsLocked=false},
            };

            _listOfTransactions = new List<Transaction>();
        }
        public void CheckUsrCardNumAndPass()
        {
            bool isCorrectLogin = false;
            while(isCorrectLogin==false)
            {
                UserAccount inputAcc = UI.AppScreen.UserLoginForm();
                Console.WriteLine("");
                UI.AppScreen.LoginProgress();
                foreach(UserAccount account in userAccountsList)
                {
                    selectAcc = account;
                    if(inputAcc.CardNumber.Equals(selectAcc.CardNumber))
                    {
                        selectAcc.TotalLogin++;
                        if(inputAcc.Cardpin.Equals(selectAcc.Cardpin))
                        {
                            selectAcc = account;
                            if(selectAcc.IsLocked || selectAcc.TotalLogin>3)
                            {
                                UI.AppScreen.PrintLookScreen();
                            }
                            else
                            {
                                selectAcc.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                    if (isCorrectLogin == false)
                    {
                        UI.Utility.PrintMsg("\n--!!!Invalid Card Number Or PIN!!--", false);
                        selectAcc.IsLocked = selectAcc.TotalLogin == 3;
                        if (selectAcc.IsLocked)
                        {
                            UI.AppScreen.PrintLookScreen();
                        }
                        
                    }
                    Console.Clear();
                }
            }
        }

         private void ProcessMenuoption()
        {
            switch (UI.Validator.Convert<int>("An Option:"))
            {
                case (int)Domain.Enums.AppMenu.CheckBalance:
                    ((UserAccAction)this).CheckBalance();
                    break;
                case (int)Domain.Enums.AppMenu.PlaceDeposit:
                    ((UserAccAction)this).PlaceDeposit();
                    break;
                case (int)Domain.Enums.AppMenu.MakeWithdrawal:
                    ((UserAccAction)this).MakeWithDrawal();
                    break;
                case (int)Domain.Enums.AppMenu.InternalTransfer:
                    var intarnalTra = screen.InternalTransferForm();
                    ProcessIntaTra(intarnalTra);
                    break;
                case (int)Domain.Enums.AppMenu.ViewTransaction:
                    ViewTransaction();


                    break;
                case (int)Domain.Enums.AppMenu.Logout:
                    UI.AppScreen.LogOutProgress();
                    UI.Utility.PrintMsg("You Have Successfully Logged Out.---Please Collect Your Atm card....");
                    Run();
                    break;
                default:
                    UI.Utility.PrintMsg("!!!Invalid Option!!!", false);
                    break;
            }
            Console.ReadKey();
        }

        void UserAccAction. CheckBalance()
        {
            UI.Utility.PrintMsg($"Your Account Balance Is:{UI.Utility.FormatAmount(selectAcc.AccBal)}");
        }

        void UserAccAction.PlaceDeposit()
        {
            Console.WriteLine("\nOnly Multiples Of 500 And 1000 Usd Allowed......\n");
            var transaction_amt = UI.Validator.Convert<int>($"amount{UI.AppScreen.cur}");
            Console.WriteLine("\nChecking And Cointing Bank Notes..");
            UI.Utility.PrintDot();
            Console.WriteLine(" ");
            if(transaction_amt<0)
            {
                UI.Utility.PrintMsg("Amount Needs To Be Greather Than Zero....Try Again.",false);
                return;
            }
            if(transaction_amt % 500 !=0)
            {
                UI.Utility.PrintMsg($"Enter Deposit Amount In Multiples Of 500 Or 100..!!Try Agin!!", false);
                return;
            }
            if(PreviewBankNotesCount(transaction_amt)==false)
            {
                UI.Utility.PrintMsg($"You Have Cancelled Your Action", false);
                return;
            }

            InsertTransaction(selectAcc.Id, TransactionType.Deposit, transaction_amt, "");

            selectAcc.AccBal += transaction_amt;
            UI.Utility.PrintMsg($"Your Deposit Of {UI.Utility.FormatAmount(transaction_amt)} Was Done..",true);
        }

        void UserAccAction.MakeWithDrawal()
        {
            var transaction_amt = 0;
            int selectedAmount = UI.AppScreen.SelectAmount();
            if(selectedAmount==-1)
            {
                selectedAmount = UI.AppScreen.SelectAmount();
                
            }
            else if(selectedAmount!=0)
            {
                transaction_amt = selectedAmount;
            }
            else
            {
                transaction_amt = UI.Validator.Convert<int>($"amount{UI.AppScreen.cur}");
            }

            if(transaction_amt<=0)
            {
                UI.Utility.PrintMsg("Amount needs to be greather than zero.--Try!! Again", false);
            }
            if(transaction_amt%5 !=0)
            {
                UI.Utility.PrintMsg("You Can Only Withdraw Amount In Multiples Of 500 Or 1000 Usd.!!Try Again!!", false);
                return;
            }
            
            if(transaction_amt > selectAcc.AccBal)
            {
                UI.Utility.PrintMsg($"Withdrawal Failed.. Your Balance Is Too Low To Withdraw {UI.Utility.FormatAmount(transaction_amt)}",false);
                return;
            }
            if((selectAcc.AccBal-transaction_amt)<minimumKeptAmount)
            {
                UI.Utility.PrintMsg($"Withdrawal Faild..Your Account needs to have" + $"minimum{UI.Utility.FormatAmount(minimumKeptAmount)}", false);
                return;
            }
            InsertTransaction(selectAcc.Id, TransactionType.Withdrawal, transaction_amt, "");
            selectAcc.AccBal -= transaction_amt;
            UI.Utility.PrintMsg($"##You Have Successfully Withdrawn" + $"{ UI.Utility.FormatAmount(transaction_amt)}.", true);

        }
        
        private bool PreviewBankNotesCount(int amount)
        {
            int thNotesCnt = amount / 1000;
            int fiveHunNotesCnt = (amount % 1000) / 500;
            Console.WriteLine($"{UI.AppScreen.cur}10000 X {thNotesCnt}={1000  *  thNotesCnt}");
            Console.WriteLine($"{UI.AppScreen.cur}500 X {fiveHunNotesCnt}={500 * fiveHunNotesCnt}");
            Console.WriteLine($"Total Amount: {UI.Utility.FormatAmount(amount)}\n\n");
            int opt = UI.Validator.Convert<int>("1 To Confirm");
            return opt.Equals(1);
        }

        public void InsertTransaction(long _UsrBackAccId, TransactionType _tranType, decimal _tranAmt, string _desc)
        {
            var transaction = new Transaction()
            {
                TransactionId = UI.Utility.GetTransactionId(),
                UserBankAccountId = _UsrBackAccId,
                TransactionDate = DateTime.Now,
                TransactionType = _tranType,
                TransactionAmount = _tranAmt,
                Descriprion=_desc
            };

            _listOfTransactions.Add(transaction);
        }

        public void ViewTransaction()
        {
            var filtraList = _listOfTransactions.Where(t => t.UserBankAccountId == selectAcc.Id).ToList();

            if (filtraList.Count <= 0)
            {
                UI.Utility.PrintMsg("*You have no transaction yet.**", true);
            }
            else
            {
                var table = new ConsoleTable("Id", "Transaction Date", "Type", "Descriptions", "Amount" + UI.AppScreen.cur);
                foreach (var tran in filtraList)
                {
                    table.AddRow(tran.TransactionId, tran.TransactionDate, tran.TransactionType, tran.Descriprion, tran.TransactionAmount);
                }
                table.Options.EnableCount = false;
                table.Write();
                UI.Utility.PrintMsg($"You have {filtraList.Count} transaction(s)", true);
            }
        }

        private void ProcessIntaTra(InternalTransfer intra)
        {
            if(intra.TransferAmount<=0)
            {
                UI.Utility.PrintMsg("Amount needs to be more than zero..**Try Again***", false);
                return;
            }

            if(intra.TransferAmount>selectAcc.AccBal)
            {
                UI.Utility.PrintMsg($"Transfer faild..You do not have enough balance" + $"to transfer {UI.Utility.FormatAmount(intra.TransferAmount)}");
                return;
            }
            if((selectAcc.AccBal-intra.TransferAmount)<minimumKeptAmount)
            {
                UI.Utility.PrintMsg($"Transfer faile.Your account needs to have minimum" + $"{UI.Utility.FormatAmount(minimumKeptAmount)}", false);
                return;
            }

            var selbankAccRec = (from usrAcc in userAccountsList where usrAcc.AccNum == intra.RecBankAccNum select usrAcc).FirstOrDefault();

            if(selbankAccRec==null)
            {
                UI.Utility.PrintMsg("-*-*-*Transfer faild.Recieber bank account number is invalid.*-*-*-", false);
                return;
            }

            if(selbankAccRec.FullName!=intra.RecBankAccName)
            {
                UI.Utility.PrintMsg("*/*/Transfer Faild. Recipient's back account name is does not match/*/*/*", false);
                return;
            }

            InsertTransaction(selectAcc.Id, TransactionType.Transfer, intra.TransferAmount, "Transferd" + $"to {selbankAccRec.AccNum}({selbankAccRec.FullName})");

            selectAcc.AccBal -= intra.TransferAmount;

            InsertTransaction(selbankAccRec.Id, TransactionType.Transfer, intra.TransferAmount, "Transfered  from" + $"{selectAcc.AccNum}({selectAcc.FullName})");

            selbankAccRec.AccBal += intra.TransferAmount;

            UI.Utility.PrintMsg($"You Have Successfully transfered" + $"{UI.Utility.FormatAmount(intra.TransferAmount)} to" + $"{intra.RecBankAccName}",true);
        }
    }
}
 