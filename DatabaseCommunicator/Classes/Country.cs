using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseCommunicator.Classes
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        public string Name { get; set; }

        public List<City> Cities { get; set; }


        public Country()  {}

        public Country(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
