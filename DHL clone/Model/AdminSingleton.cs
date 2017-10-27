using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL_clone.Model
{
    class AdminSingleton
    {
        private static AdminSingleton _instance;

        public static AdminSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AdminSingleton();
                }
                return _instance;
            }
        }

        public ObservableCollection<OrderDTO> Orders { get; set; }

        public AdminSingleton()
        {
            Orders = new ObservableCollection<OrderDTO>();
            GetData();
        }

        private async void GetData()
        {
            var orders = await Persistency.PersistencyWebApi.GetAllOrders();
            foreach (var order in orders)
            {
                Orders.Add(order);
            }
        }
    }
}
