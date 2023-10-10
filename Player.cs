using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsingtaoAdventureGame
{
    public static class Player
    {
        private static string m_sName = "Unamed";
        private static int m_nLevel = 0;
        private static int m_nHP = 100;
        public static int Damage = 15;
        private static int m_nDefense = 0;

        public static Chamber CurretChamber;

        public static string Name { get { return m_sName; } set { m_sName = value; } }
        public static int HP { get { return m_nHP; } set { m_nHP = value; } }

        public static void LevelUp(int a_nAddUp)
        {
            m_nLevel += a_nAddUp;
            Damage += a_nAddUp;
            m_nDefense += a_nAddUp;
            Console.WriteLine("You upgraded to Level " +  m_nLevel + "!");
        }
        public static void Heal(int a_nAddUp)
        {
            m_nHP += a_nAddUp * 2;
            Console.WriteLine("You are healed by " + a_nAddUp * 2 + "HP");
            Console.WriteLine("Your current HP is " + m_nHP + "!");
        }

        public static void Interact(FriendlyNPC a_fNPC)
        {
            Console.WriteLine("It's a friendly NPC");
        }
        public static void Interact(HostileNPC a_hEnemy) 
        {
            Console.WriteLine("");

            if (a_hEnemy.Damage > m_nDefense)
            {
                int damage = a_hEnemy.Damage - m_nDefense;
                m_nHP -= (a_hEnemy.Damage - m_nDefense);
                Console.WriteLine("You're damaged by " + damage);
                Console.WriteLine("Your HP is " +  m_nHP);
            }
            else
            {
                Console.WriteLine("Strong Defense! It couldn't hurt you!");
                Console.WriteLine("Your HP is " + m_nHP);
            }

            if (m_nHP <= 0)
            {
                Console.WriteLine("YOU DIED!");
                Console.WriteLine("You were killed by " + a_hEnemy.Name);
            }
        }
    }
}
