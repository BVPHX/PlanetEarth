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
    /// Логика взаимодействия для AuthWin.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        DbEntities db = DbEntities.GetContext();
        public bool IsAuthorized = false;
        public AuthWin()
        {
            InitializeComponent();
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            var user = db.Accounts.Where(l => l.Login == loginTB.Text).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == passwordBox.Password)
                {
                    IsAuthorized = true;
                    Close();
                }
                else MessageBox.Show("Неправильный логин или пароль");
            }
            else MessageBox.Show("Неправильный логин или пароль");
        }
    }
}
