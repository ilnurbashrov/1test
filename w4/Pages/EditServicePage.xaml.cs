using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для EditServicePage.xaml
    /// </summary>
    public partial class EditServicePage : Page
    {
        Service service = new Service();
        public EditServicePage(Service serviceselect)
        {
            InitializeComponent();
            if (service != null)
                service = serviceselect;
            DataContext = service;
        }   

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (service.ID == 0)
                    EFModel.Init().Services.Add(service);
                EFModel.Init().SaveChanges();
                MessageBox.Show("cохр!");
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(String.Join(", ", ex.EntityValidationErrors.Last().ValidationErrors.Select(ve => ve.ErrorMessage)));
            }
        }
    }
}
