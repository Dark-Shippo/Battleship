namespace Battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            bool isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine("Welcome to BATTLESHIP! \nPress 1 to play singleplayer! \nPress 2 to play two player!");
                ConsoleKeyInfo menuInput = Console.ReadKey();
                switch (menuInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        isPlaying = false;
                        SinglePlayer();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:     
                        isPlaying = false;
                        TwoPlayer();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }

        static void SinglePlayer()
        {

        }

        static void TwoPlayer()
        {

        }
    }
}
