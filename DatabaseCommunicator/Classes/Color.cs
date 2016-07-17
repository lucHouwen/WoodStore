using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
   public class Color
    {
        [Key]
        public int ColorID { get; set; }
        public string Name { get; set; }

        public Color() { }

        public Color(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
