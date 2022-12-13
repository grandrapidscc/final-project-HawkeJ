using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Throwback
{
    interface Enemies
    {
        void Attack(Wizert wizert);
        bool IsBlank();
        void PrintMessage();
    }

    class NoEnemies : Enemies
    {
        public void Attack(Wizert wizert)
        {

        }

        public bool IsBlank()
        {
            return true;
        }

        public void PrintMessage()
        {
           
        }
    }

    class Banshee : Enemies
    {
        int BansheeHP = 8;
        int Screech = 5;
        bool IsDead = false;

        public void Attack(Wizert wizert)
        {
            if(!IsDead)
            {
                Console.WriteLine("You've encountered a Banshee! Looks like it has " + BansheeHP + "hp left.");
                wizert.WizertHP = wizert.WizertHP - Screech;
                Console.WriteLine("The Banshee screeches at you, dealing " + Screech + " damage!");

                /*if (wizert.WizertHP = 0) 
                {
                    wizert.Die();
                }*/
            }
            else
            {
                Console.WriteLine("You gingerly step over the Banshee corpse...");
            }

        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("A cold shiver creeps up your spine as you sense a Banshee nearby...");
        }
    }

    class Orc : Enemies
    {
        int OrcHP = 5;
        int Cleave = 3;
        bool IsDead = false;

        public void Attack(Wizert wizert)
        {
            if (!IsDead)
            {
                Console.WriteLine("You've encountered an Orc! Looks like it has " + OrcHP + "hp left.");
                wizert.WizertHP = wizert.WizertHP - Cleave;
                Console.WriteLine("The Orc cleaves you, dealing " + Cleave + " damage!");

                /*if (wizert.WizertHP = 0) 
                {
                    wizert.Die();
                }*/
            }
            else
            {
                Console.WriteLine("You gingerly step over the Orc corpse...");
            }
        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("A bead of sweat rolls down your forehead as you sense an Orc nearby...");
        }
    }

    class Goblin : Enemies
    {
        int GoblinHP = 3;
        int BodySlam = 2;
        bool IsDead = false;

        public void Attack(Wizert wizert)
        {
            if (!IsDead)
            {
                Console.WriteLine("You've encountered a Goblin! Looks like it has " + GoblinHP + "hp left.");
                wizert.WizertHP = wizert.WizertHP - BodySlam;
                Console.WriteLine("The Goblin bodyslams you, dealing " + BodySlam + " damage!");

                /*if (wizert.WizertHP = 0) 
                {
                    wizert.Die();
                }*/
            }
            else
            {
                Console.WriteLine("You gingerly step over the Goblin corpse...");
            }
        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("Your nose flairs in disgust as you smell a Goblin nearby...");
        }
    }
}