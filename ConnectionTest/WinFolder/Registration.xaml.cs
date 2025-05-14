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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            AppConnect.database = new ConnectionTestEntities();
            
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
                if (AppConnect.database.User.Count(x => x.Username == TBLogin.Text) > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже есть");
                    return;
                }
            try
            {
                User userObj = new User()
                {
                    Username = TBLogin.Text,
                    Password = PBPassword.Password

                };
                AppConnect.database.User.Add(userObj);
                AppConnect.database.SaveChanges();
                MessageBox.Show("Данные успешно обновлены");
                new MainMenu().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + ex.InnerException.ToString());
            }
        }
    }
}
