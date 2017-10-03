using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL_clone.Model
{
    class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<string> Products { get; set; }
        public Driver Driver { get; set; }
        public User User { get; set; }

        public Order(int id, string description, DateTime date, List<string> products, Driver driver, User user)
        {
            Id = id;
            Description = description;
            Date = date;
            Products = products;
            Driver = driver;
            User = user;
        }
        public Order()
        { }
    }
}
