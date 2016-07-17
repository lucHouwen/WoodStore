using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
   public class FloorCovering : Product
    {
        public int FloorCoveringID { get; set; }

        public string Type { get; set; }

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Color Color { get; set; }

        public bool Standard { get; set; } // standaard plinten die altijd getoond moeten worden

        public FloorCovering()
        {

        }

        public FloorCovering(string name, Unit unit, decimal priceForUnit,string picture, string type, double length, double width, double height, Color color,bool standard) :base(name, unit, priceForUnit, picture)
        {
            Type = type;
            Length = length;
            Width = width;
            Height= height;
            Color = color;
            Standard =standard;
        }
    }
}
