using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFApp.Infrastructure;
using WPFApp.Model;
using WPFApp.Services;

namespace WPFApp.ViewModel
{
    public class WorkHistoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _users = DataService.GetUsers();

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    RaisePropertyChanged("Users");
                }
            }
        }

        public bool CanGetSelectedUser()
        {
            return true;
        }

        public void DoSomething()
        {

        }

        public ICommand GetSelectedUser
        {
            get
            {
                return new RelayCommand(DoSomething, CanGetSelectedUser);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
