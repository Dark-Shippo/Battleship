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
                Console.WriteLine(
                    " _           _   _   _           _     _       \r\n| |         | | | | | |         | |   (_)      \r\n| |__   __ _| |_| |_| | ___  ___| |__  _ _ __  \r\n| '_ \\ / _` | __| __| |/ _ \\/ __| '_ \\| | '_ \\ \r\n| |_) | (_| | |_| |_| |  __/\\__ \\ | | | | |_) |\r\n|_.__/ \\__,_|\\__|\\__|_|\\___||___/_| |_|_| .__/ \r\n                                        | |    \r\n                                        |_|  \nPress 1 to play singleplayer! \nPress 2 to play two player!");
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
                        Console.WriteLine("Invalid Choice. Try again.");
                        break;
                }
            }
        }

        static void SinglePlayer()
        {
            int Player1Sunk = 0;
            int Player2Sunk = 0;

            bool player1Win = false;
            bool player2Win = false;

            Console.Clear();
            Console.WriteLine("Starting Two Player Mode!");

            Player player1 = new Player("Player 1", false);
            PlayerBoard player1Grid = new PlayerBoard();

            Console.WriteLine("\nPlayer 1, place your ships.");

            Player player2AI = new Player("Player 2", true);
            PlayerBoard player2Grid = new PlayerBoard();

        }

        static void TwoPlayer()
        {
            int Player1Sunk = 0;
            int Player2Sunk = 0;

            bool player1Win = false;
            bool player2Win = false;

            Console.Clear();
            Console.WriteLine("Starting Two Player Mode!");

            Player player1 = new Player("Player 1", false);
            PlayerBoard player1Grid = new PlayerBoard();
            Console.WriteLine("\nPlayer 1, place your ships.");

            Player player2 = new Player("Player 2", false);
            PlayerBoard player2Grid = new PlayerBoard();
            Console.WriteLine("\nPlayer 2, place your ships."); 
        }
    }
}
/*
The main class will handle the game flow:
i. Display the game board.
ii. Let each player take turns making guesses.
iii. Display messages when a player hits or misses a ship.
iv. Determine when the game ends (all ships are sunk).
*/
