using Agenda.Banco;
using Agenda.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Agenda.ViewModel
{
    class AppViewModel
    {
        private Application Application { get; set; }
        public string FundoTitulo { get; set; }        
        public string TextoTitulo { get; set; }
        public string FundoApp { get; set; }
        public string TextoApp { get; set; }

        public AppViewModel(Application application)
        {
            Application = application;

            FundoTitulo = "#073b52";
            TextoTitulo = "#ffffff";
            FundoApp = "#ffffff";
            TextoApp = "#000000";

            CarregaTema();

            Application.MainPage = new Agenda.View.Menu();
        }
        public void TemaAlterado(string fundoTitulo, string textoTitulo, string fundoApp, string textoApp)
        {
            Application.Resources["FundoTitulo"] = fundoTitulo;
            Application.Resources["TextoTitulo"] = textoTitulo;
            Application.Resources["FundoApp"] = fundoApp;
            Application.Resources["TextoApp"] = textoApp;
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
    }
}
