using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
   public class OrderLine
    {       
        public int OrderLineID { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }

        [NotMapped]
        public decimal TotalPrice
        {
            get { return Convert.ToDecimal(Amount * Product.PriceForUnit); }                
        }

        public OrderLine() { }

    }
}
