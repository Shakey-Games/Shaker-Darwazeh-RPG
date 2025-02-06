using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.gameclasses
{
    internal class Room : Thing
    {
        public int north, south, west, east;

        public Room(string aName, string aDescription, int aNorth, int aSouth, int aWest, int aEast)
            : base(aName, aDescription)
        {
            north = aNorth;
            south = aSouth;
            west = aWest;
            east = aEast;
        }

    }
}
