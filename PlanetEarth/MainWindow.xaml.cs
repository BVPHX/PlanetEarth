using PlanetEarth.Pages;
using PlanetEarth.Windows;
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

namespace PlanetEarth
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbEntities db = DbEntities.GetContext();
        BranchesPage branchesPage = new BranchesPage();
        CountriesPage countriesPage = new CountriesPage();
        ManufacturersPage manufacturersPage = new ManufacturersPage();
        ProductsPage productsPage = new ProductsPage();

        public MainWindow()
        {
            InitializeComponent();
            pageChangeCB.SelectedIndex = 0;
            AuthWin win = new AuthWin();
            win.ShowDialog();
            if (win.IsAuthorized == false) Close();

        }

        private void CBPageChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (pageChangeCB.SelectedIndex)
            {
                case 0:
                    mainFrame.Navigate(branchesPage);
                    break;
                case 1:
                    mainFrame.Navigate(countriesPage);
                    break;
                case 2:
                    mainFrame.Navigate(manufacturersPage);
                    break;
                case 3:
                    mainFrame.Navigate(productsPage);
                    break;


            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            if (searchBox.Text != null || searchBox.Text != String.Empty)
            {
                switch (pageChangeCB.SelectedIndex)
                {
                    case 0:
                        branchesPage.mainGrid.ItemsSource = db.Branches.Where(c => c.Name.StartsWith(searchBox.Text)).ToList();
                        break;
                    case 1:
                        countriesPage.mainGrid.ItemsSource = db.Countries.Where(c => c.Name.StartsWith(searchBox.Text)).ToList();
                        break;
                    case 2:
                        manufacturersPage.mainGrid.ItemsSource = db.Manufacturer.Where(c => c.Name.StartsWith(searchBox.Text)).ToList();
                        break;
                    case 3:
                        productsPage.mainGrid.ItemsSource = db.Products.Where(c => c.Name.StartsWith(searchBox.Text)).ToList();
                        break;


                }  
            }
            else
            {
                switch (pageChangeCB.SelectedIndex)
                {
                    case 0:
                        branchesPage.mainGrid.ItemsSource = branchesPage.db.Branches.Local.ToList();
                        break;
                    case 1:
                        countriesPage.mainGrid.ItemsSource = countriesPage.db.Countries.Local.ToList();
                        break;
                    case 2:
                        manufacturersPage.mainGrid.ItemsSource = manufacturersPage.db.Manufacturer.Local.ToList();
                        break;
                    case 3:
                        productsPage.mainGrid.ItemsSource = productsPage.db.Products.Local.ToList();
                        break;


                }
            }
        }
    }
}
