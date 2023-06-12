using PlanetEarth.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace PlanetEarth.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManufacturersPage.xaml
    /// </summary>
    public partial class ManufacturersPage : Page
    {
        public DbEntities db = DbEntities.GetContext();
        public ManufacturersPage()
        {
            InitializeComponent();
            db.Manufacturer.Load();
            mainGrid.ItemsSource = db.Manufacturer.Local.ToBindingList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturerWin win = new AddManufacturerWin();
            win.ShowDialog();
            mainGrid.Items.Refresh();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var temp = (Manufacturer)mainGrid.SelectedItem;
                AddManufacturerWin win = new AddManufacturerWin(temp);
                win.ShowDialog();
                mainGrid.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Не выбрана запись");
            }


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var temp = (Manufacturer)mainGrid.SelectedItem;
            db.Manufacturer.Remove(temp);
            db.SaveChanges();
            mainGrid.Items.Refresh();
        }
    }
}
