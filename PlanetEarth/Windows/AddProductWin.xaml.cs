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
    /// Логика взаимодействия для AddProductWin.xaml
    /// </summary>
    public partial class AddProductWin : Window
    {
        public Products _product;
        DbEntities db = DbEntities.GetContext();
        public AddProductWin()
        {
            InitializeComponent();
            countryCB.ItemsSource = (from p in db.Countries select p.Name).ToList();
            branchCB.ItemsSource = (from p in db.Branches select p.Name).ToList();
            manufacturerCB.ItemsSource = (from p in db.Manufacturer select p.Name).ToList();
            funcButton.Content = "Добавить";
        }
        public AddProductWin(Products product)
        {
            InitializeComponent();
            countryCB.ItemsSource = (from p in db.Countries select p.Name).ToList();
            branchCB.ItemsSource = (from p in db.Branches select p.Name).ToList();
            manufacturerCB.ItemsSource = (from p in db.Manufacturer select p.Name).ToList();
            _product = product;
            nameBox.Text = _product.Name;
            descriptionBox.Text = _product.Description;
            countryCB.SelectedItem = _product.CountryName;
            branchCB.SelectedItem = _product.BranchName;
            manufacturerCB.SelectedItem = _product.ManufacturerName;
            amountBox.Text = _product.Amount.ToString();
            datePicker.SelectedDate = _product.ProdDate;
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
                        Products product = new Products
                        { Name = nameBox.Text,
                            Description = descriptionBox.Text,
                            Country = db.Countries.Where(l => l.Name == countryCB.SelectedItem.ToString()).FirstOrDefault().ID,
                            Branch = db.Branches.Where(l => l.Name == branchCB.SelectedItem.ToString()).FirstOrDefault().ID,
                            Manufacturer = db.Manufacturer.Where(l => l.Name == manufacturerCB.SelectedItem.ToString()).FirstOrDefault().ID,
                            Amount = Convert.ToInt32(amountBox.Text),
                            ProdDate = (DateTime)datePicker.SelectedDate
                        };
                        db.Products.Add(product);
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
                        var res = (from p in db.Products where p.ID == _product.ID select p).FirstOrDefault();
                        res.Name = nameBox.Text;
                        res.Description = descriptionBox.Text;
                        res.Country = db.Countries.Where(l => l.Name == countryCB.SelectedItem.ToString()).FirstOrDefault().ID;
                        res.Branch = db.Branches.Where(l => l.Name == branchCB.SelectedItem.ToString()).FirstOrDefault().ID;
                        res.Manufacturer = db.Manufacturer.Where(l => l.Name == manufacturerCB.SelectedItem.ToString()).FirstOrDefault().ID;
                        res.Amount = Convert.ToInt32(amountBox.Text);
                        res.ProdDate = (DateTime)datePicker.SelectedDate;
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
