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
        public static ObservableCollection<Project> GetProjects()
        {
            var data = new ObservableCollection<Project>();
            data.Add(new Project() { Name = "OMC" });
            data.Add(new Project() { Name = "Capture" });
            data.Add(new Project() { Name = "Agent" });
            data.Add(new Project() { Name = "Licensing" });
            data.Add(new Project() { Name = "MRC" });
            data.Add(new Project() { Name = "Forms" });
            return data;
        }
    }
}
