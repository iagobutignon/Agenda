using Agenda.ViewModel;
using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.macOSSpecific;
using Xamarin.Forms.Xaml;

namespace Agenda.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Geral : ContentPage
    {
        public Geral()
        {
            InitializeComponent();

            BindingContext = new ViewModel.GeralViewModel(this);            
        }
    }
}