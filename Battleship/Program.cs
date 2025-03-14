﻿namespace Battleship
{
    class Program
    {
        static void Main()
        {
            BasePlayer player = new BasePlayer();
            AI ai = new AI();
            Grid aiGrid = ai.GetGrid();
            Grid playerGrid = player.GetGrid();
            int shots = 0;

            Console.WriteLine("Welcome to Battleship! Press Enter to start.");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("AI's Board (Shots Fired):");
                aiGrid.DisplayBoard(false);

                Console.WriteLine("\nYour Board:");
                playerGrid.DisplayBoard(false);
                player.Attack(aiGrid);

                shots++;
                if (aiGrid.CheckWin())
                {
                    Console.WriteLine("You win in " + shots + " shots!");
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
    }
}
