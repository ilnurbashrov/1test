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
    /// Логика взаимодействия для UserServicePage.xaml
    /// </summary>
    public partial class UserServicePage : Page
    {
        public UserServicePage()
        {
            InitializeComponent();
            cbSort.Items.Add("по возрастанию");
            cbSort.Items.Add("по убыванию");
            cbSort.SelectedIndex = 0;
            UpdateData();
        }

        public void UpdateData()
        {
            IEnumerable<Service> services = EFModel.Init().Services.Where(w => w.Title.Contains(tbSearch.Text) | w.Description.Contains(tbSearch.Text));
            switch (cbSort.SelectedIndex)
            {
                case 0:
                    services = services.OrderBy(s => s.Cost);
                    break;
                case 1:
                    services = services.OrderByDescending(s => s.Cost);
                    break;
            }

            LvService.ItemsSource = services.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void btRec_Click(object sender, RoutedEventArgs e)
        {
            Service service = (sender as Button).DataContext as Service;
            NavigationService.Navigate(new OrderService(service));
        }
    }
}
