using SnakeGame;

namespace SnakeGame
{
    public class Controller
    {
        Direction direction;
        bool closeRequested;

        public Tuple<int, int> SetCursorToCenter()
        {
            (int X, int Y) = (GameSettings.width / 2, GameSettings.height / 2);
            return new Tuple<int, int>(X, Y);
        }

        public void GetDirection()
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
    }
}