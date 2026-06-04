using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionSlove3
{
   public class DateType
    {
        public int day, momth, year;

        public DateType(int d,int m,int y)
        {
            this.day = d;
            this.momth = m;
            this.year = y;

        }

        public override string ToString()
        {
            return day +"/" + momth +"/" + year;
        }

    }
}
