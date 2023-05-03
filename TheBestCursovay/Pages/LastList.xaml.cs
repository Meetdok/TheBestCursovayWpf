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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheBestCursovay.Tools;
using TheBestCursovay.ViewModels;

namespace TheBestCursovay.Pages
{
    /// <summary>
    /// Логика взаимодействия для LastList.xaml
    /// </summary>
    public partial class LastList : Page
    {
        public LastList()
        {
            InitializeComponent();
            DataContext = new FirtsListVM();
        }

        private void MainWindow2_Open(object sender, RoutedEventArgs e)
        {
            CurrentPageControl.Instance.SetPage(new MainWindow2());
        }
    }
}
