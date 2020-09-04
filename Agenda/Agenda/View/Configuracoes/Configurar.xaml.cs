using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.View.Configuracoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configurar : TabbedPage
    {
        public Configurar()
        {
            InitializeComponent();

            BindingContext = new ViewModel.Configuracoes.ConfigurarViewModel(this);
        }
    }
}