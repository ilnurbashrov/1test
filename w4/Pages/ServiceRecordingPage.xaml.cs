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
    /// Логика взаимодействия для ServiceRecordingPage.xaml
    /// </summary>
    public partial class ServiceRecordingPage : Page
    {
        public ServiceRecordingPage()
        {
            InitializeComponent();
            UpdateData();
            
        }

        public void UpdateData()
        {
            IEnumerable<ClientService> services = EFModel.Init().ClientServices.Where(w => w.Client.FirstName.Contains(tbSearch.Text));
            lvClient.ItemsSource = services.ToList();
           
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void btDelet_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("вы точно хотите удалить?", "внимание!", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
            {
                try
                {
                    ClientService clientService = (sender as Button).DataContext as ClientService;
                    EFModel.Init().ClientServices.Remove(clientService);
                    EFModel.Init().SaveChanges();
                    MessageBox.Show("удалено");
                    UpdateData();
                }
                catch (Exception)
                {
                    MessageBox.Show("ошибка!");
                }
            }
        }
    }
}
