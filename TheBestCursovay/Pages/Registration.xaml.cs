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
using TheBestCursovay.Tools;
using WebTheBestCursach.Models;

namespace TheBestCursovay.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }


        private async void Regist(object sender, RoutedEventArgs e)
        {

            var json = await HttpApi.Post("Users", "SaveUser", new User
            {
                UserName = txt_Name.Text,
                UserLatName = txt_LastName.Text,
                PhoneNumber = long.Parse(txt_Phone.Text),
                Mail = txt_Email.Text,
                Login = new LoginPage { Login = txt_Login.Text, Password = txt_Password.Text },
                RoleId = 1                                
            });



            User result = HttpApi.Deserialize<User>(json);
            

            MessageBox.Show("Сохранилось");

            Autorization m = new Autorization();
            m.Show();
            this.Close();
        }
    }
}
