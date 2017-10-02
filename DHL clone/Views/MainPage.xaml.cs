using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DHL_clone.Model;
using DHL_clone.ViewModel;
using DHL_clone.Views;
using Template10.Services.NavigationService;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DHL_clone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var u = new User();
            u.Email = EmailTB.Text;
            u.Password = PasswordTB.Password;
            User user = await Persistency.PersistencyWebApi.Login(u);
            if (user != null)
            {
                int loggedUserType = user.Type;
                UserSingleton.Instance.loggedUser = user;
                switch (loggedUserType)
                {
                    case 1:
                    {
                        Frame.Navigate(typeof(OrdersPage), u.Id);
                        break;
                    }
                    case 0:
                    {
                        //  NavigationService.Navigate(typeof(DriverOrderPage))
                        break;
                    }
                    default:
                        break;
                }
            }
        }
    }
}
