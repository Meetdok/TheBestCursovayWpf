using System;
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
using TheBestCursovay.Pages;
using TheBestCursovay.Tools;
using WebTheBestCursach.Models;

namespace TheBestCursovay;
public partial class Autorization : Window
{
    public Autorization()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var json = await HttpApi.Post("LoginPages", "Auth", new Auth { Login = TextBox_login.Text, Password = TextBox_password.Text });
        LoginPage result = HttpApi.Deserialize<LoginPage>(json);
        var user = result.Users.First();
        {
            if (user.RoleId == 1)
            {
                MainWindow m = new MainWindow();
                m.Show();
                CurrentPageControl.Instance.Page = new FirstList();
                this.Close();
            }

            else if (user.RoleId == 2)
            {
                ImployerWindow m = new ImployerWindow();
                m.Show();
                CurrentPageControl.Instance.Page = new MainWindow2();
                this.Close();
            }

            else
            {
                MessageBox.Show("Неверно!", "Аккаунта не существет!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    private void Registration(object sender, RoutedEventArgs e)
    {
        Registration r = new Registration();
        r.Show();
        this.Close();

    }
}
//namespace TheBestCursovay
////{
//    /// <summary>
//    /// Логика взаимодействия для Autorization.xaml
//    /// </summary>
////    public partial class Autorization : Window
////    {
////        public Autorization()
////        {
////            InitializeComponent();
////        }

////private void Button_Click(object sender, RoutedEventArgs e)
////{
////    var loginUser = TextBox_login.Text.Trim();
////    var passUser = TextBox_password.Text.Trim();
////    bool enter1 = false;
////    bool enter2 = false;


////    LoginPage log = null;
////    using (user05Context db = new user05Context())
////    {
////        log = db.LoginPages.Where(b => b.Login == loginUser && b.Password == passUser).FirstOrDefault();
////        var user = db.Users.FirstOrDefault(s => s.LoginId == log.Id);
////        enter1 = user?.RoleId == 1;
////        enter2 = user?.RoleId == 2;
////    }

////    if (enter1)
////    {
////        MainWindow f = new MainWindow();
////        f.Show();
////        this.Close();
////    }

////    if (enter2)
////    {
////        MainWindow2 f = new MainWindow2();
////        f.Show();
////        this.Close();
////    }

////        }
////    }
////}
