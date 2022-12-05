using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Throwback
{
    class Encounters
    {
        public static void Encounter(string Name, int WizertHP, int WizertMP)
        {
            string name = "";
            int hp = 0;
            int mp = 0;
            
            name = Name;
            hp = WizertHP;
            mp = WizertMP;
            
            

            while (hp > 0)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("| (F)ireball (H)eal |");
                Console.WriteLine("|       (R)un       |");
                Console.WriteLine("---------------------");
                Console.WriteLine("HP: " + hp + "MP: " + mp);
                string wizertInput = Console.ReadLine();


                switch (wizertInput.ToLower())
                {
                    case "f":
                        if (mp > 0)
                        {
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                        break;
                    case "h":
                        if (mp > 0)
                        {
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                        break;
                    case "r":
                        if (mp > 0)
                        {
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}