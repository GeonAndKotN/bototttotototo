using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bototttotototo.Game
{
    public class UserData : Location
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public int Equipment { get; set; }
        public int Money { get; set; }
        public int Exp { get; set; }
        public Location Location { get; set; }
        public int Level { get; set; } = 1;
        public int PowerPoint { get; set; } = 1;
        public int AgilityPoint { get; set; } = 1;
        public int ResistanePoint { get; set; } = 1;
    }
}
