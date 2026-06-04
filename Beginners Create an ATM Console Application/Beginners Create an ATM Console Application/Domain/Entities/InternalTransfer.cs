using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginners_Create_an_ATM_Console_Application.Domain.Entities
{
   public class InternalTransfer
    {

        public decimal TransferAmount { get; set; }
        public long RecBankAccNum { get; set; }
        public string RecBankAccName { get; set; }

    }
}
