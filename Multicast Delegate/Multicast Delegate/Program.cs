using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multicast_Delegate
{
    public delegate void LongHandLer(string message);
    public class Logger
    {
        public void LogToConsole(string message)
        {
            Console.WriteLine("Console Log:" +message);
        }
        public void LogoTofile(string message)
        {
            Console.WriteLine("File log:" + message);
        }
       
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger lo = new Logger();
            //Creating a multicast delegate
            LongHandLer lh = lo.LogToConsole;
            lh += lo.LogoTofile;
            lh("Log this info!");
            lh -= lo.LogoTofile;
            lh("After Remove LogTOFile");

            Console.ReadKey();

        }
         

    }
}
