using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Menu;
 
namespace SnakeGame
{
    public class Map 
    {

        public Tile[,] board;

        public Map()
        {
            board = new Tile[GameSettings.width, GameSettings.height];
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    board[i, j] = Tile.Open;
                }
            }
        }

        public void PositionFood()
        {
            List<(int X, int Y)> openSpaces = new List<(int X, int Y)>();

            for (int i = 0; i < GameSettings.width; i++)
            {
                for (int j = 0; j < GameSettings.height; j++)
                {
                    if (board[i, j] == Tile.Open)
                    {
                        openSpaces.Add((i, j));
                    }
                }
            }

            if (openSpaces.Count > 0)
            {
                Random random = new Random();
                var (x, y) = openSpaces[random.Next(openSpaces.Count)];
                board[x, y] = Tile.Food;
                Console.SetCursorPosition(x, y);
                Console.Write('+');
            }
        }
    }
}