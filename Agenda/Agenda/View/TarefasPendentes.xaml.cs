using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Agenda.Banco;

namespace Agenda.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TarefasPendentes : ContentPage
    {
        List<Tarefa> Lista { get; set; }
        public TarefasPendentes()
        {
            InitializeComponent();

            Database database = new Database();
            Lista = database.Consultar();
            ListaTarefas.ItemsSource = Lista.Where(a => a.DataFinalizacao == null);
        }                
        public void Pesquisar(object sender, TextChangedEventArgs args)
        {            
            ListaTarefas.ItemsSource = Lista.Where(a => a.Nome.ToUpper().Contains(args.NewTextValue.ToUpper()) && a.DataFinalizacao == null).ToList();
        }
        public void Concluir(object sender, EventArgs args)
        {
            Image imgExcluir = (Image)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)imgExcluir.GestureRecognizers[0];
            Tarefa tarefa = tapGest.CommandParameter as Tarefa;
            tarefa.DataFinalizacao = DateTime.Now;

            Database database = new Database();            
            database.Atualizar(tarefa);

            Lista = database.Consultar();
            ListaTarefas.ItemsSource = Lista.Where(a => a.DataFinalizacao == null);
        }
        public void Excluir(object sender, EventArgs args)
        {
            Image imgExcluir = (Image)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)imgExcluir.GestureRecognizers[0];
            Tarefa tarefa = tapGest.CommandParameter as Tarefa;

            Database database = new Database();
            database.Excluir(tarefa);

            Lista = database.Consultar();
            ListaTarefas.ItemsSource = Lista.Where(a => a.DataFinalizacao == null);
        }
        public void Detalhar(object sender, EventArgs args)
        {
            StackLayout stackDetalhar = (StackLayout)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)stackDetalhar.GestureRecognizers[0];
            Tarefa tarefa = tapGest.CommandParameter as Tarefa;

            Navigation.PushAsync(new Detalhe(tarefa));
        }
    }
}