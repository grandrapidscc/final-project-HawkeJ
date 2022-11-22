using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Remaster {

    public class Movement {
        
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string MovingToNorth { get; set; }
        public string MovingToEast { get; set; }
        public string MovingToSouth { get; set; }
        public string MovingToWest { get; set; }
    
        public Direction(string name,
            bool hesHere,
            string displayname,
            string description,
            string movingToNorth = "",
            string movingToEast = "",
            string movingToSouth = "",
            string movingToWest = "") {

            Name = name;
            DisplayName = displayname;
            Description = description;
            MovingToNorth = movingToNorth;
            MovingToEast = movingToEast;
            MovingToSouth = movingToSouth;
            MovingToWest = movingToWest;
            
        }

        public int[,] map = new int[5,5] {
            {1,2,3,4,5} ,
            {6,7,8,9,10} ,
            {11,12,13,14,15} ,
            {16,17,18,19,20} ,
            {21,22,23,24,25}
        };
    }
}
