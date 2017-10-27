using DHL_clone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL_clone.ViewModel
{
    class AdminVM
    {
        public AdminSingleton AdminSingleton { get; set; }

        public AdminVM()
        {
            AdminSingleton = AdminSingleton.Instance;
        }
    }
}
