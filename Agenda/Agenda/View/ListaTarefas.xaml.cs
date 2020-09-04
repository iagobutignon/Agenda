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
    public partial class ListaTarefas : ContentPage
    {
        public ListaTarefas(List<Tarefa> tarefas, string titulo)
        {
            InitializeComponent();

            BindingContext = new ViewModel.ListaTarefasViewModel(tarefas, titulo);
        }
    }
}