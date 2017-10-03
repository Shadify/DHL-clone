using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHL_clone.Persistency;
using DHL_clone.ViewModel;

namespace DHL_clone.Model
{
    class OrderSingleton
    {
        private static OrderSingleton _instance;

        public static OrderSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderSingleton();
                }
                return _instance;
            }
        }


        public ObservableCollection<Order> Orders { get; set; }

        private OrderSingleton()
        {
            GetData();
        }

        private async void GetData()
        {
            List<Order> tempOrders = new List<Order>(await PersistencyWebApi.GetOrdersForUser(UserSingleton.Instance.loggedUser.Id));
            foreach (var or in tempOrders)
            {
                Orders.Add(or);
            }
        }
    }
}
