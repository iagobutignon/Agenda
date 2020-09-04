using Agenda.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Agenda.ViewModel.Controles
{
    class QuadroTemaViewModel
    {
        public string Titulo { get; set; }
        public string Nome { get; set; }
        public string FundoTitulo { get; set; }
        public string TextoTitulo { get; set; }
        public string FundoApp { get; set; }
        public string TextoApp { get; set; }
        public Command TemaSelecionado { get; set; }

        public QuadroTemaViewModel(string titulo, Tema tema, ContentView quadroTema)
        {
            Titulo = titulo;
            Nome = tema.Nome;
            FundoTitulo = tema.FundoTitulo;
            TextoTitulo = tema.TextoTitulo;
            FundoApp = tema.FundoApp;
            TextoApp = tema.TextoApp;

            quadroTema.Resources["FundoTitulo"] = FundoTitulo;
            quadroTema.Resources["TextoTitulo"] = TextoTitulo;
            quadroTema.Resources["FundoApp"] = FundoApp;
            quadroTema.Resources["TextoApp"] = TextoApp;

            TemaSelecionado = new Command(TemaSelecionadoCommand);
        }
        private void TemaSelecionadoCommand()
        {
            var app = (AppViewModel)App.Current.BindingContext;
            app.TemaAlterado(FundoTitulo, TextoTitulo, FundoApp, TextoApp);

            Tema tema = new Tema()
            {
                Nome = this.Nome,
                FundoTitulo = this.FundoTitulo,
                TextoTitulo = this.TextoTitulo,
                FundoApp = this.FundoApp,
                TextoApp = this.TextoApp
            };

            string json = JsonConvert.SerializeObject(tema);

            if (App.Current.Properties.ContainsKey("Tema"))
                App.Current.Properties.Remove("Tema");

            App.Current.Properties.Add("Tema", json);
        }
    }
}
