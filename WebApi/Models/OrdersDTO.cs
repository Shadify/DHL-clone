using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Driver Driver { get; set; }
        public User User { get; set; }

        //public OrdersDTO(int id, string description, DateTime date, IEnumerable<Product> products, Driver driver, User user)
        //{
        //    Id = id;
        //    Description = description;
        //    Date = date;
        //    Products = products;
        //    Driver = driver;
        //    User = user;
        //}
    }
}
