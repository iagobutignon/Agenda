using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Agenda.Banco;
using Agenda.Model;
using Agenda.ViewModel;
using Newtonsoft.Json;

namespace Agenda.ViewModel.Configuracoes
{
    class NovoTemaViewModel : INotifyPropertyChanged
    {        
        public int R { get { return _R; } set {_R = value; IsPropertyChanged("R"); } }
        private int _R;

        public int G { get { return _G; } set { _G = value; IsPropertyChanged("G"); } }
        private int _G;

        public int B { get { return _B; } set { _B = value; IsPropertyChanged("B"); } }
        private int _B;

        public string Nome { get { return _Nome; } set { _Nome = value; IsPropertyChanged("Nome"); } }
        private string _Nome;

        public string FundoTitulo { get; set; }
        public string TextoTitulo { get; set; }
        public string FundoApp { get; set; }
        public string TextoApp { get; set; }        
        
        private byte Escolha;
        public Command FundoTituloSelecionado { get; set; }
        public Command TextoTituloSelecionado { get; set; }
        public Command FundoAppSelecionado { get; set; }
        public Command TextoAppSelecionado { get; set; }
        public Command Aplicar { get; set; }
        public Command Salvar { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NovoTemaViewModel()
        {
            FundoTituloSelecionado = new Command(FundoTituloCommand);
            TextoTituloSelecionado = new Command(TextoTituloCommand);
            FundoAppSelecionado = new Command(FundoAppCommand);
            TextoAppSelecionado = new Command(TextoAppCommand);
            Aplicar = new Command(AplicarCommand);
            Salvar = new Command(SalvarCommand);

            Escolha = 1;
            FundoTitulo = "#073b52";
            TextoTitulo = "#ffffff";
            FundoApp = "#ffffff";
            TextoApp = "#000000";
            FundoTituloCommand();
            FundoAppCommand();
            TextoTituloCommand();
            TextoAppCommand();
        }
        private void FundoTituloCommand()
        {
            Escolha = 0;
            System.Drawing.Color cor = Xamarin.Forms.Color.FromHex(FundoTitulo);
            R = cor.R;
            G = cor.G;
            B = cor.B;
        }
        private void TextoTituloCommand()
        {
            Escolha = 1;
            System.Drawing.Color cor = Xamarin.Forms.Color.FromHex(TextoTitulo);
            R = cor.R;
            G = cor.G;
            B = cor.B;
        }
        private void FundoAppCommand()
        {
            Escolha = 2;
            System.Drawing.Color cor = Xamarin.Forms.Color.FromHex(FundoApp);
            R = cor.R;
            G = cor.G;
            B = cor.B;
        }
        private void TextoAppCommand()
        {
            Escolha = 3;
            System.Drawing.Color cor = Xamarin.Forms.Color.FromHex(TextoApp);
            R = cor.R;
            G = cor.G;
            B = cor.B;
        }
        private void AplicarCommand()
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
        private void SalvarCommand()
        {
            var app = (AppViewModel)App.Current.BindingContext;
            app.TemaAlterado(FundoTitulo, TextoTitulo, FundoApp, TextoApp);

            DatabaseTema database = new DatabaseTema();
            Tema tema = new Tema() 
            { 
                Nome = this.Nome, 
                FundoTitulo = this.FundoTitulo, 
                TextoTitulo = this.TextoTitulo, 
                FundoApp = this.FundoApp, 
                TextoApp = this.TextoApp
            };
            database.Salvar(tema);

            string json = JsonConvert.SerializeObject(tema);

            if (App.Current.Properties.ContainsKey("Tema"))
                App.Current.Properties.Remove("Tema");

            App.Current.Properties.Add("Tema", json);

            App.Current.MainPage = new Agenda.View.Menu();
        }
        private void IsPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            ProcessarCor();
        }        
        public void ProcessarCor()
        {
            if (Escolha == 0)
                FundoTitulo = String.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);

            if (Escolha == 1)
                TextoTitulo = String.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);

            if (Escolha == 2)
                FundoApp = String.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);

            if (Escolha == 3)
                TextoApp = String.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);            
        }     
    }
}
