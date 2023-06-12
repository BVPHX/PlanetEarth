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
    /// Логика взаимодействия для CountriesPage.xaml
    /// </summary>
    public partial class CountriesPage : Page
    {
        public DbEntities db = DbEntities.GetContext();
        public CountriesPage()
        {
            InitializeComponent();
            db.Countries.Load();
            mainGrid.ItemsSource = db.Countries.Local.ToBindingList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddCountryWin win = new AddCountryWin();
            win.ShowDialog();
            mainGrid.Items.Refresh();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var temp = (Countries)mainGrid.SelectedItem;
                AddCountryWin win = new AddCountryWin(temp);
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
            var temp = (Countries)mainGrid.SelectedItem;
            db.Countries.Remove(temp);
            db.SaveChanges();
            mainGrid.Items.Refresh();
        }
    }
}
