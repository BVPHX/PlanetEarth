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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public DbEntities db = DbEntities.GetContext();
        public ProductsPage()
        {
            InitializeComponent();
            db.Products.Load();
            mainGrid.ItemsSource = db.Products.Local.ToBindingList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProductWin win = new AddProductWin();
            win.ShowDialog();
            mainGrid.Items.Refresh();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var temp = (Products)mainGrid.SelectedItem;
                AddProductWin win = new AddProductWin(temp);
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

            try
            {
                var temp = (Products)mainGrid.SelectedItem;
                db.Products.Remove(temp);
                db.SaveChanges();
                mainGrid.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Не выбрана запись");
            }
        }
    }
}
