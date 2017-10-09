using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHL_clone.Model;

namespace DHL_clone.ViewModel
{
    class DriverVM
    {
        public DriverSingleton DriverSingleton { get; set; }

        public DriverVM()
        {
            DriverSingleton = DriverSingleton.Instance;
        }
    }
}
