using System.Numerics;

namespace Battleship
{
    class Program
    {
        static void Main()
        {


            Console.WriteLine("Welcome to Battleship! \nPress 1 for SinglePlayer. \nPress 2 for TwoPlayer.");
            ConsoleKeyInfo input = Console.ReadKey();
            Console.WriteLine();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    SinglePlayer();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    TwoPlayer();
                    break;
            }


            void SinglePlayer()
            {
                string player1Name = "Player 1";
                BasePlayer player = new BasePlayer(player1Name);
                AI ai = new AI();
                Grid aiGrid = ai.GetGrid();
                Grid playerGrid = player.GetGrid();
                int shots = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Clank's Board ({shots} Fired):");
                    aiGrid.DisplayBoard(false);

                    Console.WriteLine("\nYour Board:");
                    playerGrid.DisplayBoard(false);
                    player.Attack(aiGrid, player1Name);

                    shots++;
                    if (aiGrid.CheckWin())
                    {
                        Console.WriteLine("You won in " + shots + " shots!");
                        break;
                    }
                    ai.AIAttack(playerGrid);
                    if (playerGrid.CheckWin())
                    {
                        Console.WriteLine("AI wins!");
                        break;
                    }
                }
            }

            void TwoPlayer()
            {
                string player1Name = "Player 1";
                string player2Name = "Player 2";
                BasePlayer player1 = new BasePlayer(player1Name);
                BasePlayer player2 = new BasePlayer(player2Name);
                Grid player1Grid = player1.GetGrid();
                Grid player2Grid = player2.GetGrid();
                int player1Shots = 0;
                int player2Shots = 0;

                while (true)
                {
                    bool player1Turn = true;
                    Console.Clear();
                    if (player1Turn) 
                    { 
                        Console.WriteLine($"Player 2's Board ({player2Shots} Fired):");
                        player2Grid.DisplayBoard(true);

                        Console.WriteLine($"\nPlayer 1's Board ({player1Shots} Fired):");
                        player1Grid.DisplayBoard(false);

                        player1.Attack(player2Grid, player1Name);
                        player1Shots++;
                        player1Turn = false;
                    }
                    if (player2Grid.CheckWin())
                    {
                        Console.WriteLine("Player 1 wins in " + player1Shots + " shots!");
                        break;
                    }
                    if (!player1Turn)
                    {
                        Console.WriteLine($"Player 2's Board ({player2Shots} Fired):");
                        player2Grid.DisplayBoard(false);

                        Console.WriteLine($"\nPlayer 1's Board ({player1Shots} Fired):");
                        player1Grid.DisplayBoard(true);

                        player2.Attack(player1Grid, player2Name);
                        player2Shots++;
                        player1Turn = true;
                    }
                    if (player1Grid.CheckWin())
                    {
                        Console.WriteLine("Player 2 wins in " + player2Shots + " shots!");
                        break;
                    }
                }
            }
        }
    }
}
