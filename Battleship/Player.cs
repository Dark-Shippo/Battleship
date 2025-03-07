namespace Battleship
{
    public class Player
    {
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

        static void AddShip(Ships ship)                                                          
        {

        }
    }
}
/*
a. The Player class will represent each player in the game
b. It should have methods like:
i. TakeTurn(): Prompts the player for a coordinate to make a guess.
ii. AddShip(Ship ship): Adds a ship to the player’s fleet.
*/
