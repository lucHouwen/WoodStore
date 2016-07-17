using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseCommunicator.Classes
{
   public class Address
    {
        [Key]
        public int AddressID { get; set; }

        public string Street { get; set; }

        public int HouseNr { get; set; }

        public string Box { get; set; }

        public City City { get; set; }

        public Address()
        {
            City = new City();
        }

        public Address(string street, int houseNr, string box, City city)
        {
            Street = street;
            HouseNr = houseNr;
            Box = box;
            City = city;
        }
    }
}
