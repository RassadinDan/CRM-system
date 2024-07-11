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
using SkillProfiDesctopClient.Tools;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Drawing;

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для CreateProjectWindow.xaml
    /// </summary>
    public partial class CreateProjectWindow : Window
    {
        private ProjectDataService _projectData;
        private byte[] imageBytes;
        private string _fileName;
        public CreateProjectWindow()
        {
            InitializeComponent();
            _projectData = new ProjectDataService(Connection.httpClient);
        }

		private void UploadImgBut_Click(object sender, RoutedEventArgs e)
		{
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files(*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if(fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;
                _fileName = fileName;
                Stream stream = fileDialog.OpenFile();

                if (stream != null && stream.Length > 0)
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        imageBytes =  br.ReadBytes((Int32)stream.Length);
                    }
                }

                var image = new BitmapImage(new Uri(fileName));
                ProjectImage.Source = image;

                //imageBytes = ImageLoader.ByteFromBitmapImage(image);
                Console.WriteLine(imageBytes.Length);
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
                    ImageData = imageBytes,
                    ImageDataUrl = _fileName
                };
                string extension = System.IO.Path.GetExtension(_fileName);
                model.ImageContentType = MimeTypesHelper.GetContentType(extension);
                Console.WriteLine(model.ImageData.Length);
                bool res = await _projectData.CreateAsync(model);
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
