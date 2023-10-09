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

            Chamber rootChamber = GenerateMap();
            while (Player.CurretChamber != rootChamber)
            {
                Player.CurretChamber.Interact();

                if(Player.HP <= 0)
                {
                    Console.WriteLine("\n You can't proceed anymore, Game Over!");
                    return;
                }
            }

            if(Player.HP > 0)
            {
                Console.WriteLine("\n You've reached the door! " +
                "\n You saw the sunlight brushing on your face" +
                "\n You are free!");
                return;
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

            //add NPC to chamber
            c1.ChamberNPC = new HostileNPC("SantasSon", 
                "I'm son of Santa, oh no, it's Satan......\n" +
                "I'm here to make sure you never step out of this hell",
                5);
            c2.ChamberNPC = new FriendlyNPC("Ciderella",
                "I'm trapped in my glass shoes! I give you power of beauty, help me!", 5);

            //add Item
            c2.Item = new Item("Pearl of tears",
                "It glowed the light of a glass shoe",
                2);

            //return the destination, the end of the game
            return c7;
        }
    }
}