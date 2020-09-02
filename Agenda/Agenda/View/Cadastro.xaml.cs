using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Agenda.Model;
using Agenda.Banco;

namespace Agenda.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        private byte Prioridade { get; set; }
        public Cadastro()
        {
            InitializeComponent();
        }
        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            var stacks = SLPrioridades.Children;

            foreach (var Linha in stacks)
            {
                ((Image)((StackLayout)Linha).Children[0]).Opacity = 0.5;
                ((Label)((StackLayout)Linha).Children[1]).Opacity = 0.5;
            }
            ((Image)((StackLayout)sender).Children[0]).Opacity = 1;
            ((Label)((StackLayout)sender).Children[1]).Opacity = 1;

            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            string prioridade = Source.File.ToString().Replace(".png", "").Replace("p", "");
            
            Prioridade = byte.Parse(prioridade);
        }
        public void SalvarAction(object sender, EventArgs args)
        {
            bool erroExiste = false;

            if (Nome.Text == null || Nome.Text.Trim().Length <= 0)
            {
                erroExiste = true;
                DisplayAlert("Erro", "Tarefa não digitada", "Okay");
            }

            if (Descricao.Text == null || Descricao.Text.Trim().Length <= 0)
            {
                erroExiste = true;
                DisplayAlert("Erro", "Tarefa não digitada", "Okay");
            }

            if (Prioridade <= 0)
            {
                erroExiste = true;
                DisplayAlert("Erro", "Prioridade não escolhida", "Okay");
            }

            if (erroExiste == false)
            {
                Tarefa tarefa = new Tarefa();

                tarefa.Nome = Nome.Text.Trim();
                tarefa.Descricao = Descricao.Text.Trim();
                tarefa.Data = Data.Date + Hora.Time;
                tarefa.Prioridade = this.Prioridade;

                Database database = new Database();
                database.Cadastrar(tarefa);                
                
                App.Current.MainPage = new View.Menu();
            }
        }
    }
}