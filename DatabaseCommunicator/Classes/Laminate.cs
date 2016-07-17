using System.Collections.Generic;

namespace DatabaseCommunicator.Classes
{
    public class Laminate : Floor
    {
        public int LaminateID { get; set; }    

        public Laminate(string name, Unit unit, decimal priceForUnit, Color color, string reference,
                        string type, double length, double width, double height,
                        double piecePerBox, short boxesPerPallet, decimal pricePerSquareMeter, List<FloorCovering> floorCoverings) : base(name, unit, priceForUnit, 
                         color,  reference, type, length, width, height,piecePerBox, boxesPerPallet, pricePerSquareMeter, floorCoverings)
        {           
        }

      
    }
}
