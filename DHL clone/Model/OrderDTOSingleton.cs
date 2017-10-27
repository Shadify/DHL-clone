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
    public class OrderDTOSingleton
    {
        private static OrderDTOSingleton _instance;

        public static OrderDTOSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderDTOSingleton();
                }
                return _instance;
            }
        }


        public ObservableCollection<OrderDTO> Orders { get; set; }

        private OrderDTOSingleton()
        {
            Orders = new ObservableCollection<OrderDTO>();
            GetData();
        }

        private async void GetData()
        {
            var tempOrders = await PersistencyWebApi.GetOrdersForUser(UserSingleton.Instance.loggedUser.Id);
            foreach (var or in tempOrders)
            {
                Orders.Add(or);
            }
        }
    }
}
