using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp.Model;

namespace WPFApp.ViewModel
{
    public class ProjectDetailViewModel
    {
        public Project Project { get; set; }
        public string Title
        {
            get { return String.Format("{0} Details", Project.Name); }
        }

        public ProjectDetailViewModel()
        {
            
        }

        public ProjectDetailViewModel(Project project)
        {
            Project = project;
        }
    }
}
