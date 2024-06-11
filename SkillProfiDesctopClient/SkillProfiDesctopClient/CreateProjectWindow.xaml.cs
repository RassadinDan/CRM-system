using Microsoft.Win32;
using ModelLibrary.Data;
using ModelLibrary.Projects;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CreateProjectWindow.xaml
    /// </summary>
    public partial class CreateProjectWindow : Window
    {
        private HttpClient client;
        private ProjectDataService _projectData;
        public CreateProjectWindow()
        {
            InitializeComponent();
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthSession.Token);
            _projectData = new ProjectDataService(client);
        }

		private void UploadImgBut_Click(object sender, RoutedEventArgs e)
		{
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files(*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if(fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;
                ProjectImage.Source = new BitmapImage(new Uri(fileName));
            }
		}

		private async void CreateBut_ClickAsync(object sender, RoutedEventArgs e)
		{
            if(PreviewBox.Text != null && DescriptionBox.Text != null && ProjectImage.Source != null)
            {
                ProjectModel model = new ProjectModel()
                {
                    Preview = PreviewBox.Text,
                    Description = DescriptionBox.Text,
                };
                bool res = await _projectData.CreateProjectAsync(model);
                if (res)
                {
                    MessageBox.Show("Проект успешно сохранен.", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при сохранении проекта", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Все поля обязательны к заполнению", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
		}
	}
}
