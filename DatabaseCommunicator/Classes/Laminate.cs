using System.Collections.Generic;

namespace DatabaseCommunicator.Classes
{
    public class Laminate : Floor
    {
        public int LaminateID { get; set; }    

        public Laminate(string name, Unit unit, decimal priceForUnit, string picture, string reference, Color color, string type, double length,
                     double width, double height, double piecePerBox, short boxesPerPallet, decimal pricePerSquareMeter,
                     List<FloorCovering> floorCoverings)
                    : base(name, unit, priceForUnit, picture, reference, color, type, length, width, height, piecePerBox, boxesPerPallet,
                          pricePerSquareMeter, floorCoverings)
        {           
        }

      
    }
}
