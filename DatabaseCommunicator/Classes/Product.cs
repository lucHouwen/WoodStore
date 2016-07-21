using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
   public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public string Name { get; set; }
        public Unit Unit { get; set; }
        public decimal PriceForUnit { get; set; }
        public string Picture { get; set; }
        public bool IsActive { get; set; }
        public List<Offer> Offers { get; set; }

        public Product() {  }

        public Product(string name ,Unit unit , decimal priceForUnit,string picture)
        {
            Name = name;
            Unit = unit;
            PriceForUnit = priceForUnit;
            Picture = picture;
            IsActive = true;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
