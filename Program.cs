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
            //Player.LevelUp(84); testing

            Chamber destination = GenerateMap();
            while (Player.CurretChamber != destination)
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
            Chamber c8 = new Chamber();

            //chamber structure
            c0.Left = c1; c1.Previous = c0;
            c0.Right = c2; c2.Previous = c0;

            c1.Left = c3; c3.Previous = c1;
            c1.Right = c4;c4.Previous = c1;
            
            c2.Left = c5; c5.Previous = c2;

            c3.Left = c6; c6.Previous = c3;

            c5.Right = c7; c7.Previous = c5;

            c7.Left = c8; c8.Previous = c7;

            //root chamber is c0
            Player.CurretChamber = c0;

            Console.WriteLine("");

            //add NPC and Item to chamber

            c1.ChamberNPC = new FriendlyNPC("Ciderella",
                "I'm trapped in my glass shoes! I give you power of beauty!" +
                "Be careful for the path to the left!",
                5);
            c1.Item = new Item("Pearl of tears",
                "It glowed the light of a glass shoe",
                5);

            c2.ChamberNPC = new HostileNPC("SantasSon", 
                "I'm son of Santa, oh no, it's Satan......I'm here to make sure you never step out of this hell",
                90);

            c3.ChamberNPC = new HostileNPC("Mother of the Twins",
                "Ciderella ruined my grand plan of fortune and fame!" +
                "Since you recieved her blessing, you are my enemy!",
                15);
            c3.Item = new Item("Wooden Sword",
                "It scares the ghosts",
                5);

            c4.ChamberNPC = new HostileNPC("Evil Twins",
                "Ciderella stole our loved one, you will pay for her!",
                10);
            c4.Item = new Item("Pumpkin Carriage",
                "It crushes the evils",
                4);

            c5.ChamberNPC = new HostileNPC("Satans Grandson",
                "Never to think you'd beaten my old fool father, " +
                "but you shall not pass me! I'm stronger than him!",
                100);
            c5.Item = new Item("Santa's bell",
                "The true Santa brings the joy to the world, not terror.",
                50);

            c6.ChamberNPC = new FriendlyNPC("Magic Witch",
                "Bless Cinderella, You've just met her soul, now she will be free",
                40);

            c7.ChamberNPC = new HostileNPC("Santa",
                "Actually I am Santa, I imprison you so that I can drain your power." +
                "Then I am able to send gifts to all children" +
                "You can't go, or there will be no gift fot any child",
                330);

            //return the destination, the end of the game
            return c8;
        }
    }
}