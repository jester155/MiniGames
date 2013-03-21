/*
 * Created by Mark Provenzano
 * 03/04/2013-03/06/2013
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;
using Games;

namespace GameConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcom to MiniGames Gambling application");
            Console.WriteLine("by Mark Provenzano");
            Console.ResetColor();
            Menu.Start();
        }
    }
}