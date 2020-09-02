using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaGeral : ContentPage
    {
        public ListaGeral(List<Tarefa> tarefas, string titulo)
        {
            InitializeComponent();

            BindingContext = new ViewModel.ListaGeralViewModel(tarefas, titulo);
        }
    }
}