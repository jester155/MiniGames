using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Money
    {
        private static int money = 100; //The users starting pool of money

        public static void totalOut(int b, bool w) //Calculates the total after the user wins or loses
        {
            if (w == true)
            {
                money = money + (b * 2);
            }
            else
            {
                money = money - b;
            }
        }

        public static void riskTotalOut(int b, bool w) //Calculates the total after the user wins or loses
        {
            if (w == true)
            {
                money = money + (b * 6);
            }
            else
            {
                money = money - b;
            }
        }

        public static bool canContinue() //Checks to see if the user has enough money to coninue playing
        {
            if (money > 0)
            {
                return true;
            }

            else
            {
                Console.WriteLine("You have no more money!");
                return false;
            }
        }

        public static void resetMoney()
        {
            money = 100;
        }

        public static int getMoney() //Use this to call the current amout of money the user has left
        {
            return money;
        }
    }

    class BetSystem
    {
        public static int placeBet() //Asks the user to place a bet
        {
            String bet;
            bool ok;
            int b;

            do
            {
                Console.WriteLine("How much would you like to bet?");
                bet = Console.ReadLine();

                b = Core.Parse.canParse(bet);

                ok = checkBet(b);
                if (ok == false)
                    Console.WriteLine("You cannot bet more than ${0}", Money.getMoney());
            } while (ok != true);
            return b;
        }

        private static bool checkBet(int x) //Checks the users bet against his current money
        {
            if (x > Money.getMoney())
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
