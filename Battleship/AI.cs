namespace Battleship
{
    class AI
    {
        private Grid grid;
        private Random rand;
        List<(int, int)> AIGuesses = new List<(int, int)>();
        bool isHit = false;
        List<(int, int)> AIHits = new List<(int, int)>();
        public AI()
        {
            grid = new Grid();
            rand = new Random();
            PlaceFleetAI();
        }

        public void PlaceFleetAI()
        {
            Random random = new Random();

            string direction = "H";
            if (rand.Next(0, 2) == 0)
            {
                direction = "V";
            }

            grid.PlaceShipAI(new Ship("Cruiser", 2), direction);

            direction = "H";
            if (rand.Next(0, 2) == 0)
            {
                direction = "V";
            }

            grid.PlaceShipAI(new Ship("Submarine", 3), direction);

            direction = "H";
            if (rand.Next(0, 2) == 0)
            {
                direction = "V";
            }

            grid.PlaceShipAI(new Ship("Destroyer", 3), direction);

            direction = "H";
            if (rand.Next(0, 2) == 0)
            {
                direction = "V";
            }

            grid.PlaceShipAI(new Ship("Battleship", 4), direction);

            direction = "H";
            if (rand.Next(0, 2) == 0)
            {
                direction = "V";
            }

            grid.PlaceShipAI(new Ship("Carrier", 5), direction);

        }

        public bool AIAttack(Grid enemyGrid)
        {
            int x, y;

            x = rand.Next(10);
            y = rand.Next(10); 

            if (!AIGuesses.Contains((x, y))) 
            {
                while (enemyGrid.MakeGuess(x, y));
                AIGuesses.Add((x, y));
            }
            return true;
        }

        public Grid GetGrid()
        {
            return grid;
        }


    }
}
