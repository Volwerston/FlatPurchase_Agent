using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPurchase_Agent.Models.DTO
{
    public class Agent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public Agent()
            : this("", "", "", -1)
        {
        }

        public Agent(string n, string s, string l, int id)
        {
            Name = n;
            Surname = s;
            LastName = l;
            Id = id;
        }
    }
}
