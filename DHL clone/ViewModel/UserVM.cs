using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DHL_clone.Common;
using DHL_clone.Handler;
using DHL_clone.Model;

namespace DHL_clone.ViewModel
{
    public class UserVM : INotifyPropertyChanged
    {
        public UserHandler UserHandler { get; set; }
        public UserSingleton UserSingleton { get; set; }
        public ICommand CreateUserCommand { get; set; }

        public UserVM()
        {
            UserSingleton = UserSingleton.Instance;
            newUser = new User();

            UserHandler = new UserHandler(this);
            CreateUserCommand = new RelayCommand(UserHandler.CreateUser);
        }

        private User newUser;

        public User NewUser
        {
            get { return newUser; }
            set { newUser = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
