using Agenda.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Markup.LeftToRight;
using Xamarin.Forms.Xaml;

namespace Agenda.View.CustomControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuadroTema : ContentView
    {
        public string Titulo { get; set; }
        public string Nome { get; set; }
        public string FundoTitulo { get; set; }
        public string TextoTitulo { get; set; }
        public string FundoApp { get; set; }
        public string TextoApp { get; set; }
        public QuadroTema(string titulo, string nome, string fundoTitulo, string textoTitulo, string fundoApp, string textoApp)
        {
            InitializeComponent();

            Titulo = titulo;
            Nome = nome;
            FundoTitulo = fundoTitulo;
            TextoTitulo = textoTitulo;
            FundoApp = fundoApp;
            TextoApp = textoApp;

            ((Label)LabelTitulo).Text = titulo;
            ((Label)LabelApp).Text = nome;
            Resources["FundoTitulo"] = fundoTitulo;
            Resources["TextoTitulo"] = textoTitulo;
            Resources["FundoApp"] = fundoApp;
            Resources["TextoApp"] = textoApp;
        }
        public void TemaSelecionado(object sender, EventArgs args)
        {
            var app = (App)App.Current;
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