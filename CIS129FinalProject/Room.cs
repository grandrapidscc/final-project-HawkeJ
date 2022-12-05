using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizert_Throwback
{
    class Room
    {
        public int Id { get; private set; }
        public Items Item { get; set; }
        public List<Room> AdjList { get; private set; }
        public bool isVisited { get; set; }

        public Room(int id)
        {
            Id = id;
            Item = GameConstants.NO_ITEMS;
            AdjList = new List<Room>(6);
            isVisited = false;
        }
        
        public void ConnectRoom(Room room)
        {
            AdjList.Add(room);
        }
        
        public bool IsInAdjList(int roomID)
        {
            for (int i = 0; i < AdjList.Count; i++)
            {
                if (roomID == AdjList[i].Id)
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool HasItem()
        {
            if (Item.IsBlank())
                return false;
            else
                return true;
        }

        public void PrintConnectedRooms()
        {
            for (int i = 0; i < AdjList.Count; i++)
            {
                Console.Write(AdjList[i].Id + " ");
            }
            Console.WriteLine();
        }

        public void PrintAdjRoomMessage()
        {
            for (int i = 0; i < AdjList.Count; i++)
            {
                if (AdjList[i].HasItem())
                {
                    AdjList[i].Item.PrintMessage();
                }
            }
        }

        public bool CheckAdjListItems()
        {
            for (int i = 0; i < AdjList.Count; i++)
            {
                if (AdjList[i].HasItem())
                {
                    return true;
                }

            }

            return false;
        }

       public int GetUnvisitedNode()
        {
            for (int i = 0; i < AdjList.Count; i++)
            {
                if (AdjList[i].isVisited)
                    continue;
                else
                {
                    AdjList[i].isVisited = true;
                    return AdjList[i].Id;
                }
            }

            return -1;
        }
    }
}