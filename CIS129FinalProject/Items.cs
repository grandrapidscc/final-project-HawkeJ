using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Throwback
{
    interface Items
    {
        void UseItem(Wizert wizert);
        bool IsBlank();
        void PrintMessage();
    }

    class NoItems : Items
    {
        public void UseItem(Wizert wizert)
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

    class HealthPotion : Items
    {
        int hpAdd = 10;

        public void UseItem(Wizert wizert)
        {
            Console.WriteLine("Nice! You found a health potion! You gain 10HP");
            
        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("I think there's a health potion nearby...");
        }
    }

    class ManaPotion : Items
    {
        int mpAdd = 20;

        public void UseItem(Wizert wizert)
        {
            Console.WriteLine("Nice! You found a mana potion! You gain 20MP");
        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("I think there's a mana potion nearby...");
        }
    }

    class DungeonDoor : Items
    {
        private Random roomGenerator = new Random();

        public void UseItem(Wizert wizert)
        {
            Console.WriteLine("There! The door!");
            Wizert.HasWon = true;
        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("You feel a nearby draft...");
        }
    }
}