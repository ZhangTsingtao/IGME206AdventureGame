using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TsingtaoAdventureGame
{
    public static class GameManager
    {
        public static bool GetUserInput(string a_sPrompt)//return a true or false of user input
        {
            //Console.WriteLine("Yes, type '1'; No, type '0'.");

            string m_sNumInput = "";
            m_sNumInput = Console.ReadLine();

            while (!int.TryParse(m_sNumInput, out int number)
                || int.Parse(m_sNumInput) > 1)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.WriteLine(a_sPrompt);
                m_sNumInput = Console.ReadLine();
            }
            //Console.WriteLine("Valid input.");
            int m_nNumJudge = int.Parse(m_sNumInput);
            if (m_nNumJudge == 1) { return true; }
            else { return false; }
        }

        //polymorphism
        //overloading
        public static void Fight(HostileNPC a_hNPC) 
        {
            Console.WriteLine("");
            Console.WriteLine("----Round Start----");
            a_hNPC.Interact();
            Player.Interact(a_hNPC);
            Console.WriteLine("----Round Ended----");
            Console.WriteLine("");
        }
        public static void Interact(FriendlyNPC a_fNPC)
        {
            a_fNPC.Interact();
            Player.Interact(a_fNPC);
        }
    }
}
