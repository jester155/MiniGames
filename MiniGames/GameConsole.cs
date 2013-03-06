/*
 * Created by Mark Provenzano
 * 03/04/2013-03/06/2013
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGames;
using Bank;

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
            menu();
        }

        private static void menu() //The menu system the is the main controller of the program
        {
            string choice;

            do
            {
                Console.WriteLine("You have ${0}", Money.getMoney());
                Console.WriteLine("Which game would you like you like to play?");
                Console.WriteLine("1: Coin Flip");
                Console.WriteLine("2: Guess a Number");
                string g = Console.ReadLine();
                int game = Core.Parse.canParse(g);

                switch (game)
                {
                    case 1:
                        CoinFlip.start();
                        break;
                    case 2:
                        NumberGuess.start();
                        break;
                    default:
                        choice = "no";
                        break;
                }

                bool c = Bank.Money.canContinue();

                if (c == true)
                {
                    Console.WriteLine("Would you like to continue?");
                    choice = Console.ReadLine();
                    choice.Trim();
                }
                else
                {
                    choice = "no";
                }


            } while (choice != "no");
            newGame();
        }

        private static void exit() //Exits the application
        {
            Environment.Exit(0);
        }

        private static void newGame() //Start a new game and resets the money count
        {
            Console.WriteLine("Would you like to start a new game?");
            string d = Console.ReadLine();

            if (d.Equals("yes"))
            {
                Money.resetMoney();
                menu();
            }
            else if (d.Equals("no"))
                exit();
            else
            {
                Console.WriteLine("{0} is an invalid option", d);
                newGame();
            }
        }

    }
}