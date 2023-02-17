using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPPattern.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }
        public string Color { get; set; }
        public string Transmission { get; set; }
        public int Year { get; set; }
        public override string ToString()
        {
            return $"{Model} - {Vendor} - {Year}";
        }
    }
}
