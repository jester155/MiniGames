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
using CoreObjects;

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
            CoinFlip coin = new CoinFlip();
            NumberGuess number = new NumberGuess();
            string choice;

            do
            {
                Console.WriteLine("You have ${0}", Money.money.amount());
                Console.WriteLine("Which game would you like you like to play?");
                Console.WriteLine("1: Coin Flip");
                Console.WriteLine("2: Guess a Number");
                string g = Console.ReadLine();
                int game = CoreObjects.Parse.canParse(g);

                switch (game)
                {
                    case 1:
                        coin.start();
                        break;
                    case 2:
                        number.start();
                        break;
                    default:
                        choice = "no";
                        break;
                }

                bool c = Money.money.canContinue();

                //This menu needs to be reworked for proper functionality.
                  //Right now it needs to be able to read only yes or no and present an error otherwise
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
            MoneyHandler money = new MoneyHandler();
            Console.WriteLine("Would you like to start a new game?");
            string d = Console.ReadLine();

            //Will Reset the money if they wish to play a new game
            if (d.Equals("yes"))
            {
                money.resetMoney();
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