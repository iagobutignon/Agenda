using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Agenda.Model;
using Agenda.Banco;
using Agenda;
using Agenda.View.CustomControl;

namespace Agenda.View.Config
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Temas : ContentPage
    {
        public Temas()
        {
            InitializeComponent();

            CarregarTemas();            
        }        
        public void CarregarTemas()
        {
            QuadroTema quadro;
            DatabaseTema database = new DatabaseTema();
            List<Tema> temas = database.Carregar();

            foreach (Tema tema in temas)
            {
                quadro = new QuadroTema
                (
                    "Personalizado",
                    tema.Nome,
                    tema.FundoTitulo,
                    tema.TextoTitulo,
                    tema.FundoApp,
                    tema.TextoApp
                );
                ((StackLayout)StackTemas).Children.Add(quadro);
            }

            quadro = new QuadroTema
            (
                "Padrão",
                "Azul",
                "#073b52",
                "#ffffff",
                "#ffffff",
                "#000000"
            );
            ((StackLayout)StackTemas).Children.Add(quadro);

            quadro = new QuadroTema
            (
                "Padrão",
                "Cinza",
                "#02121a",
                "#ffffff",
                "#04212e",
                "#ffffff"
            );
            ((StackLayout)StackTemas).Children.Add(quadro);

            quadro = new QuadroTema
             (
                 "Padrão",
                 "Preto",
                 "#000000",
                 "#ffffff",
                 "#2b2c2e",
                 "#ffffff"
             );
            ((StackLayout)StackTemas).Children.Add(quadro);
        }
    }
}