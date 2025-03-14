namespace Battleship
{
    class AI
    {
        private Grid grid;
        private Random rand;
        List<(int, int)> AIGuesses = new List<(int, int)>();
        List<(int, int)> shipCoord = new List<(int, int)>();
        public bool shipHit;
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
            if (shipHit == false)
            {
                do
                {
                    x = rand.Next(10);
                    y = rand.Next(10);
                }
                while (enemyGrid.MakeGuess(x, y));
                AIGuesses.Add((x, y));
                shipHit = enemyGrid.MakeGuess(x, y);
                if (shipHit == true)
                {
                    shipCoord.Add((x, y));
                }
            }
            else
            {
                (x, y) = shipCoord[0];
                shipCoord.Remove((x, y));
                int random = rand.Next(0, 2);

                if (random == 0)
                {
                    int randomX = rand.Next(0, 2);
                    if (randomX == 0 && x < 9)
                    {
                        x = x + 1;
                    }
                    if (x > 0)
                    {
                        x = x - 1;
                    }
                }
                if (random == 1)
                {
                    int randomY = rand.Next(0, 2);
                    if (randomY == 0 && y < 9)
                    {
                        y = y + 1;
                    }
                    if (y > 0)
                    {
                        y = y - 1;
                    }
                }
            }
            return true;
        }

        public Grid GetGrid()
        {
            return grid;
        }


    }
}
