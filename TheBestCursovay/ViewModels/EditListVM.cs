using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheBestCursovay.Pages;
using TheBestCursovay.Tools;
using WebTheBestCursach.Models;

namespace TheBestCursovay.ViewModels
{
    internal class EditListVM : BaseTools
    {
        public CommandVM Save { get; set; }

        public CommandVM EditForm { get; set; }

        public AduccationForm aduccationform { get; set; }
        public EducationForm educationform { get; set; }

        public AduccationForm SelectedItem { get; set; }

        public string Name { get; set; }
        public string PatronicName { get; set; }
        public string PrimingCertificate { get; set; }
        public string RegistarionSerificate { get; set; }
        public string Polis { get; set; }
        public string Flurografy { get; set; }
        public string SecondName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string PlaceBithday { get; set; }
        public long INN { get; set; }
        public string Nationality { get; set; }
        public int Seria_Pass { get; set; }
        public int PassNumber { get; set; }
        public string Who { get; set; }
        public string Score { get; set; }
        public int Snils { get; set; }
        public string Addres { get; set; }
        public string EdducationForm { get; set; }


        public List<EducationForm> educationForm;
        private List<AduccationForm> aduccationForms;
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

        public List<Documet> Documet
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

        public List<EducationForm> EducationForm
        {
            get => educationForm;
            set
            {
                educationForm = value;

                Signal();
            }
        }

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


        public EditListVM(AduccationForm aduccationForm, EducationForm educationForm, Documet documet)
        {


            Task.Run(async () =>
            {
                var json = await HttpApi.Post("AduccationForms", "list", null);
                AduccationForm = HttpApi.Deserialize<List<AduccationForm>>(json);

                var json2 = await HttpApi.Post("Documets", "list", null);
                Documet = HttpApi.Deserialize<List<Documet>>(json2);

                var json3 = await HttpApi.Post("Specialities", "list", null);
                Speciality = HttpApi.Deserialize<List<Speciality>>(json3);

                var json4 = await HttpApi.Post("EducationForms", "list", null);
                EducationForm = HttpApi.Deserialize<List<EducationForm>>(json4);
            });

            EditForm = new CommandVM(async () =>
            {
                aduccationform = SelectedItem;
                educationform = SelectedItem;
                new EditList(aduccationform).Show();
            });


            Save = new CommandVM(async () =>
            {
                var json3 = await HttpApi.Post("AduccationForms", "put", new AduccationForm
                {
                    DefaultListId = aduccationForm.DefaultListId,
                    PatronicName = PatronicName,
                    PrimingCertificate = Score,
                    Fluorography = Flurografy,
                    MedicalPolicy = Polis,
                    RegistrationCertificate = RegistarionSerificate,
                    SpecialityId = SelectedSpeciality.SpecialityId
                });
                var json = await HttpApi.Post("EducationForms", "put", new EducationForm
                {
                    EducationName = EdducationForm
                });

                var json2 = await HttpApi.Post("Documets", "put", new Documet
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

                MessageBox.Show("Сохранилось!");
            });

        }
    }
}
