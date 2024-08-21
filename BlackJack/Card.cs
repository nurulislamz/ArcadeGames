using System;
using System.Collections.Generic;
using System.Linq;
using
System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        CardNumber cardNumber { get; set; }
        CardSuits cardSuit { get; set; }

        public Card(CardSuits cardSuits, CardNumber cardNumber)
        {
            this.cardSuit = cardSuits;
            this.cardNumber = cardNumber;
        }

        public string PrintCards() { return $"{this.cardSuit}: {this.cardNumber}"; }

        public static int operator +(int a, Card b)
        {
            if (b.cardNumber == CardNumber.Ace)
            {
                int result1 = a + 11; int result2 = a + 1;

                if (result1 <= 21) return result1; else return result2;
            }

            return a + (int)b.cardNumber;
        }
    }
}
