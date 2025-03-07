namespace Battleship
{
    class PlayerBoard
    {
        private char[,] board;
        private bool[,] shipLocations;
        private int gridSize = 10;
        private int shipsRemaining;

        public PlayerBoard()
        {
            board = new char[gridSize, gridSize];
            shipLocations = new bool[gridSize, gridSize];
            shipsRemaining = 0;
            InitializeBoard();
        }
        private void InitializeBoard()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    board[i, j] = '~'; // Empty space
                }
            }
        }
        public void DisplayBoard()
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
            for (int i = 0; i < gridSize; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void PlaceShip(int startX, int startY, int length, string direction)
        {
            bool isPlacing = true;
            while (isPlacing)
            {
                Console.WriteLine("Enter the x then y coordinate for your ");
                Console.ReadLine();
            }
        }
        public void MakeGuess(int x, int y)
        {

        }
        public void CheckWin()
        {

        }
    }
}
/*
Create a 10x10 grid for displays:
a. Use a Grid class to manage the board. The Grid class could have the following methods:
i. DisplayBoard(): Displays the current state of the board.
ii. PlaceShip(int startX, int startY, int length, string direction): Places a ship on the
grid. Ships can be placed either horizontally or vertically.
iii. MakeGuess(int x, int y): Checks if a guess hits a ship and updates the
board accordingly.
iv. CheckWin(): Checks if all ships of the opponent are sunk.
b. You’ll likely want four grids.
i. One for ships placed
ii. One for shots fired
iii. Times 2 for each player
*/

