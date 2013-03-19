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
            menu();
        }

        private static void menu() //.The menu system the is the main controller of the program
        {
            String [] games = new String[] {"Coin flip", "Guess a Number", "Black Jack"};
            CoinFlip coin = new CoinFlip();
            NumberGuess number = new NumberGuess();
            BlackJack bj = new BlackJack();
            string choice;

            do
            {
                Console.WriteLine("You have ${0}", Money.money.amount());
                Console.WriteLine("Which game would you like you like to play?");
                
                {
                    int i = games.Length - 1;
                    foreach (String item in games)
                        Console.WriteLine("{0}: {1}", games.Length - i--, item);
                }
                //for (int i = 0; i < games.Length; i++)
                //    Console.WriteLine("{0}: {1}", i + 1, games[i]);

                string g = Console.ReadLine();
                int game;
                int.TryParse(g, out game);

                switch (game)
                {
                    case 1:
                        coin.Start();
                        break;
                    case 2:
                        number.Start();
                        break;
                    case 3:
                        bj.Start();
                        break;
                    default:
                        choice = "no";
                        break;
                }

                //.This menu needs to be reworked for proper functionality.
                //.Right now it needs to be able to read only yes or no and present an error otherwise
                if (Money.money.canContinue() == true)
                {
                    Console.WriteLine("Would you like to continue?");
                    choice = Console.ReadLine();
                    choice.Trim();
                }
                else
                {
                    choice = "no";
                }


            } while (choice.EqualsIgnoreCase("yes"));
            newGame();
        }

        private static void exit() //.Exits the application
        {
            Environment.Exit(0);
        }

        private static void newGame() //.Start a new game and resets the money count
        {
            Console.WriteLine("Would you like to start a new game?");
            string d = Console.ReadLine();

            //.Will Reset the money if they wish to play a new game
            if (d.EqualsIgnoreCase("yes"))
            {
                Money.money.resetMoney();
                menu();
            }
            else if (d.EqualsIgnoreCase("no"))
                exit();
            else
            {
                Console.WriteLine("{0} is an invalid option", d);
                newGame();
            }
        
        }

    }
}