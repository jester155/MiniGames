﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace MiniGames
{
    class CoinFlip //Game that flips a coin and askes the user to call heads or tails, best of three wins
    {
        private static int bet; //Holds the bet information

        public static void start() //Beginning of the game
        {
            Console.WriteLine("Flip a coin. Best of three and you win.");
            bet = BetSystem.placeBet(); //Gets the users bet and holds tehe information in bet
            flip();
        }

        private static void flip() //Perfors the action of 'flipping' the coin
        {
            int z = call(); //holds the user input of heads or tails
            int head = 0, tail = 0, coin;

            for (int i = 1; i <= 3; i++) //Perfors the coin flip 3 times
            {
                coin = Core.RandomGenerator.r.Next(0, 2); //Random generator can only choose between 0 or 1

                if (coin == 0) //Determines if the coin is heads or tails then tracks how many times heads or tails was chosen was chosen
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Tails");
                    Console.ResetColor();
                    tail++;
                }
                else if (coin == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Heads");
                    Console.ResetColor();
                    head++;
                }
            }
            getResult(tail, head, z);
        }

        private static int call() //Gets the user to call heads or tails
        {
            int x = 0;

            Console.WriteLine("Call heads or tails");
            String h = Console.ReadLine();

            if (h.Equals("heads"))
            {
                Console.WriteLine("You have chosen {0}!", h);
                x = 1;
            }
            else if (h.Equals("tails"))
            {
                Console.WriteLine("You have chosen {0}!", h);
                x = 2;
            }
            else
            {
                Console.WriteLine("{0} is not a valid entry", h);
                call();
            }
            return x;
        }

        private static void getResult(int t, int h, int f) //Finds the result of the game, wether the user won or lost
        {
            bool win;
            String w = "You Win!";
            String l = "You Lose...";

            if (t > 1 && f == 2)
            {
                Console.WriteLine(w);
                win = true;
            }
            else if (h >= 2 && f == 1)
            {
                Console.WriteLine(w);
                win = true;
            }
            else
            {
                Console.WriteLine(l);
                win = false;
            }
            Money.totalOut(bet, win);
            Console.WriteLine("You now have ${0}", Money.getMoney());
        }

    }

    class NumberGuess //Games where a user guesses a number and matches that agains a random computer guess
    {
        private static int bet; //Holds the bet information

        public static void start()
        {
            Console.WriteLine("You will guess a number 1-5 if the number is correct you win");
            bet = BetSystem.placeBet();
            act();
        }

        private static int compChoice() //Randomly generates the computers choice
        {
            int comp = Core.RandomGenerator.r.Next(0, 5) + 1;
            return comp;
        }

        private static int askUser() //Asks the user for their input
        {
            Console.WriteLine("What number do you choose?");
            string u = Console.ReadLine();
            int user = Core.Parse.canParse(u);

            if (user >= 1 && user <= 5)
            {
                return user;
            }
            else
            {
                Console.WriteLine("{0} is not a vailid option", user);
                askUser();
                return user;
            }
        }

        private static void act() //Performs aprpriate actions with the computer data and user input
        {
            int c = compChoice();
            int u = askUser();
            getResult(c, u);
        }

        private static void getResult(int c, int u) //Finds the result of the game wether the user won or lost
        {
            bool win;

            Console.WriteLine("The number was {0}, you guessed {1}", c, u);
            if (c == u)
            {
                Console.WriteLine("Wow, You Won!");
                win = true;
            }
            else
            {
                Console.WriteLine("You lost");
                win = false;
            }
            Money.riskTotalOut(bet, win);
            Console.WriteLine("You now have ${0}", Money.getMoney());
        }
    }
}