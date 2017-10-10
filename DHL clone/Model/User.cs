using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL_clone.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return Email + " " + Name + " " + Phone + " " + Address;
        }
    }
}
