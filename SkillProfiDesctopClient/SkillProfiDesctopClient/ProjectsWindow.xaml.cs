using ModelLibrary.Data;
using ModelLibrary.Projects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Http.Headers;

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для ProjectsWindow.xaml
    /// </summary>
    public partial class ProjectsWindow : Window
    {
        private ProjectDataService _projectData;
        public ObservableCollection<Project> Projects;
        public ProjectsWindow()
        {
            InitializeComponent();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
            _projectData = new ProjectDataService(httpClient);

            Loaded += async (sender, e) =>
            {
                IEnumerable<Project> data = await _projectData.GetProjectsAsync();
                Projects = new ObservableCollection<Project>(data);
                ProjectsListBox.ItemsSource = Projects;
            };
        }

        private void CreateBut_OnClick(object sender, RoutedEventArgs e)
        {
            CreateProjectWindow window = new CreateProjectWindow();
            window.Show();
        }

        private void ProjectsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Project project = ProjectsListBox.SelectedItem as Project;
            OneProjectWindow window = new OneProjectWindow(project);
            window.Show();
        }
    }
}
