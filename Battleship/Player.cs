namespace Battleship
{
    class BasePlayer
    {
        private Grid grid;
        private Random rand;

        public BasePlayer(bool isAI)
        {
            grid = new Grid();
            rand = new Random();
            PlaceShips();
        }

        public void PlaceShips()
        {
            bool placed = false;
            int x;
            int y;

            string direction = "H";
            if (rand.Next(0, 2) == 0)
            {
                direction = "V";
            }

            while (!placed)
            {
                Console.WriteLine("Please select your");
            }

            grid.PlaceShip(new Ship("Cruiser", 2), x, y, direction);
            grid.PlaceShip(new Ship("Submarine", 3), x, y, direction);
            grid.PlaceShip(new Ship("Destroyer", 3), x, y, direction);
            grid.PlaceShip(new Ship("Battleship", 4), x, y, direction);
            grid.PlaceShip(new Ship("Carrier", 5), x, y, direction);
        }

        public void PlaceShipsAI()
        {
            Random rand = new Random();
            int x = rand.Next(0, 10);
            int y = rand.Next(0, 10);

            string direction = "H";
            if (rand.Next(0, 2) == 0)
            {
                direction = "V";
            }

            grid.PlaceShip(new Ship("Cruiser", 2), x, y, direction);
            grid.PlaceShip(new Ship("Submarine", 3), x, y, direction);
            grid.PlaceShip(new Ship("Destroyer", 3), x, y, direction);
            grid.PlaceShip(new Ship("Battleship", 4), x, y, direction);
            grid.PlaceShip(new Ship("Carrier", 5), x, y, direction);
        }

        public bool Attack(Grid enemyGrid)
        {
            int x, y;
            do
            {
                x = rand.Next(10);
                y = rand.Next(10);
            }
            while (enemyGrid.MakeGuess(x, y));
            return true;
        }

        public Grid GetGrid()
        {
            return grid;
        }
    }
}
