using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCommunicator.Classes
{
    [Table("Parquets")]
    public class Parquet : Floor
    {
        public int ParquetID { get; set; }

        public Parquet(string name, Unit unit, decimal priceForUnit, string picture, string reference, Color color, string type, double length,
                     double width, double height, double piecePerBox, short boxesPerPallet, decimal pricePerSquareMeter,
                     List<FloorCovering> floorCoverings)
                    : base(name, unit, priceForUnit, picture, reference, color, type, length, width, height, piecePerBox, boxesPerPallet,
                          pricePerSquareMeter, floorCoverings)
        { }

    }
}
