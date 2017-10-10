using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHL_clone.Model;
using DHL_clone.ViewModel;

namespace DHL_clone.Handler
{
    public class UserHandler
    {
        public UserVM UserVM { get; set; }

        public UserHandler(UserVM uservm)
        {
            UserVM = uservm;
        }

        public async void CreateUser()
        {
            User user = new User
            {
                Email = UserVM.NewUser.Email,
                Password = UserVM.NewUser.Password,
                Name = UserVM.NewUser.Name,
                Phone = UserVM.NewUser.Phone,
                Address = UserVM.NewUser.Address,
                Type = 1
            };
            await Persistency.PersistencyWebApi.Register(user);

            UserVM.NewUser.Email = "";
            UserVM.NewUser.Password = "";
            UserVM.NewUser.Name = "";
            UserVM.NewUser.Address = "";
            UserVM.NewUser.Phone = 0;
        }
    }
}
