using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Agenda.Model;
using System.Linq;
using Agenda.Banco;
using Xamarin.Essentials;
using Agenda.ViewModel;
using System.Resources;
using Newtonsoft.Json;

namespace Agenda
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            BindingContext = new ViewModel.AppViewModel(this);
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
