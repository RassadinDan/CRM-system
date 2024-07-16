using Microsoft.Win32;
using ModelLibrary.Blogs;
using ModelLibrary.Data;
using SkillProfiDesctopClient.Tools;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для UpdateBlogWindow.xaml
    /// </summary>
    public partial class UpdateBlogWindow : Window
    {
        private Blog Blog;
        private byte[] imageBytes;
        private string _fileName;
        private BlogDataService _blogData;
        public UpdateBlogWindow(Blog blog)
        {
            InitializeComponent();

            Blog = blog;
            NameBox.Text = blog.Name;
            PreviewBox.Text = blog.Preview;
            DescriptionBox.Text = blog.Description;
            BlogImage.Source = ImageLoader.LoadImage(Blog.ImageData);
            imageBytes = Blog.ImageData;
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

                Console.WriteLine(imageBytes.Length);
            }

        }


        private async void UpdateBut_OnClick(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != null && PreviewBox.Text != null && DescriptionBox.Text != null && BlogImage.Source != null)
            {
                BlogModel model = new BlogModel()
                {
                    Name = NameBox.Text,
                    Preview = PreviewBox.Text,
                    Description = DescriptionBox.Text,
                    ImageData = imageBytes
                };

                Console.WriteLine($"{model.ImageData.Length}");
                bool res = await _blogData.UpdateAsync(Blog.Id, model);
                if (res)
                {
                    MessageBox.Show("Блог успешно сохранен.", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
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
