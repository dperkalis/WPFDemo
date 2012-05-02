using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp.Model;

namespace WPFApp.Services
{
    public static class DataService
    {
        public static ObservableCollection<User> GetUsers()
        {
            var data = new ObservableCollection<User>();
            data.Add(new User() { FirstName = "Don", LastName = "Mattingly" });
            data.Add(new User() { FirstName = "Mark", LastName = "McGwire" });
            data.Add(new User() { FirstName = "Albert", LastName = "Pujols" });
            data.Add(new User() { FirstName = "Alex", LastName = "Rodriguez" });
            return data;
        }
    }
}
