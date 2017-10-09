using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DHL_clone.Model;

namespace DHL_clone.ViewModel
{
    class OrderVM : INotifyPropertyChanged
    {
        //For when creating Orders
        //private Order _newOrder;

        //public Order NewOrder
        //{
        //    get { return _newOrder; }
        //    set { _newOrder = value; OnPropertyChanged(); }
        //}

        public OrderSingleton OrderSingleton { get; set; }

        public OrderVM()
        {
            OrderSingleton = OrderSingleton.Instance;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
