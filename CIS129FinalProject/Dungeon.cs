using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizert_Throwback
{
    class Dungeon
    {
        private static Room[] roomNodes = new Room[GameConstants.WORLD_SIZE];
        private HashSet<int> doorRooms = new HashSet<int>();
        private HashSet<int> manaRooms = new HashSet<int>(); 
        private HashSet<int> healthRooms = new HashSet<int>();
        public int InitialWizertRoom { get; private set; }
        private Random random = new Random();

        public Dungeon()
        {

            for (int i = 0; i < GameConstants.WORLD_SIZE; i++)
            {
                roomNodes[i] = new Room(i);
            }

            BuildMap();
            GenerateDungeonDoor();
            ManaPotionPlacement();
            HealthPotionPlacement();
            InitialWizertRoom = GenerateWizertRoomNumber();
            SpawnItems();
        }


        public void ResetDungeon(bool resetRooms)
        {
            for (int i = 0; i < GameConstants.WORLD_SIZE; i++)
            {
                roomNodes[i].Item = GameConstants.NO_ITEMS;
            }

            if (resetRooms)
            {
                GenerateDungeonDoor();
                InitialWizertRoom = GenerateWizertRoomNumber();
            }

            SpawnItems();
        }

        private void SpawnItems()
        {
            ManaPotion manaPotion = new ManaPotion();
            HealthPotion healthPotion = new HealthPotion();
            DungeonDoor dungeonDoor = new DungeonDoor();

            foreach (int doorRoom in doorRooms)
            {
                roomNodes[doorRoom].Item = dungeonDoor;
            }

            foreach (int manaRoom in manaRooms)
            {
                roomNodes[manaRoom].Item = manaPotion;
            }

            foreach (int healthRoom in healthRooms)
            {
                roomNodes[healthRoom].Item = healthPotion;
            }
        }

        private void GenerateDungeonDoor()
        {
            doorRooms.Clear();
            doorRooms.Add(random.Next(0, 24));
        }

        private void ManaPotionPlacement()
        {
            manaRooms.Clear();
            manaRooms.Add(6);
            manaRooms.Add(8);
            manaRooms.Add(16);
            manaRooms.Add(18);
        }

        private void HealthPotionPlacement()
        {
            healthRooms.Clear();
            healthRooms.Add(0);
            healthRooms.Add(4);
            healthRooms.Add(12);
            healthRooms.Add(20);
            healthRooms.Add(24);
        }

        private int GenerateWizertRoomNumber()
        {
            int randomNumber = random.Next(0, 24);

            while (manaRooms.Contains(randomNumber) && healthRooms.Contains(randomNumber))
            {
                randomNumber = random.Next(0, 24);
            }

            return randomNumber;
        }

        private void BuildMap()
        {
            roomNodes[0].ConnectRoom(roomNodes[1]);
            roomNodes[0].ConnectRoom(roomNodes[5]);

            roomNodes[1].ConnectRoom(roomNodes[2]);
            roomNodes[1].ConnectRoom(roomNodes[6]);
            roomNodes[1].ConnectRoom(roomNodes[0]);

            roomNodes[2].ConnectRoom(roomNodes[3]);
            roomNodes[2].ConnectRoom(roomNodes[7]);
            roomNodes[2].ConnectRoom(roomNodes[1]);

            roomNodes[3].ConnectRoom(roomNodes[4]);
            roomNodes[3].ConnectRoom(roomNodes[8]);
            roomNodes[3].ConnectRoom(roomNodes[2]);

            roomNodes[4].ConnectRoom(roomNodes[9]);
            roomNodes[4].ConnectRoom(roomNodes[3]);
           
            roomNodes[5].ConnectRoom(roomNodes[0]);
            roomNodes[5].ConnectRoom(roomNodes[6]);
            roomNodes[5].ConnectRoom(roomNodes[10]);

            roomNodes[6].ConnectRoom(roomNodes[1]);
            roomNodes[6].ConnectRoom(roomNodes[7]);
            roomNodes[6].ConnectRoom(roomNodes[11]);
            roomNodes[6].ConnectRoom(roomNodes[5]);

            roomNodes[7].ConnectRoom(roomNodes[2]);
            roomNodes[7].ConnectRoom(roomNodes[8]);
            roomNodes[7].ConnectRoom(roomNodes[12]);
            roomNodes[7].ConnectRoom(roomNodes[6]);

            roomNodes[8].ConnectRoom(roomNodes[3]);
            roomNodes[8].ConnectRoom(roomNodes[9]);
            roomNodes[8].ConnectRoom(roomNodes[13]);
            roomNodes[8].ConnectRoom(roomNodes[7]);

            roomNodes[9].ConnectRoom(roomNodes[4]);
            roomNodes[9].ConnectRoom(roomNodes[14]);
            roomNodes[9].ConnectRoom(roomNodes[8]);

            roomNodes[10].ConnectRoom(roomNodes[5]);
            roomNodes[10].ConnectRoom(roomNodes[11]);
            roomNodes[10].ConnectRoom(roomNodes[15]);

            roomNodes[11].ConnectRoom(roomNodes[6]);
            roomNodes[11].ConnectRoom(roomNodes[12]);
            roomNodes[11].ConnectRoom(roomNodes[16]);
            roomNodes[11].ConnectRoom(roomNodes[10]);

            roomNodes[12].ConnectRoom(roomNodes[7]);
            roomNodes[12].ConnectRoom(roomNodes[13]);
            roomNodes[12].ConnectRoom(roomNodes[17]);
            roomNodes[12].ConnectRoom(roomNodes[11]);

            roomNodes[13].ConnectRoom(roomNodes[8]);
            roomNodes[13].ConnectRoom(roomNodes[14]);
            roomNodes[13].ConnectRoom(roomNodes[18]);
            roomNodes[13].ConnectRoom(roomNodes[12]);

            roomNodes[14].ConnectRoom(roomNodes[9]);
            roomNodes[14].ConnectRoom(roomNodes[19]);
            roomNodes[14].ConnectRoom(roomNodes[13]);

            roomNodes[15].ConnectRoom(roomNodes[10]);
            roomNodes[15].ConnectRoom(roomNodes[16]);
            roomNodes[15].ConnectRoom(roomNodes[20]);

            roomNodes[16].ConnectRoom(roomNodes[11]);
            roomNodes[16].ConnectRoom(roomNodes[17]);
            roomNodes[16].ConnectRoom(roomNodes[21]);
            roomNodes[16].ConnectRoom(roomNodes[15]);

            roomNodes[17].ConnectRoom(roomNodes[12]);
            roomNodes[17].ConnectRoom(roomNodes[18]);
            roomNodes[17].ConnectRoom(roomNodes[22]);
            roomNodes[17].ConnectRoom(roomNodes[16]);

            roomNodes[18].ConnectRoom(roomNodes[13]);
            roomNodes[18].ConnectRoom(roomNodes[19]);
            roomNodes[18].ConnectRoom(roomNodes[23]);
            roomNodes[18].ConnectRoom(roomNodes[17]);

            roomNodes[19].ConnectRoom(roomNodes[14]);
            roomNodes[19].ConnectRoom(roomNodes[24]);
            roomNodes[19].ConnectRoom(roomNodes[18]);

            roomNodes[20].ConnectRoom(roomNodes[15]);
            roomNodes[20].ConnectRoom(roomNodes[21]);

            roomNodes[21].ConnectRoom(roomNodes[16]);
            roomNodes[21].ConnectRoom(roomNodes[22]);
            roomNodes[21].ConnectRoom(roomNodes[20]);

            roomNodes[22].ConnectRoom(roomNodes[17]);
            roomNodes[22].ConnectRoom(roomNodes[23]);
            roomNodes[22].ConnectRoom(roomNodes[21]);

            roomNodes[23].ConnectRoom(roomNodes[18]);
            roomNodes[23].ConnectRoom(roomNodes[24]);
            roomNodes[23].ConnectRoom(roomNodes[22]);

            roomNodes[24].ConnectRoom(roomNodes[19]);
            roomNodes[24].ConnectRoom(roomNodes[23]);
        }

        public static Room GetRoomById(int id)
        {
            if (id < GameConstants.WORLD_SIZE)
                return roomNodes[id];
            else
                throw new IndexOutOfRangeException();
        }

        public static bool AreRoomsConnected(int roomID1, int roomID2)
        {
            return roomNodes[roomID1].IsInAdjList(roomID2);
        }
    }
}