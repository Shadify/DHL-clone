using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHL_clone.Model;

namespace DHL_clone.ViewModel
{
    public class UserSingleton
    {
        static UserSingleton() { }
        private static UserSingleton _instance = new UserSingleton();
        public static UserSingleton Instance { get { return _instance; } }

        public User loggedUser { get; set; }

        private UserSingleton()
        {
        }
    }
}
