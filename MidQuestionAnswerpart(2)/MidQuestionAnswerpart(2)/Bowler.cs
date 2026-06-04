using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionAnswerpart_2_
{
   public class Bowler:Player
    {
       
        int total_Wickets;
        int five_WicketHauls;
        double bowlingAverage;
        public Bowler(string id,string name,string country,int total_Wickets,int five_WicketHauls,double bowlingAverage)
            : base(id, name, country)
        {
            
            this.total_Wickets = total_Wickets;
            this.five_WicketHauls = five_WicketHauls;
            this.bowlingAverage = bowlingAverage;
        }

        public override bool PlayerPerformance()
        {
            return total_Wickets > 50;
        }

        public override void ShowStatistics()
        {
            Console.WriteLine("Total Wickets:"+total_Wickets);
            Console.WriteLine("five Wicket Hauls:"+five_WicketHauls);
            Console.WriteLine("Bowling Average:"+bowlingAverage);
        }
    }
}
