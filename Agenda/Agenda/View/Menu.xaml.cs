using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
        }
        public void BotaoGeral(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.Geral());
            IsPresented = false;
        }
        public void BotaoNovaTarefa(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.Cadastro());
            IsPresented = false;
        }
        public void BotaoTarefasPendentes(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.TarefasPendentes());
            IsPresented = false;
        }
        public void BotaoTarefasFinalizadas(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.TarefasFinalizadas());
            IsPresented = false;
        }
        public void BotaoCalendario(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.Calendario());
            IsPresented = false;
        }
        public void BotaoConfigurar(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.Config.Configurar());
            IsPresented = false;
        }
        public void BotaoPersonalizar(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.Config.Temas());
            IsPresented = false;
        }
        public void BotaoNovoTema(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new View.Config.NovoTema());
            IsPresented = false;
        }
    }
}