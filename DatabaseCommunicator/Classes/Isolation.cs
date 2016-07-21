using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
   [Table("Isolations")]
   public class Isolation : Product
    {      
        [Key]
        public int IsolationID { get; set; }

        public string Type { get; set; }

        public double SquareMeterPerRol { get; set; }
        public double Decibel { get; set; }

        public Isolation() { }

        public Isolation(string name,Unit unit, decimal priceForUnit, string picture,string type,double squareMeterPerRol,double decibel) :base(name,unit,priceForUnit,picture)
        {
            Type = type;
            SquareMeterPerRol = squareMeterPerRol;
            Decibel = decibel;
        }
    }
}
