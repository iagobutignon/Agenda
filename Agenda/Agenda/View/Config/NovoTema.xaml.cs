using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.View.Config
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoTema : ContentPage
    {
        public NovoTema()
        {
            InitializeComponent();

            BindingContext = new ViewModel.NovoTemaViewModel();

            BotaoSelecionado(BotaoTextoTitulo, null);
            SliderModificado(null, null);
        }
        public void BotaoSelecionado(object sender, EventArgs args)
        {
            BotaoTextoApp.Opacity = 0.5;
            BotaoFundoApp.Opacity = 0.5;
            BotaoTextoTitulo.Opacity = 0.5;
            BotaoFundoTitulo.Opacity = 0.5;

            ((Button)sender).Opacity = 1;
        }
        public void SliderModificado(object sender, EventArgs args)
        {
            var NovoTemaViewModel = BindingContext as ViewModel.NovoTemaViewModel;

            LabelTitulo.TextColor = Color.FromHex(NovoTemaViewModel.TextoTitulo);
            LabelTitulo.BackgroundColor = Color.FromHex(NovoTemaViewModel.FundoTitulo);
            LabelApp.TextColor = Color.FromHex(NovoTemaViewModel.TextoApp);
            LabelApp.BackgroundColor = Color.FromHex(NovoTemaViewModel.FundoApp);
        }
    }
}