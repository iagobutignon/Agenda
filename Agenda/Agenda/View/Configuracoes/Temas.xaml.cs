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
using Agenda.View.Controles;

namespace Agenda.View.Configuracoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Temas : ContentPage
    {
        public Temas()
        {
            InitializeComponent();

            BindingContext = new ViewModel.Configuracoes.TemasViewModel(this, StackTemas);                      
        }                
    }
}