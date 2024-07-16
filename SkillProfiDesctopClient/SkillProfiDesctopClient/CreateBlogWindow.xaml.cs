using ModelLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
using SkillProfiDesctopClient.Tools;
using Microsoft.Win32;
using SkillProfiDesctopClient.Pages;
using System.IO;
using ModelLibrary.Blogs;

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для CreateBlogWindow.xaml
    /// </summary>
    public partial class CreateBlogWindow : Window
    {
        private BlogDataService _blogData;
        private byte[] imageBytes;
        private string _fileName;
        public CreateBlogWindow()
        {
            InitializeComponent();
            _blogData = new BlogDataService(Connection.httpClient);
        }

        private void UploadImg_OnClick(object sender, RoutedEventArgs e)
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
                BlogImage.Source = image;

                //imageBytes = ImageLoader.ByteFromBitmapImage(image);
                Console.WriteLine(imageBytes.Length);
            }

        }
        private async void CreateBut_OnClick(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != null && PreviewBox.Text != null && DescriptionBox.Text != null && BlogImage.Source != null)
            {
                BlogModel model = new BlogModel()
                {
                    Name = NameBox.Text,
                    Preview = PreviewBox.Text,
                    Description = DescriptionBox.Text,
                    ImageData = imageBytes,
                    ImageDataUrl = _fileName
                };
                string extension = System.IO.Path.GetExtension(_fileName);
                model.ImageContentType = MimeTypesHelper.GetContentType(extension);
                Console.WriteLine(model.ImageData.Length);
                bool res = await _blogData.CreateAsync(model);
                if (res)
                {
                    MessageBox.Show("Блог успешно сохранен.", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при сохранении блога", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Все поля обязательны к заполнению", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
