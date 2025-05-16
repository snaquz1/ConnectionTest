using ConnectionTest.ClassFolder;
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

namespace ConnectionTest.WinFoler
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.database.User.FirstOrDefault(x => x.Username == LoginTB.Text && x.Password == PasswordPB.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
                else
                {
                    MessageBox.Show("Добро пожаловать " + userObj.Username);
                    new MainMenu().Show();
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message); 
            }

            new MainMenu().Show();
            this.Close();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            this.Close();
        }
    }
}
