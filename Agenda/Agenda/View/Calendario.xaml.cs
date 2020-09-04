using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Agenda.Banco;
using Agenda.Model;
using Agenda.ViewModel;
using System.Globalization;

namespace Agenda.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calendario : ContentPage
    {
        public Calendario()
        {
            InitializeComponent();

            BindingContext = new ViewModel.CalendarioViewModel(this);          
        }

        private void DetalheEvento(object sender, EventArgs args)
        {
            Frame frameDetalhar = (Frame)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)frameDetalhar.GestureRecognizers[0];
            Tarefa tarefa = tapGest.CommandParameter as Tarefa;

            Navigation.PushAsync(new Detalhe(tarefa));
        }
    }
}