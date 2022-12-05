using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Throwback
{
    public enum ParseError { ABAPattern, NotNumber, InvalidNumber, Correct, Failure, ListTooLong, RepeatedNumber }

    class Wizert
    {
        public int WizertHP = 100;
        public int WizertMP = 200;
        public int Fireball = 5;
        public int Heal = 3;


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
                Console.Write("Where to?: ");
                wizertInput = Console.ReadLine();
                /*Console.Write("Will you go (N)orth, (E)ast, (S)outh, or (W)est?");
                wizertInput = Console.ReadLine();

                switch (wizertInput.ToLower())
                {
                    case "n":
                        break;
                    case "e":
                        break;
                    case "s":
                        break;
                    case "w":
                        break;
                    default:
                        Console.WriteLine("Invalid command\n");
                        break;
                }
                Console.WriteLine();*/

            } while (!IsInputValid(wizertInput, ref roomNum));
           
            Console.WriteLine();
            TravelTo(roomNum);
        }

        public void ListConnectedRooms()
        {
            CurrRoom.PrintConnectedRooms();
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

        private bool TryParse(string input, LinkedList<int> roomIDs)
        {
            char[] splitChars = { ' ' };
            string[] inputRooms = input.Split(splitChars);

            ParseError parseError = FindParseError(inputRooms, roomIDs);
            switch (parseError)
            {
                case ParseError.ABAPattern:
                    Console.WriteLine("Arrows are not that crooked");
                    goto case ParseError.Failure;

                case ParseError.InvalidNumber:
                    Console.WriteLine("Room numbers must be between 0 and 19");
                    goto case ParseError.Failure;

                case ParseError.NotNumber:
                    Console.WriteLine("Input must be numbers");
                    goto case ParseError.Failure;

                case ParseError.ListTooLong:
                    Console.WriteLine("Arrow cannot fly to more than 5 rooms");
                    goto case ParseError.Failure;

                case ParseError.RepeatedNumber:
                    Console.WriteLine("Rooms cannot be repeated");
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

            if (inputRooms.Length > 5)
                return ParseError.ListTooLong;

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

                    else if (Dungeon.GetRoomById(currentElement).isVisited)
                    {
                        if (currentElement == roomIDs.Last())
                        {
                            result = ParseError.RepeatedNumber;
                        }
                        else
                        {
                            result = ParseError.ABAPattern;
                        }

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