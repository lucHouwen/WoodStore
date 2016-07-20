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

        public string Reference { get; set; }

        public Color Color { get; set; }   

        public string ClickSystem { get; set; }

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double PiecePerBox { get; set; }
        public short BoxesPerPallet { get; set; }
        public decimal PricePerSquareMeter { get; set; }

        public List<FloorCovering> FloorCoverings { get; set; }

        public Floor(string name , Unit unit,decimal priceForUnit,string picture ,string reference,Color color, 
                     string clicksystem, double length, double width, double height,double piecePerBox, short boxesPerPallet,
                     decimal pricePerSquareMeter, List<FloorCovering> floorCoverings)
            : base(name,unit,priceForUnit, picture)
        {
            Reference = reference;
            Color = color;
            ClickSystem = clicksystem;
            Length = length;
            Width = width;
            Height = height;
            PiecePerBox = piecePerBox;
            BoxesPerPallet = boxesPerPallet;
            PricePerSquareMeter = pricePerSquareMeter;
            FloorCoverings = floorCoverings;
        }
       

    }
}
