using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFApp.Infrastructure;
using WPFApp.Model;
using WPFApp.Services;

namespace WPFApp.ViewModel
{
    public class ProjectsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Project> _projects = DataService.GetProjects();

        public ObservableCollection<Project> Projects
        {
            get { return _projects; }
            set
            {
                if (_projects != value)
                {
                    _projects = value;
                    RaisePropertyChanged("Projects");
                }
            }
        }

        private bool CanGetProjectDetails()
        {
            return true;
        }

        private void LoadProjectDetail(Project project)
        {
            var pd = new ProjectDetail();
            pd.DataContext = new ProjectDetailViewModel(project);
            pd.Show();
           
        }

        public ICommand ShowProjectDetail
        {
            get
            {
                return new RelayCommand<Project>(LoadProjectDetail, CanGetProjectDetails);
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
