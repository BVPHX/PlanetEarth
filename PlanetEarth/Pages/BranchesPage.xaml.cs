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
    /// Логика взаимодействия для BranchesPage.xaml
    /// </summary>
    public partial class BranchesPage : Page
    {
        public DbEntities db = DbEntities.GetContext();
        public BranchesPage()
        {
            InitializeComponent();
            db.Branches.Load();
            mainGrid.ItemsSource = db.Branches.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddBranchWin win = new AddBranchWin();
            win.ShowDialog();
            mainGrid.Items.Refresh();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var temp = (Branches)mainGrid.SelectedItem;
                AddBranchWin win = new AddBranchWin(temp);
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
            var temp = (Branches)mainGrid.SelectedItem;
            db.Branches.Remove(temp);
            db.SaveChanges();
            mainGrid.Items.Refresh();
        }
    }
}
