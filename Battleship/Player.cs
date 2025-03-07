namespace Battleship
{
    public class Player
    {
        Disctionary<string, Ship> playerFleet = new Dictionary<string, Ship>();
        public string Name { get; private set; }
        public bool isAI { get; private set; }

        public Player (string name, bool isAI)
        {
            Name = name;
            this.isAI = isAI;
        }
        static void TakeTurn()
        {

        }

        public void AddShip(Ship ship)                                                          
        {
            playerFleet.add(ship.name, ship);                      
        }
    }
}
/*
a. The Player class will represent each player in the game
b. It should have methods like:
i. TakeTurn(): Prompts the player for a coordinate to make a guess.
ii. AddShip(Ship ship): Adds a ship to the player’s fleet.
*/
