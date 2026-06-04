using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginners_Create_an_ATM_Console_Application.Domain.Entities
{
   public  class UserAccount
    {
        public int Id { get; set; }
        public long CardNumber { get; set; }
        public int Cardpin { get; set; }
        public  long AccNum { get; set; }
        public string FullName { get; set; }
        public decimal AccBal { get; set; }
        public  int TotalLogin  { get; set; }
        
        public bool IsLocked { get; set; }







    }
}
