using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPurchase_Agent.Models.DTO
{
    public class Organisation
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public int LicenseId { get; set; }

        public Organisation()
            : this("", -1, "", -1)
        {
        }

        public Organisation(string t, int id, string addr, int li)
        {
            Title = t;
            Id = id;
            Address = addr;
            LicenseId = li;
        }
    }
}
