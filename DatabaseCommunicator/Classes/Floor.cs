using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
    public class Floor : Product
    {
        public int FloorID { get; set; }

        public Color Color { get; set; }   

        public string ClickSystem { get; set; }

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double PiecePerBox { get; set; }
        public short BoxesPerPallet { get; set; }
        public decimal PricePerSquareMeter { get; set; }

        public List<FloorCovering> FloorCovering { get; set; }

        public Floor(string name , Unit unit,decimal priceForUnit, Color color, string picutre, 
                     string type, double length, double width, double height,
                     double piecePerBox, short boxesPerPallet, decimal pricePerSquareMeter, List<FloorCovering> floorCoverings) : base(name,unit,priceForUnit, picutre)
        {
            Color = color;
            ClickSystem = type;
            Length = length;
            Width = width;
            Height = height;
            PiecePerBox = piecePerBox;
            BoxesPerPallet = boxesPerPallet;
            PricePerSquareMeter = pricePerSquareMeter;    
        }
       

    }
}
