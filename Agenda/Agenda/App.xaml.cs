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

            BindingContext = new ViewModel.AppViewModel();

            CarregaTema();

            MainPage = new Agenda.View.Menu();
        }

        public void TemaAlterado(string fundoTitulo, string textoTitulo, string fundoApp, string textoApp)
        {
            var appViewModel = BindingContext as AppViewModel;

            Resources["FundoTitulo"] = fundoTitulo;
            Resources["TextoTitulo"] = textoTitulo;
            Resources["FundoApp"] = fundoApp;
            Resources["TextoApp"] = textoApp;
        }
        public void CarregaTema()
        {
            if (App.Current.Properties.ContainsKey("Tema"))
            {
                string json = (string)App.Current.Properties["Tema"];
                Tema tema = JsonConvert.DeserializeObject<Tema>(json);

                TemaAlterado(tema.FundoTitulo, tema.TextoTitulo, tema.FundoApp, tema.TextoApp);
            }
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
