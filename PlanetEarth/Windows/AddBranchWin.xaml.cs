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
    /// Логика взаимодействия для AddBranchWin.xaml
    /// </summary>
    public partial class AddBranchWin : Window
    {
        DbEntities db = DbEntities.GetContext();
        private Branches _branch;
        public AddBranchWin()
        {
            InitializeComponent();
            funcButton.Content = "Добавить";
        }
        public AddBranchWin(Branches branch)
        {
            InitializeComponent();
            _branch = branch;
            branchNameBox.Text = branch.Name;
            branchDescBox.Text = branch.Description;
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
                        Branches branch = new Branches { Name = branchNameBox.Text, Description = branchDescBox.Text };
                        db.Branches.Add(branch);
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
                        var res = (from p in db.Branches where p.ID == _branch.ID select p).FirstOrDefault();
                        res.Name = branchNameBox.Text;
                        res.Description = branchDescBox.Text;
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
