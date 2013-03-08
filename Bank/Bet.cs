using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Bet
    {
        MoneyHandler m = new MoneyHandler();
        public int placeBet() //Asks the user to place a bet
        {
            String bet;
            bool ok;
            int value;

            do
            {
                Console.WriteLine("How much would you like to bet?");
                bet = Console.ReadLine();

                //b = CoreObjects.Parse.canParse(bet);

                int.TryParse(bet, out value);

                ok = checkBet(value);
                if (ok == false)
                    Console.WriteLine("You cannot bet more than ${0}", m.amount());
            } while (ok != true);
            return value;
        }

        private bool checkBet(int x) //Checks the users bet against his current money
        {
            if (x > m.amount())
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
