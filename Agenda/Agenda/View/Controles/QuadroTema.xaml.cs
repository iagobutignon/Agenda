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

namespace Agenda.View.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuadroTema : ContentView
    {
        public QuadroTema(string titulo, Tema tema)
        {
            InitializeComponent();

            BindingContext = new ViewModel.Controles.QuadroTemaViewModel(titulo, tema, (ContentView)this);
        }
    }
}