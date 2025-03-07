namespace Battleship
{
    public class Ship
    {
        public string name;
        public List<Coordinate> positions;
        public bool isSunk;

        public Ship(string inputName, List<Coordinate> inputPositions)
        {
            name = inputName;
            positions = inputPositions;
            isSunk = false;
        }
    }
}

/*
a. The Ship class will represent a ship on the board.
b.It should have properties like:
i.Name: Name of the ship.
ii. Length: The length of the ship (e.g., 5 for an aircraft carrier).
iii. Coordinates: The list of coordinates that the ship occupies on the grid.
iv. IsSunk: A flag indicating whether the ship is sunk. 
*/
