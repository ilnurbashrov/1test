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
    /// Логика взаимодействия для ServiceAdminPage.xaml
    /// </summary>
    public partial class ServiceAdminPage : Page
    {
        public ServiceAdminPage()
        {
            InitializeComponent();
            CbSort.Items.Add("по возрастанию");
            CbSort.Items.Add("по убыванию");
            CbSort.SelectedIndex = 0;
            UpdateData();
        }

        public void UpdateData()
        {
            IEnumerable<Service> services = EFModel.Init().Services.Where(w => w.Title.Contains(TbSearch.Text));
            switch (CbSort.SelectedIndex)
            {
                case 0:
                    services = services.OrderBy(w => w.Cost);
                    break;
                case 1:
                    services = services.OrderByDescending(w => w.Cost);
                    break;
            }
            LvService.ItemsSource = services.ToList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("ВЫ ТОЧНО ХОТИТЕ УДАЛИТЬ?", "ВНИМАНИЕ", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
            {
                try
                {
            Service service = (sender as Button).DataContext as Service;
            EFModel.Init().Services.Remove(service);
            EFModel.Init().SaveChanges();
            UpdateData();
                }
                catch(Exception)
                {
                    MessageBox.Show("ЗАПИСЬ УЧАСТВУЕТ!");
                }
            }
        }
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddServicePage());
        }

        private void btRec_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceRecordingPage());
        }

        private void btRedact_Click(object sender, RoutedEventArgs e)
        {
            Button btService = sender as Button;
            Service service = btService.DataContext as Service;
            NavigationService.Navigate(new EditServicePage(service));
        }
    }
}
