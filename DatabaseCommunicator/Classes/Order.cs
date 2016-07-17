using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCommunicator.Classes
{
   public class Order
    {     
        [Key]
        public int OrderID { get; set; }

        [Required]
        public Account Account { get; set; }

        [Required]
        public DateTime Ordered { get; set; }

        public DateTime PickUp { get; set; }
        public DateTime Delivered { get; set; }

        public List<OrderLine> Orderlines { get; set; }

        public bool IsCancelled { get; set; }
        public decimal Discount { get; set; } // == % korting (decimal voor gemak om niet te moeten converteren

        [NotMapped]
        public decimal Totalprice
        {   // notmapped, de som van alle prijs van de orderlijn voor iedere orderlijn
            get
            {
                decimal price = 0;
                foreach (OrderLine orderline in Orderlines)
                {
                    price += orderline.TotalPrice;
                }
                return price;
            }
        }

        public Order() { }

        public Order(Account account , DateTime ordered)
        {
            Account = account;
            Ordered = ordered;
            Orderlines = new List<OrderLine>();
            IsCancelled = false;
        }

        public override string ToString()
        {
            return OrderID.ToString();
        }

    }
}
