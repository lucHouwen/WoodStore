using System;
using System.Collections.Generic;
using System.Linq;
namespace DatabaseCommunicator.Classes
{
    public class Vinyl : Floor
    {
        public int VinylID { get; set; }      

        public Vinyl(string name, Unit unit, decimal priceForUnit,string picture ,string reference,Color color,string type, double length,
                     double width, double height,double piecePerBox, short boxesPerPallet, decimal pricePerSquareMeter,
                     List<FloorCovering> floorCoverings)
                    : base(name, unit, priceForUnit,picture, reference, color, type, length, width, height, piecePerBox, boxesPerPallet,
                          pricePerSquareMeter, floorCoverings)
        { }


    }
}
