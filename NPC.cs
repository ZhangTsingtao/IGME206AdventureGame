using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsingtaoAdventureGame
{
    //This is the base class, it has two subclasses:
    //HostileNPC and FriendlyNPC
    public class NPC 
    {
        protected string m_sName = "Unamed";
        protected int m_nLevel = 0;
        protected int m_nHP = 100;
        public int Damage = 0;
        protected int m_nDefense = 0;
        protected string m_sBackStory;

        public NPC() { }
        public NPC(string a_sName)
        {
            m_sName = a_sName;
            m_nLevel = 0;
            Init();
        }
        public NPC(string a_sName, int a_nLevel)
        {
            m_sName = a_sName;
            m_nLevel = a_nLevel;
            Init();
        }
        public NPC(string a_sName, string a_sBackStory, int a_nLevel)
        {
            m_sName = a_sName;
            m_nLevel = a_nLevel;
            m_sBackStory = a_sBackStory;
            Init();
        }

        public void Init() 
        {
            m_nHP = 100;
            Damage += m_nLevel;
            m_nDefense += m_nLevel;
            Print();
        }

        //polymorphism
        public virtual void Interact()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Interact with " + m_sName);
        }

        public int GiveXP() 
        {
            Console.WriteLine("");
            Console.WriteLine("NPC added you " + m_nLevel + " level");
            return m_nLevel; 
        }
        public void Print()
        {
            Console.WriteLine("");
            Console.WriteLine("----Initialization Start---- ");
            Console.WriteLine("Name: " + m_sName);
            Console.WriteLine("Level: " + m_nLevel);
            Console.WriteLine("Damage: " + Damage);
            Console.WriteLine("Defense: " + m_nDefense);
            Console.WriteLine("----Initialization End---- ");
            Console.WriteLine("");
        }
        public string Name { get { return m_sName; } }
        public int HP { get { return m_nHP; } set { m_nHP = value; } } 
    }
}
