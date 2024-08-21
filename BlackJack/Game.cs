using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {
        Player player1 { get; set; }
        Player player2 { get; set; }
        Deck deck { get; set; }

        int rounds { get; set; } = 3;

        public Game()
        {
            // Play Game
            Console.WriteLine("Playing BlackJack:");

            deck = new Deck();

            string? player1Name = null;
            while (string.IsNullOrEmpty(player1Name))
            {
                Console.WriteLine("Enter Player1Name: ");
                player1Name = Console.ReadLine();

                if (string.IsNullOrEmpty(player1Name))
                {
                    Console.WriteLine("Invalid Input");
                }
                player1 = new Player(player1Name);
            }
            Console.WriteLine($"Player1 Name: {player1Name}");

            string? player2Name = null;
            while (player2Name == null)
            {
                Console.WriteLine("Enter Player2Name: ");
                player2Name = Console.ReadLine();

                if (string.IsNullOrEmpty(player2Name))
                {
                    Console.WriteLine("Invalid Input");
                }
                player2 = new Player(player2Name);
            }
            Console.WriteLine($"Player2 Name: {player2Name}");

            for (int i = 0; i < rounds; i++)
            {
                Player winner = PlayGame();
                Console.WriteLine($"{winner.playerName} won.");
                winner.score += 1;
                player1.ResetHand();
                player2.ResetHand();

                Console.WriteLine($"{player1.playerName}: {player1.score}");
                Console.WriteLine($"{player2.playerName}: {player2.score}");
            }
        }

        public Player PlayGame()
        {
            while (true)
            {
                Console.WriteLine("Player1 Turn");
                PlayRound(player1);

                Console.WriteLine("Player2 Turn");
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
            Console.WriteLine($"{player.playerName}: Draw [D] or Stay [S]");

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
                    Console.WriteLine("Drawing Card from Deck.");
                    Card pickUp = deck.GetRandomCardFromDeck();

                    deck.RemoveCardFromDeck(pickUp);
                    Console.WriteLine($"You picked this card: {pickUp.PrintCards()}");

                    player.AddCardToHand(pickUp);
                    player.PrintHand();
                    Console.WriteLine($"Your total so far: {player.total}");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                default:
                    Console.Write("Incorrect input, try again");
                    Console.WriteLine($"{player.playerName}: Draw [D] or Stay [S]");
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


}
