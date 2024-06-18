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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkillProfiDesctopClient.Tools;

namespace SkillProfiDesctopClient.Pages
{
	/// <summary>
	/// Логика взаимодействия для OneProjectPage.xaml
	/// </summary>
	public partial class OneProjectPage : Page
	{
		public Project Project { get; set; }
		public OneProjectPage(Project project)
		{
			InitializeComponent();
			this.Project = project;
			PreviewBox.Text = Project.Preview;
			DescriptionBox.Text = Project.Description;
			ProjectImage.Source = ImageLoader.LoadImage(Project.ImageData);
		}
	}
}
