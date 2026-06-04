using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3test3
{
    class Account
    {
        string accName, acid;
        int balance;

        public Account(string accName, string acid, int balance)
        {
            this.accName = accName;
            this.acid = acid;
            this.balance = balance;
        }

        public void Deposit(int amount)
        {
            balance += amount;
        }
        public void Withdraw(int amount)
        {
            if(amount<=balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient Balance!");
            }

        }

        public void ShowInfo()
        {
            Console.WriteLine("---- Account Info ----");
            Console.WriteLine($"Account Name: {accName}");
            Console.WriteLine($"Account ID: {acid}");
            Console.WriteLine($"Balance: {balance}");
            Console.WriteLine();
        }
    }
}
