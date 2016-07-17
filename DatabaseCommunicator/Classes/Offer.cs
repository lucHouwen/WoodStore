using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
   public class Offer
    {
        [Key]
        public int OfferID { get; set; }
        public Account Account { get; set; }
        public string Specifications { get; set; }
        public List<Product> Products { get; set; }

        public Offer()
        {
            Products = new List<Product>();
        }

        public override string ToString()
        {
            return OfferID.ToString();
        }
    }
}
