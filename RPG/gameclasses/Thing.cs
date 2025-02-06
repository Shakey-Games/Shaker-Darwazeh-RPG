using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.gameclasses
{
    internal class Thing
    {
        public string name, description;
        public Thing(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
