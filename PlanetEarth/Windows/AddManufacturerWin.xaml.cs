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
using System.Windows.Shapes;

namespace PlanetEarth.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddManufacturerWin.xaml
    /// </summary>
    public partial class AddManufacturerWin : Window
    {
        public Manufacturer _manufacturer;
        DbEntities db = DbEntities.GetContext();
       
        public AddManufacturerWin()
        {
            InitializeComponent();
            countryCB.ItemsSource = (from p in db.Countries select p.Name).ToList();
            branchCB.ItemsSource = (from p in db.Branches select p.Name).ToList();
            funcButton.Content = "Добавить";

        }
        public AddManufacturerWin(Manufacturer manufacturer)
        {
            InitializeComponent();
            countryCB.ItemsSource = (from p in db.Countries select p.Name).ToList();
            branchCB.ItemsSource = (from p in db.Branches select p.Name).ToList();
            _manufacturer = manufacturer;
            nameBox.Text = _manufacturer.Name;
            countryCB.SelectedItem = _manufacturer.CountryName;
            branchCB.SelectedItem = _manufacturer.BranchName;
            funcButton.Content = "Изменить";

        }
        private void FuncButton_Click(object sender, RoutedEventArgs e)
        {
            var a = sender as Button;
            switch (a.Content)
            {
                case "Добавить":
                    try
                    {
                        Manufacturer manufacturer = new Manufacturer { Name = nameBox.Text, Country = db.Countries.Where(l => l.Name == countryCB.SelectedItem.ToString()).FirstOrDefault().ID, Branch = db.Branches.Where(l => l.Name == branchCB.SelectedItem.ToString()).FirstOrDefault().ID };
                        db.Manufacturer.Add(manufacturer);
                        db.SaveChanges();
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Введены некорректные данные");
                    }


                    break;
                case "Изменить":
                    try
                    {
                        var res = (from p in db.Manufacturer where p.ID == _manufacturer.ID select p).FirstOrDefault();
                        res.Name = nameBox.Text;
       
                        res.Country = db.Countries.Where(l => l.Name == countryCB.SelectedItem.ToString()).FirstOrDefault().ID;
                        res.Branch = db.Branches.Where(l => l.Name == branchCB.SelectedItem.ToString()).FirstOrDefault().ID;
                        db.SaveChanges();
                        Close();
                    }
                    catch
                    {

                        MessageBox.Show("Введены некорректные данные");
                    }
                    break;
            }
        }
    }
}
