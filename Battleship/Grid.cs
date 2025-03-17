namespace Battleship
{
    class Grid
    {
        public char[,] Board;
        public List<Ship> Ships;
        private (int, int) BoardDimensions = (10, 10);
        public Grid()
        {
            Board = new char[BoardDimensions.Item1, BoardDimensions.Item2];
            Ships = new List<Ship>();
            for (int i = 0; i < BoardDimensions.Item1; i++)
            {
                for (int j = 0; j < BoardDimensions.Item2; j++)
                {
                    Board[i, j] = '~';
                }
            }
        }

        public void DisplayBoard(bool hideShips)
        {
            string startLetter = "0123456789";
            for (int i = 0; i < BoardDimensions.Item1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
                }
                for (int j = 0; j < BoardDimensions.Item2; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(startLetter[i] + " ");
                    }
                    char displayChar = Board[i, j];
                    if (hideShips && displayChar == 'S')
                    {
                        displayChar = '~';
                    }
                    Console.Write(displayChar + " ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public bool PlaceShip(Ship ship, int startX, int startY, string direction)
        {
            List<(int, int)> tempCoordinates = new List<(int, int)>();
            for (int i = 0; i < ship.Length; i++)
            {
                int x = startX;
                int y = startY;

                if (direction == "V")
                {
                    x += i;
                }
                if (direction == "H")
                {
                    y += i;
                }

                if (x >= 10 || y >= 10 || Board[x, y] != '~')
                {
                    return false;
                }
                tempCoordinates.Add((x, y));
            }
            foreach (var coord in tempCoordinates)
            {
                Board[coord.Item1, coord.Item2] = 'S';
            }
            ship.Coordinates.AddRange(tempCoordinates);
            Ships.Add(ship);
            return true;
        }

        public void PlaceShipAI(Ship ship, string direction)
        {
            List<(int, int)> tempCoordinates = new List<(int, int)>();
            bool isPlaced = false;
            Random rnd = new Random();
            int startX = rnd.Next(0, 10);
            int startY = rnd.Next(0, 10);


            while (direction == "H" && !IsWithinBoundary(startX, ship, 0))
            {
                startX = rnd.Next(0, 10);
            }

            while (direction == "V" && !IsWithinBoundary(startY, ship, 1))
            {
                startY = rnd.Next(0, 10);
            }

            while (!isPlaced)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    int x = startX;
                    int y = startY;
                    if (direction == "V")
                    {
                        y += i;
                    }
                    if (direction == "H")
                    {
                        x += i;
                    }
                    while (Board[x, y] != '~' ||
                            (direction == "H" && !IsWithinBoundary(startX, ship, 0)) ||
                            (direction == "V" && !IsWithinBoundary(startY, ship, 1)))
                    {
                        x = rnd.Next(0, 10);
                        y = rnd.Next(0, 10);
                        startX = x;
                        startY = y;
                        direction = "H";
                        if (rnd.Next(0, 2) == 0)
                        {
                            direction = "V";
                        }
                        if (Board[x, y] == '~' ||
                                (direction == "H" && IsWithinBoundary(startX, ship, 0)) ||
                                (direction == "V" && IsWithinBoundary(startY, ship, 1)))
                        {
                            i = -1;
                        }
                        continue;
                    }
                    tempCoordinates.Add((x, y));
                }
                foreach (var coord in tempCoordinates)
                {
                    Board[coord.Item1, coord.Item2] = 'S';
                    isPlaced = true;
                }
                ship.Coordinates.AddRange(tempCoordinates);
                Ships.Add(ship);
            }
        }

        public bool MakeGuess(int x, int y)
        {
            if (Board[x, y] == 'S')
            {
                Board[x, y] = 'X';
                foreach (var ship in Ships)
                {
                    if (ship.Coordinates.Contains((x, y)))
                    {
                        ship.Hits++;
                        return true;
                    }
                }
            }
            if (Board[x, y] == '~')
            {
                Board[x, y] = 'O';
            }
            return false;
        }

        public bool AIMakeGuess(int x, int y)
        {
            if (Board[x, y] == 'S')
            {
                Board[x, y] = 'X';
                
                foreach (var ship in Ships)
                {
                    if (ship.Coordinates.Contains((x, y)))
                    {
                        ship.Hits++;
                        return true;
                    }
                }
            }
            if (Board[x, y] == '~')
            {
                Board[x, y] = 'O';
            }
            return false;
        }

        public bool CheckWin()
        {
            foreach (var ship in Ships)
            {
                if (!ship.IsSunk()) return false;
            }
            return true;
        }

        private bool IsWithinBoundary(int XYValue, Ship ship, int i)
        {
            if ((XYValue + ship.Length < Board.GetLength(i)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

