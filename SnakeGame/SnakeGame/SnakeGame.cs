using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Menu;
using SnakeGame;
using SnakeGame.Snake;


namespace SnakeGame
{
    public class SnakeGame
    {
        public SnakeGame()
        {
            Menus.MainMenu();

            int velocity = GameSettings.velocity;
            TimeSpan sleep = GameSettings.sleepDuration;

            int width = GameSettings.width;
            int height = GameSettings.height;

            char[] DirectionChars = ['^', 'v', '<', '>',];

  //          Map map = new Map();
    //        var board = map.board;

            Tile[,] board = new Tile[width, height];
            Direction? direction = null;
            Queue<(int X, int Y)> snake = new();
            (int X, int Y) = (width / 2, height / 2);
            bool closeRequested = false;

                Console.CursorVisible = false;
                Console.Clear();
                snake.Enqueue((X, Y));
                board[X, Y] = Tile.Snake;
                PositionFood();
                Console.SetCursorPosition(X, Y);
                Console.Write('@');
                while (!direction.HasValue && !closeRequested)
                {
                    GetDirection();
                }
                while (!closeRequested)
                {
                    switch (direction)
                    {
                        case Direction.Up: Y--; break;
                        case Direction.Down: Y++; break;
                        case Direction.Left: X--; break;
                        case Direction.Right: X++; break;
                    }
                    if (X < 0 || X >= width ||
                        Y < 0 || Y >= height ||
                        board[X, Y] is Tile.Snake)
                    {
                        Console.Clear();
                        Console.Write("Game Over. Score: " + (snake.Count - 1) + ".");
                        return;
                    }
                    Console.SetCursorPosition(X, Y);
                    Console.Write(DirectionChars[(int)direction!]);
                    snake.Enqueue((X, Y));
                    if (board[X, Y] is Tile.Food)
                    {
                        PositionFood();
                    }
                    else
                    {
                        (int x, int y) = snake.Dequeue();
                        board[x, y] = Tile.Open;
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                    }
                    board[X, Y] = Tile.Snake;
                    if (Console.KeyAvailable)
                    {
                        GetDirection();
                    }
                    System.Threading.Thread.Sleep(sleep);
                }
            

            

            void GetDirection()
            // takes direction from arrow keys
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow: direction = Direction.Up; break;
                    case ConsoleKey.DownArrow: direction = Direction.Down; break;
                    case ConsoleKey.LeftArrow: direction = Direction.Left; break;
                    case ConsoleKey.RightArrow: direction = Direction.Right; break;
                    case ConsoleKey.Escape: closeRequested = true; break;
                }
            }

            void PositionFood()
            {
                List<(int X, int Y)> possibleCoordinates = new();
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (board[i, j] is Tile.Open)
                        {
                            possibleCoordinates.Add((i, j));
                        }
                    }
                }
                int index = Random.Shared.Next(possibleCoordinates.Count);
                (int X, int Y) = possibleCoordinates[index];
                board[X, Y] = Tile.Food;
                Console.SetCursorPosition(X, Y);
                Console.Write('+');
            }
        }
        

        enum Direction
        {
                Up = 0,
                Down = 1,
                Left = 2,
                Right = 3,
        }   

        enum Tile
        {
            Open = 0,
            Snake,
            Food,
        }
    }
}
