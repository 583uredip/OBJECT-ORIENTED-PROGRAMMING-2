using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionAnswerpart_2_
{
   public class Batsman:Player
    {
        
        int total_run;
        int fifties;
        int hundreds;
        public Batsman(string id, string name, string country,int total_run,int fifties,int hundreds)
            :base(id,name,country)
        {
            this.total_run = total_run;
            this.fifties = fifties;
            this.hundreds = hundreds;
        }

        public override bool PlayerPerformance()
        {
            return total_run > 1000;
        }

        public override void ShowStatistics()
        {
            Console.WriteLine("Total Run:"+total_run);
            Console.WriteLine("Fifties:"+fifties);
            Console.WriteLine("Hundreds:"+hundreds);
        }

    }
}
