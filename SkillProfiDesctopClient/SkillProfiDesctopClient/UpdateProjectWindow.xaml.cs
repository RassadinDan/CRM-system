using Microsoft.Win32;
using ModelLibrary.Projects;
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
    /// Логика взаимодействия для UpdateProjectWindow.xaml
    /// </summary>
    public partial class UpdateProjectWindow : Window
    {
        private Project Project;
        private byte[] imageBytes;
        private string _fileName;
        public UpdateProjectWindow(Project project)
        {
            InitializeComponent();
            Project = project;
            PreviewBox.Text = Project.Preview;
            DescriptionBox.Text = Project.Description;

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

        private void UpdateBut_OnClick(object sender, RoutedEventArgs e)
        {
            if(PreviewBox.Text != null && DescriptionBox.Text != null && ProjectImage.Source != null)
            {
                ProjectModel model = Project as ProjectModel;
                model.Preview = PreviewBox.Text;
                model.Description = DescriptionBox.Text;
                model.ImageData = imageBytes;
                model.ImageDataUrl = _fileName;
            }
        }
    }
}
