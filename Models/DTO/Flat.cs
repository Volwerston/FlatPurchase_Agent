using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPurchase_Agent.Models.DTO
{
    public class Flat
    {
        public string Address { get; set; }
        public int Floor { get; set; }
        public double Area { get; set; }
        public double Price { get; set; }

        public Flat()
            :this("",-1,0.00,0.00)
        {
        }

        public Flat(string addr, int f, double area, double pr)
        {
            Address = addr;
            Floor = f;
            Area = area;
            Price = pr;
        }
    }
}
