using Microsoft.Win32;
using ModelLibrary.Data;
using ModelLibrary.Projects;
using SkillProfiDesctopClient.Tools;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для UpdateProjectWindow.xaml
    /// </summary>
    public partial class UpdateProjectWindow : Window
    {
        private Project Project;
        private byte[] imageBytes;
        private string _fileName;
        private ProjectDataService _projectData;
        public UpdateProjectWindow(Project project)
        {
            InitializeComponent();
            Project = project;
            PreviewBox.Text = Project.Preview;
            DescriptionBox.Text = Project.Description;
            ProjectImage.Source = ImageLoader.LoadImage(Project.ImageData);
            imageBytes = Project.ImageData;
            _projectData = new ProjectDataService(Connection.httpClient);
        }

        private void UploadImgBut_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files(*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;
                _fileName = fileName;
                Stream stream = fileDialog.OpenFile();

                if (stream != null && stream.Length > 0)
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        imageBytes = br.ReadBytes((Int32)stream.Length);
                    }
                }

                var image = new BitmapImage(new Uri(fileName));
                ProjectImage.Source = image;

                Console.WriteLine(imageBytes.Length);
            }
        }

        private async void UpdateBut_OnClick(object sender, RoutedEventArgs e)
        {
            if(PreviewBox.Text != null && DescriptionBox.Text != null && ProjectImage.Source != null)
            {
                ProjectModel model = new ProjectModel()
                {
                    Preview = PreviewBox.Text,
                    Description = DescriptionBox.Text,
                    ImageData = imageBytes,
                    //ImageDataUrl = _fileName
                };

                //string extension = System.IO.Path.GetExtension(_fileName);
                //model.ImageContentType = MimeTypesHelper.GetContentType(extension);
                bool res = await _projectData.UpdateAsync(Project.Id, model);
                if (res)
                {
                    MessageBox.Show("Проект успешно сохранен.", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
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
