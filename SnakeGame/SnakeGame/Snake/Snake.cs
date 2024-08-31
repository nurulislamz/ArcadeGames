using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame;

namespace SnakeGame
{
    public static class Snakee
    {
        public static Queue<(int, int)> snake { get; private set; } = new Queue<(int, int)>();
        public static Direction? direction { get; set; } = null;


    }
}
