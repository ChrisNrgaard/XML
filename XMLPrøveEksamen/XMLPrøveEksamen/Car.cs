using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLPrøveEksamen
{
    public class Car
    {
        public string Name { get; set; }
        public string Cylinders { get; set; }
        public string Country { get; set; }

        public Car() { 
        }

        public Car(string name, string cylinders, string country)
        {
            Name = name;
            Cylinders = cylinders;
            Country = country;
        }

        public override string ToString()
        {
            return "[Car: name=" + Name +
                ", cylinder=" + Cylinders +
                ", publisher=" + Country + "]";
        }
    }
}
