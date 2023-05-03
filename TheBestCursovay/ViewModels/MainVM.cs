using TheBestCursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TheBestCursovay.Pages;
using WebTheBestCursach.Models;

namespace TheBestCursovay.ViewModels
{
    public class MainVM : BaseTools
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }


        public AduccationForm SelectedItem { get; set; }

        public AduccationForm aduccationForm { get; set; }

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

        public CommandVM EditList { get; set; }
        public CommandVM FirstList { get; set; }

        public CommandVM DeleteForm { get; set; }

        public CommandVM MainWindow2 { get; set; }

        public CommandVM LastList { get; set; }
        public CommandVM Profile { get; set; }

        public CommandVM UserLastList { get; set; }


        public MainVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("AduccationForms", "list", null);
                AduccationForm = HttpApi.Deserialize<List<AduccationForm>>(json);

                var json2 = await HttpApi.Post("Documets", "list", null);
                Documents = HttpApi.Deserialize<List<Documet>>(json2);

                var json3 = await HttpApi.Post("Specialities", "list", null);
                Speciality = HttpApi.Deserialize<List<Speciality>>(json3);


              
            });
            DeleteForm = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("AduccationForms", "delete", SelectedItem.DefaultListId);

                Task.Run(async () =>
                {
                    var json = await HttpApi.Post("AduccationForms", "list", null);
                    AduccationForm = HttpApi.Deserialize<List<AduccationForm>>(json);

                    var json2 = await HttpApi.Post("Documets", "list", null);
                    Documents = HttpApi.Deserialize<List<Documet>>(json2);

                    var json3 = await HttpApi.Post("Specialities", "list", null);
                    Speciality = HttpApi.Deserialize<List<Speciality>>(json3);
                });
            });

            currentPageControl =CurrentPageControl.Instance;
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;

            EditList = new CommandVM(async () =>
            {
                aduccationForm = SelectedItem;
                new EditList(aduccationForm).Show();
            });

            FirstList = new CommandVM(() =>
            {
                CurrentPageControl.Instance.SetPage(new FirstList());
            });

            Profile = new CommandVM(() =>
            {
                CurrentPageControl.Instance.SetPage(new Profile());
            });

            MainWindow2 = new CommandVM(() =>
            {
                CurrentPageControl.Instance.SetPage(new MainWindow2());
            });

            LastList = new CommandVM(() =>
            {
                CurrentPageControl.Instance.SetPage(new LastList());
            });

            UserLastList = new CommandVM(() =>
            {
                CurrentPageControl.Instance.SetPage(new UserLastList());
            });

        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }
    }
}
