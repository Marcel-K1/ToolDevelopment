using CommunityToolkit.Mvvm.ComponentModel;
using LevelEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.Services
{
    public class ProjectManager : ObservableObject
    {
        private Project currentProject;
        public Project CurrentProject
        {
            get => currentProject;
            set => SetProperty(ref currentProject, value);
        }

        public ProjectManager()
        {
            NewProject();
        }

        public void CloseProject() => CurrentProject = null;
        public void NewProject() => CurrentProject = new Project();
        public void OpenProject()
        {

        }
        public void SaveProject()
        {

        }
    }
}
