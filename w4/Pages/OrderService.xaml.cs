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
using System.Windows.Navigation;
using System.Windows.Shapes;
using w4.DateBase;

namespace w4.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderService.xaml
    /// </summary>
    public partial class OrderService : Page
    {
        ClientService Service;
        public OrderService(Service service)
        {
            Service = new ClientService { Service = service, StartTime = DateTime.Now };
            InitializeComponent();
            DataContext = Service;
            cbClient.ItemsSource = EFModel.Init().Clients.ToList();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service.Client = cbClient.SelectedItem as Client;
                EFModel.Init().ClientServices.Add(Service);
                EFModel.Init().SaveChanges();
                MessageBox.Show("запись готова");
            }
            catch(Exception)
            {
                MessageBox.Show("ошиибка");
            }
        }
    }
}
