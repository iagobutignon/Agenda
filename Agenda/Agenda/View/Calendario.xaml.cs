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

            BindingContext = new ViewModel.CalendarioViewModel();

            CultureInfo culture = new CultureInfo("pt-Br");
            ViewCalendario.Culture = culture;
            
            //DatabaseCor database = new DatabaseCor();

            //Cor cor = database.Carregar();

            //if (cor != null)
            //{
            //    StackCalendario.BackgroundColor = Color.FromHex(cor.Fundo);

            //    ViewCalendario.BackgroundColor = Color.FromHex(cor.Fundo);
            //    ViewCalendario.ArrowsColor = Color.FromHex(cor.Fundo);
            //    ViewCalendario.DeselectedDayTextColor = Color.FromHex(cor.Texto);
            //    ViewCalendario.SelectedDateColor = Color.FromHex(cor.Texto);
            //    ViewCalendario.EventIndicatorColor = Color.FromHex(cor.Texto);
            //    ViewCalendario.EventIndicatorTextColor = Color.FromHex(cor.Texto);
            //    ViewCalendario.EventIndicatorSelectedColor = Color.FromHex(cor.Fundo);
            //    ViewCalendario.EventIndicatorSelectedTextColor = Color.FromHex(cor.Fundo);
            //    ViewCalendario.TodayOutlineColor = Color.FromHex(cor.Texto);
            //    ViewCalendario.DaysTitleColor = Color.FromHex(cor.Texto);
            //    ViewCalendario.YearLabelColor = Color.FromHex(cor.Texto);
            //    ViewCalendario.MonthLabelColor = Color.FromHex(cor.Texto);
            //    ViewCalendario.SelectedDayTextColor = Color.FromHex(cor.Fundo);
            //    ViewCalendario.SelectedDayBackgroundColor = Color.FromHex(cor.Texto);
            //}
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