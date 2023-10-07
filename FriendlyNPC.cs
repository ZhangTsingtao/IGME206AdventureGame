using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsingtaoAdventureGame
{
    public class FriendlyNPC : NPC
    {
        
        private bool m_bGivenXP = false;
        public FriendlyNPC(string a_sName, string a_sBackStory, int a_nLevel) : base(a_sName, a_sBackStory, a_nLevel)
        {
            
        }

        public override void Interact()
        {
            base.Interact();

            Console.WriteLine("");
            Console.WriteLine("I'm " + m_sName +" ,");
            Console.WriteLine(m_sBackStory);

            if (!m_bGivenXP) 
            {
                Console.WriteLine("");
                Player.LevelUp(GiveXP());
                m_bGivenXP = true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("This NPC has already given you Strength");
            }
        }
    }
}
