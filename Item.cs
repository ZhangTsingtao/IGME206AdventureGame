using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsingtaoAdventureGame
{
    public class Item
    {
        private string m_sName;
        public string Name { get { return m_sName; } }

        private int m_nLevel;
        private string m_sEffectArug;
        public Item (string a_sName, string a_sEffectArug, int a_nLevel)
        {
            m_sName = a_sName;
            m_sEffectArug = a_sEffectArug;
            m_nLevel = a_nLevel;
        }

        public void Interact()
        {
            Console.WriteLine("There's something in the dark");
            if (GameManager.GetUserInput(" ---'1' Check it out; '0' Avoid it"))
            {
                Console.WriteLine("It's " + m_sName + ", " + m_sEffectArug);
                Player.LevelUp(m_nLevel);
                Player.Heal(m_nLevel);
            }
            else
            {
                Console.WriteLine("You went past it");
            }
        }
    }
}
