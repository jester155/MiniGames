using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Games
{
    public class BlackJack
    {
        private static Random r = new Random(Environment.TickCount);
        private int[] n = new int[3]; //.Holds dealer score [0], player score [1] and bet information [2]

        public void start()
        {
            Bet b = new Bet();
            Console.WriteLine("Welcome to Black Jack.\nRemember in this dealer always wins.");
            n[2] = b.placeBet();
            dealer();
            player();
            getResult(n[0], n[1]);
        }

        private void dealer()
        {
            int d = 0;

            while (d < 16)
            {
                d = d + r.Next(0, 11) + 1;
            }

            n[0] = d;
        }

        private void player()
        {
		    
            int p = 0;
		    String decision = "hit";
		
		    while(p < 21 && decision.Equals("hit")) {
			
			    p = p + r.Next(0, 11) + 1;
			
			    Console.WriteLine("You have " + p);
			
			    if(p > 21)
				    decision = "stay";
			    else 
                {
				    Console.WriteLine("Hit or stay?");
					    decision = Console.ReadLine();
			    }	
				
		    }
		    n[1] = p;
        }

        private void getResult(int p , int d) 
        {
            bool win;

            if (p > d && p <= 21)
            {
                Console.WriteLine("you won!\nYou had: " + p + "\nDealer had: " + d);
                win = true;
            }
            else if (p > 21)
            {
                Console.WriteLine("You lost\nYou had: " + p + "\nDealer had: " + d);
                win = false;
            }
            else
            {
                Console.WriteLine("You lost\nYou had: " + p + "\nDealer had: " + d);
                win = false;
            }
            Money.money.totalOut(n[2], win);
            Console.WriteLine("You now have ${0}", Money.money.amount());
	    }

    }
}
