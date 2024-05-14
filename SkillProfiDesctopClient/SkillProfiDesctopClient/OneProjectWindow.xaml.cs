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
using ModelLibrary.Projects;

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для OneProjectWindow.xaml
    /// </summary>
    public partial class OneProjectWindow : Window
    {
        public Project Project { get; set; }
        public OneProjectWindow(Project project)
        {
            InitializeComponent();
            this.Project = project;
			PreviewBox.Text = Project.Preview;
            DescriptionBox.Text = Project.Description;
			ProjectImage.Source = LoadImage(Project.ImageData);
        }

		private static BitmapImage LoadImage(byte[] imageData)
		{
			if (imageData == null || imageData.Length == 0) return null;
			var image = new BitmapImage();
			using (var mem = new MemoryStream(imageData))
			{
				mem.Position = 0;
				image.BeginInit();
				image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
				image.CacheOption = BitmapCacheOption.OnLoad;
				image.UriSource = null;
				image.StreamSource = mem;
				image.EndInit();
			}
			image.Freeze();
			return image;
		}
	}
}
