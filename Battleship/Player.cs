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

            if (!isAI)
            {
                PlaceFleetPlayer();
            }
            else
            {
                PlaceFleetAI();
            }
        }

        public void PlaceFleetPlayer()
        {
            List<string> placedShips = new List<string>(){};
            while (placedShips.Count < 5)
            {
                Console.WriteLine("Select a ship to place! \n1. Cruiser \n2. Submarine \n3. Destroyer \n4. Battleship \n5. Carrier");
                grid.DisplayBoard(false);
                ConsoleKeyInfo input = Console.ReadKey();

                string selectedShip = "";
                int shipLength = 0;

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        selectedShip = "Cruiser";
                        shipLength = 2;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        selectedShip = "Submarine";
                        shipLength = 3;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        selectedShip = "Destroyer";
                        shipLength = 3;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        selectedShip = "Battleship";
                        shipLength = 4;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        selectedShip = "Carrier";
                        shipLength = 5;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        continue;
                }
                if (!placedShips.Contains(selectedShip))
                {
                    Console.WriteLine("\nEnter your coordinates and direction (H/V) \n Example: 2 5 H");
                    string[]? inputs = Console.ReadLine()?.Split(' ');
                    if (inputs?.Length == 3 &&
                        int.TryParse(inputs[0], out int x) &&
                        int.TryParse(inputs[1], out int y) &&
                        (inputs[2].ToUpper() == "H" || inputs[2].ToUpper() == "V"))
                    {
                        string direction = inputs[2].ToUpper();
                        bool placed = grid.PlaceShip(new Ship(selectedShip, shipLength), x, y, direction);

                        if (placed)
                        {
                            Console.WriteLine("Ship placed successfully!");
                            placedShips.Add(selectedShip);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement! Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid format try again.");
                    }
                }
                else
                {
                    Console.WriteLine("\nYou already placed that ship. Pick a different ship.");
                }
            }
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
