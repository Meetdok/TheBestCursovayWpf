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
using TheBestCursovay.ViewModels;
using WebTheBestCursach.Models;

namespace TheBestCursovay.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditList.xaml
    /// </summary>
    public partial class EditList : Window
    {
        public EditList(AduccationForm aduccationForm, EducationForm educationForm, Documet documet)
        {
            InitializeComponent();
            DataContext = new EditListVM(aduccationForm, educationForm, documet);
        }
    }
}
