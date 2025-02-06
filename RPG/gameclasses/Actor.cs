using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.gameclasses
{
    // / The Actor class is a subclass of the Thing class.
    internal class Actor : Thing
    {
        public Room location;

        public Actor(string name, string description, Room location) : base(name, description)
        {
            this.location = location;
        }
    }
}
