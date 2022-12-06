using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Throwback
{
    public enum ParseError { NotNumber, InvalidNumber, Correct, Failure}

    class Wizert
    {
        public int WizertHP = 100;
        public int WizertMP = 200;
        public int FireballHP = 5;
        public int FireballMP = 3;
        public int HealHP = 3;
        public int HealMP = 5;

        public Room CurrRoom { get; private set; }
        public static bool IsAlive { get; private set; }
        public static bool IsDead
        {
            get { return !IsAlive; }
            set
            {
                IsAlive = !value;
            }
        }

        public static bool HasWon { get; set; }
       
        public Wizert(int startingRoom)
        {
            CurrRoom = Dungeon.GetRoomById(startingRoom);
            IsAlive = true;
            HasWon = false;
        }

        public void Move()
        {
            string wizertInput;
            int roomNum = 0;

            do
            {
                Console.Write("Which room?: ");
                wizertInput = Console.ReadLine();
            } while (!IsInputValid(wizertInput, ref roomNum));
           
            Console.WriteLine();
            TravelTo(roomNum);
        }

        public void ListConnectedRooms()
        {
            CurrRoom.PrintConnectedRooms();
        }

        public void ListCurrentStats()
        {
            Console.WriteLine("HP: " + WizertHP + " MP: " + WizertMP);
        }

        private bool IsInputValid(string wizertInput, ref int roomNum)
        {
            if (Int32.TryParse(wizertInput, out roomNum) && CurrRoom.IsInAdjList(roomNum))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Not Possible");
                return false;
            }
        }

        public void TravelTo(int roomID)
        {
            CurrRoom = Dungeon.GetRoomById(roomID);
        }

        public void CheckForItems()
        {
            if (CurrRoom.HasItem())
            {
                CurrRoom.Item.UseItem(this);
            }
            else
            {
                CurrRoom.PrintAdjRoomMessage();
            }
        }

        public void CheckForEnemies()
        {
            if (CurrRoom.HasEnemy())
            {
                CurrRoom.Enemy.Attack(this);
            }
            else
            {
                CurrRoom.PrintAdjRoomMessage();
            }
        }

        private bool TryParse(string input, LinkedList<int> roomIDs)
        {
            char[] splitChars = { ' ' };
            string[] inputRooms = input.Split(splitChars);

            ParseError parseError = FindParseError(inputRooms, roomIDs);
            switch (parseError)
            {
                case ParseError.InvalidNumber:
                    Console.WriteLine("Room numbers must be between 0 and 24");
                    goto case ParseError.Failure;

                case ParseError.NotNumber:
                    Console.WriteLine("Input must be numbers");
                    goto case ParseError.Failure;

                default:
                    Console.WriteLine("Forgot to handle this error");
                    goto case ParseError.Failure;

                case ParseError.Failure:
                    roomIDs.Clear();
                    return false;

                case ParseError.Correct:
                    break;
            }

            CorrectInput(roomIDs);
            return true;
        }

        private ParseError FindParseError(string[] inputRooms, LinkedList<int> roomIDs)
        {
            ParseError result = ParseError.Correct;

            for (int i = 0; i < inputRooms.Length; i++)
            {
                int currentElement;

                if (Int32.TryParse(inputRooms[i], out currentElement))
                {
                    if (currentElement < 0 || currentElement >= GameConstants.WORLD_SIZE)
                    {
                        result = ParseError.InvalidNumber;
                        break;
                    }
                    else
                    {
                        Dungeon.GetRoomById(currentElement).isVisited = true;
                        roomIDs.AddLast(currentElement);
                    }

                }
                else
                {
                    result = ParseError.NotNumber;
                    break;
                }
            }

            if (result != ParseError.Correct)
            {
                foreach (int i in roomIDs)
                {
                    Dungeon.GetRoomById(i).isVisited = false;
                }
            }

            return result;
        }

        private void CorrectInput(LinkedList<int> roomIDs)
        {
            for (LinkedListNode<int> currentNode = roomIDs.First.Next; currentNode != null; currentNode = currentNode.Next)
            {
                int current = currentNode.Value;
                int previous = currentNode.Previous.Value;

                if (Dungeon.AreRoomsConnected(previous, current))
                {
                    continue;
                }
                else
                {
                    Dungeon.GetRoomById(currentNode.Value).isVisited = false;
                    currentNode.Value = Dungeon.GetRoomById(previous).GetUnvisitedNode();
                }
            }
        }

        public void Die()
        {
            IsAlive = false;
        }
    }
}