using System.Collections.Generic;

namespace DatabaseCommunicator.Classes
{
    public class Parquet : Floor
    {
        public int ParquetID { get; set; }

        public Parquet(string name, Unit unit, decimal priceForUnit, Color color, string reference,
                       string type, double length, double width, double height,
                     double piecePerBox, short boxesPerPallet, decimal pricePerSquareMeter, List<FloorCovering> floorCoverings) : base(name, unit, priceForUnit,
                         color, reference, type, length, width, height, piecePerBox, boxesPerPallet,  pricePerSquareMeter, floorCoverings)
        { }

    }
}
