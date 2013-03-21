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

        public void Start() //.Beginning of the game
        {
            Bet b = new Bet();
            Console.WriteLine("Welcome to Black Jack.\nRemember in this, dealer always wins.");
            n[2] = b.placeBet();
            dealer();
            player();
            getResult(n[0], n[1]);
        }

        private void dealer() //.The logic behind the dealer and his score
        {
            int d = 0;
            int firstCard = r.Next(0, 11) + 1;
            if (firstCard == 11)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe dealer's first card is an ace");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe dealer's first card is {0}\n", firstCard);
                Console.ResetColor();
            }

            while (d < 16)
            {
                d += firstCard + r.Next(0, 11) + 1;
            }

            n[0] = d;
        }

        private void player() //.The logic behind the player and his score
        {
		    
            int p = 0;
		    String decision = "hit";
            String useAce;
            int aceCounter = 0;
            int ace = 0;
            int aceStringHolder = aceCounter;
		    while(p < 21 && decision.EqualsIgnoreCase("hit"))
            {
                
                int aceChance = r.Next(0, 11) + 1;
                if (aceChance == 11 || aceCounter > 0)
                {
                    aceCounter++;
                    aceChance = 0;
                    if (aceCounter > 0)
                    {
                        Console.WriteLine("You have drew an ace, you have {0}, would you like to use them? [yes / no]", aceCounter);
                        useAce = Console.ReadLine();
                        if (useAce.EqualsIgnoreCase("yes"))
                        {
                            for (int i = 0; i < aceCounter; i++)
                            {
                                int acex = 0;
                                Console.WriteLine("Ace number {0}: 1 or 11", aceStringHolder--);
                                String a = Console.ReadLine();
                                int.TryParse(a, out acex);
                                ace += acex;
                            }
                        }
                    }
                }

                    p += ace + aceChance;
			
			    Console.WriteLine("You have {0}", p);
			
			    if(p >= 21)
				    decision = "stay";
			    else 
                {
				    Console.WriteLine("Hit or stay?");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                        decision = Console.ReadLine();
                    Console.ResetColor();
			    }

		    }
            n[1] = p;
        }

        private void getResult(int d , int p) //.Finds the result of weather the user won or lost
        {
            bool win;

            if (p > d && p <= 21)
            {
                Console.WriteLine("you won!\nYou have: {0}\nDealer has: {1}", p, d);
                win = true;
            }
            else if (p > 21)
            {
                Console.WriteLine("You lost\nYou have: {0}\nDealer has: {1}", p,  d);
                win = false;
            }
            else if (p < d && d > 21)
            {
                Console.WriteLine("You won!\nYou have: {0}\nDealer has: {1}", p, d);
                win = true;
            }
            else
            {
                Console.WriteLine("You lost\nYou have: {0}\nDealer has: {1}", p, d);
                win = false;
            }
            Money.money.totalOut(n[2], win);
            Console.WriteLine("You now have ${0}", Money.money.amount());
	    }

    }
}
