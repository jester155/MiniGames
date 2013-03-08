using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Games
{
    public class NumberGuess //Games where a user guesses a number and matches that agains a random computer guess
    {
        private int bet; //Holds the bet information
        Random r = new Random(Environment.TickCount);
        Bet b = new Bet();
    
        public void start() //Signals the start of the program
        {
            Console.WriteLine("You will guess a number 1-5 if the number is correct you win");
            bet = b.placeBet();
            act();
        }

        private int compChoice() //Randomly generates the computers choice
        {
            int comp = r.Next(0, 5) + 1;
            return comp;
        }

        private int askUser() //Asks the user for their input
        {
            Console.WriteLine("What number do you choose?");
            string u = Console.ReadLine();
            int user;
            int.TryParse(u, out user); 
            

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

        private void act() //Performs aprpriate actions with the computer data and user input
        {
            int c = compChoice();
            int u = askUser();
            getResult(c, u);
        }

        private void getResult(int c, int u) //Finds the result of the game wether the user won or lost
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
            Money.money.riskTotalOut(bet, win);
            Console.WriteLine("You now have ${0}", Money.money.amount());
        }
    }
}
