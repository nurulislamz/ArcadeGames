﻿using System;

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

        return a + (int)b.cardNumber;
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
        if (deck.Count == 0)
        {
            throw new Exception("Empty Deck");
        }

        Random random = new Random();
        CardSuits suits = (CardSuits)random.Next(0, 3);
        CardNumber numbers = (CardNumber)random.Next(0, 11);

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
}

public class Player
{
    public string playerName { get; set; }
    public List<Card> hand { get; set; }
    public int total { get; set; } = 0;
    public int score { get; set; } = 0;

    public Player(string PlayerName)
    {
        this.playerName = PlayerName;
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
        foreach(Card card in hand)
        {
            Console.WriteLine("Card in your hands:");
            Console.WriteLine(card.PrintCards());
        }

    }
}

public class Game
{
    Player player1 { get; set; }
    Player player2 { get; set; }
    Deck deck { get; set; }

    int rounds {get; set;}

    public Game()
    {
        // Play Game
        Console.Write("Playing BlackJack");

        deck = new Deck();

        string player1Name = "Player1";
        while (!string.IsNullOrEmpty(Console.ReadLine()))
        {
            player1 = new Player(player1Name);
            Console.Write($"Player Name is {player1Name}");
        }

        string player2Name = "Player1";
        while (!string.IsNullOrEmpty(Console.ReadLine()))
        {
            player2 = new Player(player2Name);
            Console.Write($"Player Name is {player2Name}");
        }

        for (int i = 0; i < rounds; i++) 
        {
            Player winner = PlayGame();
            Console.WriteLine($"{winner.playerName} won.");
            Console.WriteLine($"{player1.playerName}: {player1.score}");
            Console.WriteLine($"{player2.playerName}: {player2.score}");
        }
    }

    public Player PlayGame()
    {
        while (true)
        {
            PlayRound(player1);
            PlayRound(player2);

            Player winner;
            
            if (IsDraw())
            {
                Console.WriteLine("Draw. Play again.");
            }
            else if (CheckIfTotalIs17OrMore())
            {
                Console.WriteLine("Card total is less than 17. Draw again.");
            }
            else if ((winner = CheckGameWin()) != null)
            {
                return winner;
            }
            else
            {
                throw new Exception("WTF happened?");
            }
        }
    }

    public void PlayRound(Player player)
    {
        // Draw or Stay
        Console.Write($"{player.playerName}: Draw [D] or Stay [S]");        
        
        string input;
        while ((input = Console.ReadLine()) != "d" && input != "s")
        {
            Console.WriteLine("Incorrect input"); 
        }

        switch (input)
        {
            case "s":
                Console.WriteLine("Stand. Did not draw.");
                break;
            case "d": 
                Console.WriteLine("Draw Card from Deck.");
                Card pickUp = deck.GetRandomCardFromDeck();
                Console.WriteLine($"You picked this card: {pickUp.PrintCards()}");
                player.AddCardToHand(pickUp);
                Console.WriteLine($"Your total so far: {player.total}");
                break;
            default:
                Console.Write("Incorrect input, try again");
                break;
        }
    }

    public bool IsDraw()
    {
        if (player1.score == 21 && player2.score == 21) return true;
        else return false;
    }

    public bool CheckIfTotalIs17OrMore()
    {
        if (player1.total < 17 || player2.total < 17) return true;
        else return false;
    }
    public Player CheckGameWin()
    {
        if (player1.total == 21)
        {
            Console.WriteLine($"{player1.playerName}: BLACKJACK! Scored 21.");
            return player1;
        }

        if (player2.total == 21)
        {
            Console.WriteLine($"{player2.playerName}: BLACKJACK! Scored 21.");
            return player2;
        }

        if (player1.total > 21) return player2;
        if (player2.total > 21) return player1;

        if (player1.total - 21 < player2.total - 21) return player1;
        else if (player2.total - 21 < player1.total - 21) return player2;
        else throw new Exception("Something went wrong in CheckGameWin");
    }
}


public class Program
{
    public void Main()
    {
        Game game = new Game(); 
    }
}
