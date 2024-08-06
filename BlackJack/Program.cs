using System;

public enum CardNumber
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Fou = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Jack = 10,
    Queen = 10,
    King = 10
}

public enum CardSuits
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public class Card
{

    CardNumber cardNumber { get; set; }
    CardSuits cardSuit { get; set; }

    public Card(CardSuits cardSuits, CardNumber cardNumber)
    {
        this.cardSuit = cardSuits;
        this.cardNumber = cardNumber;
    }
    
    public string PrintCards()
    {
        return $"{this.cardSuit}: {this.cardNumber}";
    }

    public static int operator +(int a, Card b)
    {
        if (b.cardNumber == CardNumber.Ace)
        {
            int result1 = a + 11;
            int result2 = a + 1;

            if (result1 <= 21) return result1;
            else return result2;
        }
        
        return a + (int) b.cardNumber;
    }
}

public class Deck
{
    public List<Card> deck { get; set; }

    public Deck()
    {
        foreach (CardSuits suits in Enum.GetValues(typeof(CardSuits)))
        {
            foreach (CardNumber number in Enum.GetValues(typeof(CardNumber)))
            {
                deck.Add(new Card(suits, number));
            }
        }
    }

    public Card GetRandomCardFromDeck()
    {
        Random random = new Random();
        CardSuits suits = (CardSuits) random.Next(0, 3);
        CardNumber numbers = (CardNumber) random.Next(0, 11);

        Card card = new Card(suits, numbers);

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

    public class Player
    {
        string playerName {get; set;}
        List<Card> hand {get; set;}
        int total {get; set;} = 0;
        int score {get; set;} = 0;
        
        public Player(string PlayerName)
        {
            this.playerName = PlayerName;
        }
        
        public Card AddCardToHand(Card card)
        {
            hand.Add(card);
            return Card;
        }

        public CalculateHand(Card card)
        {
            total += card;
        }
    }

    public class Game
    {
        Player player{get; set;}
        Player computer{get; set;}
        
        public Game()
        {
            // Play Game
            Console.Write("Playing BlackJack");

            string playerName = "Player1";
            while (!string.TryParse(Console.Readline(), out string playerName))
            {
                Console.Write($"Player Name is {playerName}");
            }

        }

        public PlayerTurn()
        {
            
        }
        

        public ComputerTurn();

        
            Console.Write("Player1s Turn");
            
        
    }
}
