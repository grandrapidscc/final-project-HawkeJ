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
            wizert.WizertHP = wizert.WizertHP + hpAdd;
            Console.WriteLine("You found a health potion! You gain " + hpAdd + "hp for a total of " + wizert.WizertHP + "hp!");
        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("Your heart beats loudly as you sense a health potion nearby...");
        }
    }

    class ManaPotion : Items
    {
        int mpAdd = 20;

        public void UseItem(Wizert wizert)
        {
            wizert.WizertMP = wizert.WizertMP + mpAdd;
            Console.WriteLine("You found a mana potion! You gain " + mpAdd + "mp for a total of " + wizert.WizertMP + "mp!");
        }

        public bool IsBlank()
        {
            return false;
        }

        public void PrintMessage()
        {
            Console.WriteLine("Your muscles ache as you sense a mana potion nearby...");
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
            Console.WriteLine("As you look around, you feel a nearby draft...");
        }
    }
}