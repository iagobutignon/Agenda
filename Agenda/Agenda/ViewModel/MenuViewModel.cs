using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Agenda.ViewModel
{
    class MenuViewModel
    {
        private MasterDetailPage Page { get; set; }
        public Command GeralCommand { get; set; }
        public Command NovaTarefaCommand { get; set; }
        public Command TarefasPendentesCommand { get; set; }
        public Command TarefasConcluidasCommand { get; set; }
        public Command CalendarioCommand { get; set; }
        public Command ConfigurarCommand { get; set; }
        public MenuViewModel(MasterDetailPage page)
        {
            Page = page;

            GeralCommand = new Command(Geral);
            NovaTarefaCommand = new Command(NovaTarefa);
            TarefasPendentesCommand = new Command(TarefasPendentes);
            TarefasConcluidasCommand = new Command(TarefasConcluidas);
            CalendarioCommand = new Command(Calendario);
            ConfigurarCommand = new Command(Configurar);
        }

        private void Geral()
        {
            Page.Detail = new NavigationPage(new View.Geral());
            Page.IsPresented = false;
        }
        private void NovaTarefa()
        {
            Page.Detail = new NavigationPage(new View.Cadastro());
            Page.IsPresented = false;
        }
        private void TarefasPendentes()
        {
            Page.Detail = new NavigationPage(new View.TarefasPendentes());
            Page.IsPresented = false;
        }
        private void TarefasConcluidas()
        {
            Page.Detail = new NavigationPage(new View.TarefasFinalizadas());
            Page.IsPresented = false;
        }
        private void Calendario()
        {
            Page.Detail = new NavigationPage(new View.Calendario());
            Page.IsPresented = false;
        }
        private void Configurar()
        {
            Page.Detail = new NavigationPage(new View.Configuracoes.Configurar());
            Page.IsPresented = false;
        }
    }
}
