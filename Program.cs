namespace TsingtaoAdventureGame
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            string nameInput = "";
            while (nameInput == "")
            {
                Console.WriteLine("Type in your name: ");
                nameInput = Console.ReadLine();
            }

            Console.WriteLine("Hello, " + nameInput);
            Player.Name = nameInput;


            //HostileNPC hostileNPC = new HostileNPC("monster", 1);

            //while (Player.HP > 0)
            //{
            //    Console.WriteLine("Do you want to interact with it?");

            //    if (GameManager.GetUserInput())
            //    {
            //        GameManager.Interact(hostileNPC);
            //    }
            //}

            //Generate map, and also returns the last chamber, 
            //if the player gets to the last chamber, the game ends

            Chamber rootChamber = GenerateMap();
            while (Player.CurretChamber != rootChamber)
            {
                Player.CurretChamber.Interact();
            }
        }

        public static Chamber GenerateMap()
        {
            //map initialization
            Chamber c0 = new Chamber();
            Chamber c1 = new Chamber();
            Chamber c2 = new Chamber();
            Chamber c3 = new Chamber();
            Chamber c4 = new Chamber();
            Chamber c5 = new Chamber();
            Chamber c6 = new Chamber();
            Chamber c7 = new Chamber();

            //chamber structure
            c0.Left = c1; c1.Previous = c0;
            c0.Right = c2; c2.Previous = c0;

            c1.Left = c3; c3.Previous = c1;
            c1.Right = c4;c4.Previous = c1;
            
            c2.Left = c5; c5.Previous = c2;

            c3.Left = c6; c6.Previous = c3;

            c5.Right = c7; c7.Previous = c5;

            //root chamber is c0
            Player.CurretChamber = c0;

            Console.WriteLine("");

            //Console.WriteLine("c7 Back to Origin");
            //c7.BackToOrigin();

            //add NPC to chamber
            c1.ChamberNPC = new HostileNPC();

            //return the destination, the end of the game
            return c7;
        }
    }
}