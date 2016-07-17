using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        public string Name { get; set; }

        public int Zipcode { get; set; }

        public Country Country { get; set; }

        public List<Address> Adresses { get; set; }

        public City() {}

        public City(string name, int zipcode, Country country)
        {
            Name = name;
            Zipcode = zipcode;
            Country = country;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
