using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SnakeGame.Menu
{
    public static class Menus
    {
        public static void MainMenu()
        {
            string? consoleInput;
            int menuInput;

            do
            {
                RenderMenu(MenuItems.MainMenuItems);
                //Console.Write(menuStrings.menu);
                KeepScreenLocked();

            } while (!int.TryParse(consoleInput = Console.ReadLine(), out menuInput));

            // Menu Choices
            switch (menuInput)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    SpeedSettingMenu();
                    break;
                case 3:
                    QuitMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again!");
                    RedirectToMainMenu();
                    break;
            }
        }
        public static void SpeedSettingMenu()
        {
            string? settingInput;
            int speedSetting;

            RenderMenu(MenuItems.SpeedMenuItems);

            while (!int.TryParse(settingInput = Console.ReadLine(), out speedSetting) || speedSetting < 1 || speedSetting > 3)
            {
                if (string.IsNullOrEmpty(settingInput))
                {
                    settingInput = "2";
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Try again!");
                    SpeedSettingMenu();
                }
            }

            speedSetting = int.Parse(settingInput);
            GameSettings.UpdateSpeedSetting(speedSetting - 1);

            RenderTempMenu(MenuItems.SpeedSettingConfirmationItems);

            RedirectToMainMenu();
        }
        public static void QuitMenu() => Environment.Exit(0);
        public static void StartGame() => RenderTempMenu(new string[] { "Starting Game..." });
        public static void RenderMenu(string[] menuItems)
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            string menuString = MenuBuilder.MenuBuilderString(menuItems);
            Console.Write(menuString);
        }
        public static void RenderTempMenu(string[] list)
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            string menuString = MenuBuilder.MenuBuilderString(list);
            Console.Write(menuString);

            Thread.Sleep(3000);
        }
        public static void RedirectToMainMenu() => MainMenu();
        public static bool CheckIfMenuResize()
        {
            if (Console.WindowWidth != GameSettings.width || Console.WindowHeight != GameSettings.height)
            {
                Console.Clear();
                Console.Write("Console was resized. Snake game had ended");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void KeepScreenLocked()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
        }

    }
}