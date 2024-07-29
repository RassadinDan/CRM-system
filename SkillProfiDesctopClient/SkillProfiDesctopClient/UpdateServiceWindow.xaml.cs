using ModelLibrary.Data;
using ModelLibrary.Services;
using SkillProfiDesctopClient.Tools;
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

namespace SkillProfiDesctopClient
{
    /// <summary>
    /// Логика взаимодействия для UpdateServiceWindow.xaml
    /// </summary>
    public partial class UpdateServiceWindow : Window
    {
        private Service Service;
        private ServiceDataService _serviceData;
        public UpdateServiceWindow(Service service)
        {
            InitializeComponent();
            _serviceData = new ServiceDataService(Connection.httpClient);
            Service = service;
            NameBox.Text = Service.Name;
            DescriptionBox.Text = Service.Description;

        }


        private async void UpdateBut_OnClick(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != null && DescriptionBox.Text != null)
            {
                var model = new ServiceModel()
                {
                    Name = NameBox.Text,
                    Description = DescriptionBox.Text
                };

                bool res = await _serviceData.UpdateServiceAsync(Service.Id, model);
                if (res) 
                {
                    MessageBox.Show("Запись службы успешно обновлена", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Не удалось создать запись службы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            }
        }
    }
}
