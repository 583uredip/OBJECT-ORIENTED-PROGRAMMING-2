using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionAnswerpart_2_
{
   public class Player
    {
      public string id;
      public  string name;
      public string country;

        public Player(string id,string name,string country)
        {
            this.id = id;
            this.name = name;
            this.country = country;
        }

        public virtual bool PlayerPerformance()
        {
            return false;
        }
        public virtual void ShowStatistics()
        {

        }

        public void ShowInfo()
        {
            Console.WriteLine("Player type:"+id);
            Console.WriteLine("Player Name:"+name);
            Console.WriteLine("Player Country:"+country);
            ShowStatistics();
            if(PlayerPerformance())
            {
                Console.WriteLine("Eligible for Award");
            }
            else
            {
                Console.WriteLine("Not Eligible for Award");
            }
            Console.WriteLine("----------------------------");
        }

    }
}
