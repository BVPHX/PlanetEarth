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
    /// Логика взаимодействия для AddCountryWin.xaml
    /// </summary>
    public partial class AddCountryWin : Window
    {
        DbEntities db = DbEntities.GetContext();
        private Countries _country;
        public AddCountryWin()
        {
            InitializeComponent();
            funcButton.Content = "Добавить";
        }
        public AddCountryWin(Countries country)
        {
            InitializeComponent();
            funcButton.Content = "Изменить";
            _country = country;
            nameBox.Text = _country.Name;
        }
        private void FuncButton_Click(object sender, RoutedEventArgs e)
        {
            var a = sender as Button;
            switch (a.Content)
            {
                case "Добавить":
                    try
                    {
                        Countries countries = new Countries { Name = nameBox.Text };
                        db.Countries.Add(countries);
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
                        var res = (from p in db.Countries where p.ID == _country.ID select p).FirstOrDefault();
                        res.Name = nameBox.Text;
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
