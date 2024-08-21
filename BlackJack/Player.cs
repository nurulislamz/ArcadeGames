using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player
    {
        public string playerName { get; set; }
        public List<Card> hand { get; set; }
        public int total { get; set; } = 0;
        public int score { get; set; } = 0;

        public Player(string PlayerName)
        {
            this.playerName = PlayerName;
            this.hand = new List<Card>();
        }

        public Card AddCardToHand(Card card)
        {
            hand.Add(card);
            UpdateTotal(card);
            return card;
        }

        public int UpdateTotal(Card card)
        {
            total += card;
            return total;
        }

        public void PrintHand()
        {
            Console.WriteLine($"Card in {playerName} hands:");
            foreach (Card card in hand)
            {
                Console.WriteLine(card.PrintCards());
            }
        }

        public void ResetHand()
        {
            hand = new List<Card>();
            total = 0;
        }

        public int IncrementScore() => score += 1;
    }
}
