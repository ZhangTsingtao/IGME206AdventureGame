using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TsingtaoAdventureGame
{
    public class Chamber
    {
        public Chamber Previous;
        public Chamber Left;
        public Chamber Right;

        public static int ChamberCount = 0;
        public int ID;
        public NPC ChamberNPC;

        public Chamber()
        {
            ID = ChamberCount;
            ChamberCount++;
            Console.WriteLine("ID: " + ID);
        }

        public void Interact()
        {
            Console.WriteLine("---------Chamber---------");
            Console.WriteLine("You are in chamber " + ID);
            //envoke chamber event
            ChamberEvent();



            //After the event is ended, choose the path
            Console.WriteLine(" ---Type '1' Go Forward, '0' Backward");
            if (GameManager.GetUserInput(" ---Type '1' Go Forward, '0' Backward"))
            //forward
            {
                if(Left != null || Right != null)
                {
                    Console.WriteLine(" ---Type '1' Go Left, '0' Right");
                    //go left
                    if (GameManager.GetUserInput(" ---Type '1' Go Left, '0' Right"))
                    {
                        if(Left != null)
                        {
                            Player.CurretChamber = GoLeft();
                        }
                        else 
                        {
                            Console.WriteLine("There's no way to the left");
                            Interact();
                        }
                    }
                    //go right
                    else
                    {
                        if (Right != null)
                        {
                            Player.CurretChamber = GoRight();
                        }
                        else
                        {
                            Console.WriteLine("There's no way to the right");
                            Interact();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No way ahead");
                }
            }
            else
            //backward
            {
                if(Previous != null)
                {
                    Player.CurretChamber = GoBack();
                }
                else
                {
                    Console.WriteLine("Can't go back anymore. This is the start");
                    Interact();
                }
            }

        }

        public void Interact(HostileNPC a_hEnemy)
        {
            Console.WriteLine("Interaction Function with HostileNPC");

            if (GameManager.GetUserInput(""))
            {
                GameManager.Fight(a_hEnemy);
            }
        }
        public void ChamberEvent()
        {
            if(ChamberNPC != null)
            {
                if (ChamberNPC is HostileNPC)
                {
                    Console.WriteLine("There's a hostile NPC, you can't skip them");
                    Console.WriteLine(" ---'1' Fight; '0' Go Back");
                    
                    while(ChamberNPC.HP > 0 && Player.HP > 0)
                    {
                        Console.WriteLine(" ---'1' Fight; '0' Flee");
                        if (GameManager.GetUserInput(" ---'1' Fight; '0' Go Back"))
                        {
                            Console.WriteLine("---------Fight!---------");
                            GameManager.Fight(ChamberNPC as HostileNPC);

                            if (ChamberNPC.HP <= 0)//Victory
                            {
                                Console.WriteLine("Enemy is Defeated! You've won!");
                                ChamberNPC = null;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                { 
                    Console.WriteLine("There's a friendly NPC"); 
                }
            }
            else { Console.WriteLine("No one's here"); }
            
        }

        //reccursion
        public void BackToOrigin()
        {
            Console.WriteLine(ID);
            if (this.Previous != null)
            {
                this.Previous.BackToOrigin();
            }
            else
            {
                Console.WriteLine("Reached the root! From BackToOrigin");
            }
        }

        public Chamber GoBack()
        {
            if (Previous != null) { return Previous; }
            else 
            {
                Console.WriteLine("No previous chamber. This is the start");
                return this;
            }
        }
        public Chamber GoLeft()
        {
            if (Left != null) { return Left; }
            else 
            {
                Console.WriteLine("No left chamber. You're still in this chamber");
                return this;
            }
        }
        public Chamber GoRight()
        {
            if (Right != null) { return Right; }
            else
            {
                Console.WriteLine("No right chamber. You're still in this chamber");
                return this;
            }
        }

        
        
    }
}
