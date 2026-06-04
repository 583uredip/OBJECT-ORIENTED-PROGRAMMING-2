using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginners_Create_an_ATM_Console_Application.Domain.Interfaces
{
   public interface UserAccAction
    {
        void CheckBalance();
        void PlaceDeposit();
        void MakeWithDrawal();
    }
}
