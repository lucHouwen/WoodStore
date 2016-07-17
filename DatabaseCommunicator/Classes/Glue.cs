using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Classes
{
    public class Glue : Product
    {
        [Key]
        public int GlueID { get; set; }

        public string Type { get; set; }
        public double LiterPerBucket { get; set; }
        public bool IsFloorGlue { get; set; }

        public Glue() { }

        public Glue(string name,double literPerBucket)
        {
            Name = name;
            LiterPerBucket = literPerBucket;
        }

    }
}
