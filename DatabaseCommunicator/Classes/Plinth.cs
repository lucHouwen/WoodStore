using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCommunicator.Classes
{
    [Table("Plinths")]
    public class Plinth : FloorCovering
    {
        public int PlinthID { get; set; }

        public Plinth(string name, Unit unit, decimal priceForUnit, string picture, string reference,string type, double length, double width, double height, Color color, bool standard) : base(name, unit, priceForUnit, picture, reference, type, length, width, height, color, standard)
        {

        }  
    }
}

    
      
    