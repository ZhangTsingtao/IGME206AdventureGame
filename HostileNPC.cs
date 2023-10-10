using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TsingtaoAdventureGame
{
    public class HostileNPC : NPC
    {
        public HostileNPC() { }
        public HostileNPC(string a_sName, string a_sBackStory, int a_nLevel) : base(a_sName, a_nLevel)
        {
            m_sBackStory = a_sBackStory;
        }

        //polymorphism
        //override
        public override void Interact()
        {
            if (Player.Damage > m_nDefense)
            {
                int damage = Player.Damage - m_nDefense;
                m_nHP -= (Player.Damage - m_nDefense);
                Console.WriteLine("Enemy is hurt by " + damage + " points");
                Console.WriteLine("Its HP is " +  m_nHP);
            }
            else
            {
                Console.WriteLine("Enemy is too powerful, it's unharmed!");
                Console.WriteLine("Its HP is " + m_nHP);
            }

        }
        public override void Speak()
        {
            Console.WriteLine("");
            Console.WriteLine("I'm " + m_sName + " ,");
            Console.WriteLine(m_sBackStory);
        }
    }
}
