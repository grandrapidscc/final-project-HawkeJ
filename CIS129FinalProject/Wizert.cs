using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Remaster {
    public enum ParseError { NotNumber, InvalidNumber, Correct, Failure, ListTooLong, RepeatedNumber }
    
    class Wizert {
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
        
        public Player(int startingRoom)
        {
            CurrRoom = Dungeon.GetRoomById(startingRoom);
            IsAlive = true;
            HasWon = false;
        }

        
        public void ListConnectedRooms()
        {
            CurrRoom.PrintConnectedRooms();
        }

        public void Move()
        {
            string playerInput;
            int roomNum = 0;

            
            do
            {
                Console.Write("Where to?: ");
                playerInput = Console.ReadLine();

            } while (!IsInputValid(playerInput, ref roomNum));

            Console.WriteLine();
            TravelTo(roomNum);
        }

       
        private ParseError FindParseError(string[] inputRooms, LinkedList<int> roomIDs)
        {
            ParseError result = ParseError.Correct;

            if (inputRooms.Length > 25)
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

                    else if (World.GetRoomById(currentElement).isVisited)
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
                        World.GetRoomById(currentElement).isVisited = true;
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
                    World.GetRoomById(i).isVisited = false;
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

                if (World.AreRoomsConnected(previous, current))
                {
                    continue;
                }
                else
                {
                    World.GetRoomById(currentNode.Value).isVisited = false;
                    currentNode.Value = World.GetRoomById(previous).GetUnvisitedNode();//change current to one of previous's unvisited connections
                }
            }
        }

        public void Die()
        {
            IsAlive = false;
        }
    }
}