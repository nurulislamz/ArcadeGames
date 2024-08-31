using System.Reflection.Metadata.Ecma335;

namespace SnakeGame.Menu {
    public struct MenuItems
    {
        public static readonly string[] MainMenuItems = new string[] { "1. Play", "2: Settings", "3: Quit" };
        public static readonly string[] SpeedMenuItems = new string[] { "Choose Speed Setting: ", "1: Fast Speed", "2: Medium Speed (Default)", "3. Slow Speed" };
        public static string[] SpeedSettingConfirmationItems => new string[] { $"Speed Set to {GameSettings.velocity}" };
    }
}