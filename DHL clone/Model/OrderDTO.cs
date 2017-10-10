using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL_clone.Model
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Driver Driver { get; set; }
        public User User { get; set; }
    }
}
