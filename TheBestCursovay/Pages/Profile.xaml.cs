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
using WebTheBestCursach.Models;

namespace TheBestCursovay.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            DataContext = new FirtsListVM();
        }

        //private async void SaveForm(object sender, RoutedEventArgs e)
        //{
        //    var json = await HttpApi.Post("AduccationForms", "Save", new AduccationForm
        //    {
        //        Documents = new Documet
        //        {
        //            Name = txt_Name.Text,
        //            LastName = SecondName.Text,
        //            Snils = int.Parse(Snils.Text),
        //            BirthdayDate = DateTime.Parse(BrithdayDate.Text),
        //            BirthPlace = PlaceBithday.Text,
        //            Inn = int.Parse(INN.Text),
        //            Addres = Addres.Text,
        //            Nationality = Nationality.Text,
        //            PassNumber = int.Parse(PassNumber.Text),
        //            PassSeries = int.Parse(Seria_Pass.Text),
        //            IssuedBy = Who.Text
        //        },
        //        Fluorography = Flurografy.Text,
        //        PatronicName = PatronykName.Text,
        //        PrimingCertificate = Score.Text,
        //        RegistrationCertificate = RegistarionSerificate.Text,
        //        MedicalPolicy = Polis.Text,
        //        Speciality = new Speciality { SpecialityName = NameSpeciality.Text },
        //        EducationForm = new EducationForm { EducationName = AdducationForm.Text }


        //    });
        //}
    }
}
