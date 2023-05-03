using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TheBestCursovay.Pages;
using TheBestCursovay.Tools;
using WebTheBestCursach.Models;

namespace TheBestCursovay.ViewModels
{
    public class FirtsListVM : BaseTools
    {

        public CommandVM FirstList { get; set; }

        public CommandVM UserLastList { get; set; }

        public CommandVM MainWindow2 { get; set; }

        public CommandVM Save { get; set; }

        public string Name { get; set; }
        public string PatronicName { get; set; }
        public string PrimingCertificate { get; set; }
        public string RegistarionSerificate { get; set; }
        public string Polis { get; set; }
        public string Flurografy { get; set; }
        public string SecondName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string PlaceBithday { get; set; }
        public int INN { get; set; }
        public string Nationality { get; set; }
        public int Seria_Pass { get; set; }
        public int PassNumber { get; set; }
        public string Who { get; set; }
        public string Score { get; set; }
        public int Snils { get; set; }
        public string Addres { get; set; }
        public string EdducationForm { get; set; }


        private Speciality specialitiess;
        public Speciality SelectedSpeciality
        {
            get => specialitiess;
            set
            {
                specialitiess = value;
                Signal();
            }
        }

        private List<AduccationForm> aduccationForms;
        public List<EducationForm> educationForm;
        private List<Documet> documets;
        private List<Speciality> specialities;

        public List<AduccationForm> AduccationForm
        {
            get => aduccationForms;
            set
            {
                aduccationForms = value;

                Signal();
            }
        }

        public List<EducationForm> EducationForm
        {
            get => educationForm;
            set
            {
                educationForm = value;

                Signal();
            }
        }

        public List<Documet> Documents
        {
            get => documets;
            set
            {
                documets = value;

                Signal();
            }
        }



        public List<Speciality> Speciality
        {
            get => specialities;
            set
            {
                specialities = value;

                Signal();
            }
        }

           


        public FirtsListVM()
        {

            FirstList = new CommandVM(() =>
            {
                CurrentPageControl.Instance.SetPage(new FirstList());
            });

            UserLastList = new CommandVM(() =>
            {
                CurrentPageControl.Instance.SetPage(new UserLastList());
            });

            MainWindow2 = new CommandVM(() =>
            {
                CurrentPageControl.Instance.SetPage(new MainWindow2());
            });

            Save = new CommandVM(async () =>
            {
                try
                {
                    var json = await HttpApi.Post("AduccationForms", "save", new AduccationForm
                    {
                        PatronicName = PatronicName,
                        PrimingCertificate = Score,
                        Fluorography = Flurografy,
                        MedicalPolicy = Polis,
                        RegistrationCertificate = RegistarionSerificate,
                        //SpecialityId = SelectedSpeciality.SpecialityId




                    });
                    var json3 = await HttpApi.Post("EducationForms", "save", new EducationForm
                    {
                        EducationName = EdducationForm
                    });

                    var json2 = await HttpApi.Post("Documets", "save", new Documet
                    {
                        Name = Name,
                        LastName = SecondName,
                        BirthdayDate = Date,
                        BirthPlace = PlaceBithday,
                        Inn = INN,
                        Nationality = Nationality,
                        PassSeries = Seria_Pass,
                        PassNumber = PassNumber,
                        IssuedBy = Who,
                        Snils = Snils,
                        Addres = Addres
                    });



                    Documet result = HttpApi.Deserialize<Documet>(json);
                    if (Name != null || SecondName != null || Date != null || Date != null || Who != null || PassNumber != null)
                    { MessageBox.Show("Сохранилось!"); }
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }

            });

            Task.Run(async () =>
            {
                var json = await HttpApi.Post("AduccationForms", "list", null);
                AduccationForm = HttpApi.Deserialize<List<AduccationForm>>(json);

                var json4 = await HttpApi.Post("EducationForms", "list", null);
                EducationForm = HttpApi.Deserialize<List<EducationForm>>(json4);

                var json2 = await HttpApi.Post("Documets", "list", null);
                Documents = HttpApi.Deserialize<List<Documet>>(json2);

                var json3 = await HttpApi.Post("Specialities", "list", null);
                Speciality = HttpApi.Deserialize<List<Speciality>>(json3);
            });
        }
    }
}
