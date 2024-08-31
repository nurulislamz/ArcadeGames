using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game
{
    public class GameLoop
    {
     
        public GameLoop() 
        {
            Map board = new Map();
            Direction? direction = null;
            Queue<(int X, int Y)> snake = new();
            (int X, int Y) = (GameSettings.width / 2, GameSettings.height / 2);
            bool closeRequested = false;

            Console.CursorVisible = false;
            Console.Clear();
            snake.Enqueue((X, Y));
            // board.board[X, Y] = Tile.Snake;
            Console.SetCursorPosition(X, Y);
            Console.Write('@');


        }


    }
}
