using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHL_clone.Model
{
    class DriverSingleton
    {
        private static DriverSingleton _instance;

        public static DriverSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DriverSingleton();
                }
                return _instance;
            }
        }

        public ObservableCollection<Driver> Drivers { get; set; }

        public DriverSingleton()
        {
            Drivers = new ObservableCollection<Driver>();
            GetData();
        }

        private async void GetData()
        {
            var drivers = await Persistency.PersistencyWebApi.GetDrivers();
            foreach (var driver in drivers)
            {
                Drivers.Add(driver);
            }
        }
    }
}
