using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Menu
{
    public static class MenuBuilder
    {
        public static string MenuBuilderString(string[] listOfItems)
        {
            string line;
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            StringBuilder stringBuilder = new StringBuilder();

            Dictionary<int, string> listOfIndex = new Dictionary<int, string>();
            // Calculate the vertical line where the menu items would be written in
            for (int i = 0; i < listOfItems.Length; i++)
            {
                int index = (i + 2) * height / (listOfItems.Length * 2);
                listOfIndex[index] = listOfItems[i];
            }

            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    line = new string('#', width);
                }
                else if (listOfItems.Length == 1 && i == height / 2)
                {
                    string item = listOfItems[0];
                    int padding = (width - item.Length - 2) / 2; // Adjust padding for the item
                    line = "#" + new string(' ', padding) + item + new string(' ', width - padding - item.Length - 2) + "#";
                }
                else if (listOfIndex.ContainsKey(i))
                {
                    string item = listOfIndex[i];
                    int padding = (width - item.Length - 2) / 2; // Adjust padding for the item
                    line = "#" + new string(' ', padding) + item + new string(' ', width - padding - item.Length - 2) + "#";
                }
                else
                {
                    // Default line 
                    line = "#" + new string(' ', width - 2) + "#";
                }
                stringBuilder.AppendLine(line);
            }
            return stringBuilder.ToString();
        }
    }
}
