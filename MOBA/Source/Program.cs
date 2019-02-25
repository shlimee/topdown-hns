using System;

namespace MOBA
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Settings.LoadSettings("settings.xml");

            Console.WriteLine("Starting game..");
            using (var game = new Game1())
                game.Run();

            Settings.CloseSettings();
        }
    }
}
