using Agenda.Banco;
using Agenda.Model;
using Agenda.View.Controles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Agenda.ViewModel.Configuracoes
{
    class TemasViewModel
    {
        private ContentPage Page { get; set; }
        private StackLayout Temas { get; set; }

        public TemasViewModel(ContentPage page, StackLayout temas)
        {
            Page = page;
            Temas = temas;

            CarregarTemas();
            TemasPadrao();
        }

        private void CarregarTemas()
        {
            QuadroTema quadro;
            DatabaseTema database = new DatabaseTema();
            List<Tema> temas = database.Carregar();

            foreach (Tema tema in temas)
            {
                quadro = new QuadroTema("Personalizado", tema);
                ((StackLayout)Temas).Children.Add(quadro);
            }            
        }
        private void TemasPadrao()
        {
            QuadroTema quadro;
            quadro = new QuadroTema("Padrão", new Tema()
            {
                Nome = "Azul",
                FundoTitulo = "#073b52",
                TextoTitulo = "#ffffff",
                FundoApp = "#ffffff",
                TextoApp = "#000000"
            });
            ((StackLayout)Temas).Children.Add(quadro);

            quadro = new QuadroTema("Padrão", new Tema()
            {
                Nome = "Cinza",
                FundoTitulo = "#02121a",
                TextoTitulo = "#ffffff",
                FundoApp = "#04212e",
                TextoApp = "#ffffff"
            });
            ((StackLayout)Temas).Children.Add(quadro);

            quadro = new QuadroTema("Padrão", new Tema()
            {
                Nome = "Preto",
                FundoTitulo = "#000000",
                TextoTitulo = "#ffffff",
                FundoApp = "#2b2c2e",
                TextoApp = "#ffffff"
            });
            ((StackLayout)Temas).Children.Add(quadro);
        }
    }
}
