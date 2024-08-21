using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

    public class Deck
    {
        public List<Card> deck { get; set; }

        public Deck()
        {
            deck = new List<Card>();

            foreach (CardSuits suits in Enum.GetValues(typeof(CardSuits)))
            {
                foreach (CardNumber number in Enum.GetValues(typeof(CardNumber)))
                {
                    Card card = new Card(suits, number);
                    deck.Add(card);
                }
            }
        }

        public Card GetRandomCardFromDeck()
        {
            if (deck.Count == 0)
            {
                throw new Exception("Empty Deck");
            }

            Random random = new Random();

            Array suits = Enum.GetValues(typeof(CardSuits));
            CardSuits suit = (CardSuits)suits.GetValue(random.Next(suits.Length));

            Array numbers = Enum.GetValues(typeof(CardNumber));
            CardNumber number = (CardNumber)numbers.GetValue(random.Next(numbers.Length));

            Card card = new Card(suit, number);

            if (RemoveCardFromDeck(card)) return card;
            else
            {
                throw new Exception("Card already in deck, retrying");
            }
        }

        public bool RemoveCardFromDeck(Card card)
        {
            if (!deck.Contains(card))
            {
                deck.Remove(card);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
