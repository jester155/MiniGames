using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class MoneyHandler
    {
        private int money; //The users starting pool of money

        public MoneyHandler()
        {
            money = 100;
        }

        public void totalOut(int b, bool w) //Calculates the total after the user wins or loses
        {
            if (w == true)
            {
                money = money + b;
            }
            else
            {
                money = money - b;
            }
        }

        public void riskTotalOut(int b, bool w) //Calculates the total after the user wins or loses
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

        public bool canContinue() //Checks to see if the user has enough money to coninue playing
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

        public void resetMoney()
        {
            money = 100;
        }

        public int amount() //Use this to call the current amout of money the user has left
        {
            return money;
        }
    }
}