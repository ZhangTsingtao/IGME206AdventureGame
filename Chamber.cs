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
        public Item Item = null;

        public Chamber()
        {
            ID = ChamberCount;
            ChamberCount++;
            Console.WriteLine("ID: " + ID);
        }
        public Chamber (Item a_iItem)
        {
            this.Item = a_iItem;
        }

        public void Interact()
        {
            Console.WriteLine("--------- Chamber " + ID + " ---------");
            Console.WriteLine("You are in chamber " + ID);

            //envoke chamber event
            //return true means event is accomplished, player can go forward
            //return false means player is back to previous chamber
            bool passed = ChamberEvent();
            if (passed)
            {
                //After the event is ended, choose the path
                ChoosePath();
            }
            else 
            {
                Player.CurretChamber = GoBack();
            }
        }

        public bool ChamberEvent()
        {
            //A chamber with NPC
            if(ChamberNPC != null)
            {
                //Interact with Hostile NPC
                //If Hostile NPC is defeated, it will be destroyed
                if (ChamberNPC is HostileNPC)
                {
                    Console.WriteLine("There's a hostile NPC, you can't skip them");

                    ChamberNPC.Speak();
                    while (ChamberNPC != null && ChamberNPC.HP > 0 && Player.HP > 0)
                    {
                        if (GameManager.GetUserInput(" ---'1' Fight; '0' Go Back"))
                        {
                            //I should've written this in HostileNPC,
                            //but I don't have enough time, sorry
                            Console.WriteLine("--------- Fight! ---------");
                            GameManager.Fight(ChamberNPC as HostileNPC);

                            if (ChamberNPC.HP <= 0)//Victory
                            {
                                Console.WriteLine("Enemy is Defeated! You've won!");
                                Player.LevelUp(ChamberNPC.GiveXP());
                                ChamberNPC = null;
                            }

                            if(Player.HP <= 0)//dead
                            {
                                return false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You fled back to the last chamber");
                            //break;
                            return false;
                        }
                    }
                    
                }

                //Interact with Friendly NPC
                //If already interacted, it will vary in Interact() function
                else
                { 
                    Console.WriteLine("There's a vague figure");
                    ChamberNPC.Interact();
                }
            }

            //A chamber without NPC
            if(ChamberNPC == null)
            { 
                Console.WriteLine("No one's here");
            }

            if(Item != null)
            {
                Item.Interact();
                Item = null;
            }

            return true;
        }
        public void ChoosePath()
        {
            //After the event is ended, choose the path
            if (GameManager.GetUserInput(" ---Type '1' Go Forward, '0' Backward"))
            //forward
            {
                if (Left != null || Right != null)
                {
                    //go left
                    if (GameManager.GetUserInput(" --- Type '1' Go Left, '0' Right"))
                    {
                        if (Left != null)
                        {
                            Player.CurretChamber = GoLeft();
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("There's no way to the left");
                            Console.WriteLine("");
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
                            Console.WriteLine("");
                            Console.WriteLine("There's no way to the right");
                            Console.WriteLine("");
                            Interact();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("No way ahead, you can only go back");
                    Console.WriteLine("");
                }
            }
            else
            //backward
            {
                if (Previous != null)
                {
                    Player.CurretChamber = GoBack();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Can't go back anymore. This is the start");
                    Console.WriteLine("");
                    Interact();
                }
            }
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
