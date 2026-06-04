using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionAnswerpart_2_
{
    class AllRounder : Player
    {
        int totalRuns;
        int total_Wickets;

        public AllRounder(string id, string name, string country, int totalRuns, int total_Wickets)
            : base(id, name, country)
        {
            this.totalRuns = totalRuns;
            this.total_Wickets = total_Wickets;
        }

        public override bool PlayerPerformance()
        {
            return totalRuns > 500 && total_Wickets > 20;
        }

        public override void ShowStatistics()
        {
            Console.WriteLine("Total Runs:"+totalRuns);
            Console.WriteLine("Total Wickets:"+total_Wickets);

        }
    }
}
