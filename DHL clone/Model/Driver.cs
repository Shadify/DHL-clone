using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL_clone.Model
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Phone { get; set; }
        public int VehicleNr { get; set; }

        public Driver(int id, string name, int phone, int vehicleNr)
        {
            Id = id;
            Name = name;
            Phone = phone;
            VehicleNr = vehicleNr;
        }
        public Driver() { }
    }
}
