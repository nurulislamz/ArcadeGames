namespace SnakeGame
{
    public static class GameSettings
    {
        // Properties for getting console dimensions remain the same.
        public static int width => Console.WindowWidth;
        public static int height => Console.WindowHeight;

        // Readonly array for velocities, unchanged.
        private static readonly int[] velocities = { 100, 70, 50 };

        // Internal index for speed setting. Starts with a default value, e.g., 1 for medium speed.
        private static int speedSettingIndex { get; set; } = 2;  // Default to medium speed setting.

        // Public properties for velocity and sleep duration.
        public static int velocity { get; private set; } = velocities[speedSettingIndex];
        public static TimeSpan sleepDuration { get; private set; } = TimeSpan.FromMilliseconds(velocities[speedSettingIndex]);

        // Method to update the speed setting.
        public static void UpdateSpeedSetting(int newSpeedSetting)
        {
            if (newSpeedSetting >= 0 && newSpeedSetting < velocities.Length)
            {
                speedSettingIndex = newSpeedSetting;
                velocity = velocities[speedSettingIndex];
                sleepDuration = TimeSpan.FromMilliseconds(velocity);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(newSpeedSetting), "Speed setting must be within the range of available velocities.");
            }
        }
    }
}
