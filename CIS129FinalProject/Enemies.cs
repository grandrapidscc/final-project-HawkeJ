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

        public void Attack(Wizert wizert)
        {
            Screech = wizert.WizertHP - Screech;
        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("I think there's a Banshee nearby...");
        }
    }

    class Orc : Enemies
    {
        int OrcHP = 5;
        int Cleave = 3;

        public void Attack(Wizert wizert)
        {

        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("I think there's an Orc nearby...");
        }
    }

    class Goblin : Enemies
    {
        int GoblinHP = 3;
        int BodySlam = 2;

        public void Attack(Wizert wizert)
        {

        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("I think there's a Goblin nearby...");
        }
    }
}