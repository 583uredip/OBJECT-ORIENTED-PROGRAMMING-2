
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionAnswerpart_2_
{
    class Program
    {
        static void Main(string[] args)
        {

            Player[] players = new Player[3];

            players[0] = new Batsman("P-1", "Virat Kohli", "India", 12000, 60, 43);
            players[1] = new Bowler("P-2", "Mitchell Starc", "Australia", 300, 15, 20.5);
            players[2] = new AllRounder("P-3", "Ben Stokes", "England", 5000, 150);

            foreach (Player player in players)
            {
                if (player != null)
                {
                    player.ShowInfo();
                    Console.WriteLine();
                    
                }
            }
            Console.ReadKey();
        }
    }
}
