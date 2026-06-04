using Beginners_Create_an_ATM_Console_Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginners_Create_an_ATM_Console_Application.Domain.Interfaces
{
   public interface ITrasaction
    {
        void InsertTransaction(long _UsrBackAccId, TransactionType _tranType, decimal _tranAmt, string _desc);
        void ViewTransaction();

    }
}
